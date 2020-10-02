using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddLineClassController : MonoBehaviour
{
    public Button add;
    public GameObject container;
    public GameObject line;

    public ResourceController resourceController;


    void Start()
    {
        add.onClick.AddListener(addClick);
        resourceController = container.transform.parent.GetComponent<ResourceController>();
    }

    void addClick()
    {
        int index = container.transform.GetSiblingIndex();

        GameObject nl = GameObject.Instantiate(line, new Vector3(0, 0, 0), Quaternion.identity);
        nl.transform.SetParent(container.transform.parent);
        nl.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        nl.transform.SetSiblingIndex(index);
        

    }
}
