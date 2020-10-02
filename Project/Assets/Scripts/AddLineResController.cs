using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddLineResController : MonoBehaviour
{
    public Button add;
    public GameObject container;
    public GameObject line;
    


    void Start()
    {
        add.onClick.AddListener(addClick);
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
