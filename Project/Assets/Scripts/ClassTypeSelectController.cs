using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassTypeSelectController : MonoBehaviour
{
    public GameObject go_drop;
    public GameObject go_add;
    public GameObject container;
    public GameObject res;
    public GameObject var;
    public GameObject go_del;

    public Button del;
    public Button add;
    public Dropdown drop;

    void Start()
    {
        del.onClick.AddListener(delClick);
        add.onClick.AddListener(addClick);
    }

    void delClick()
    {
        DestroyImmediate(container);
    }

    void addClick()
    {
        int dropdownValue = drop.value;
        string dropMsg = drop.options[dropdownValue].text;

        if (dropMsg == "Resource")
        {
            GameObject nl = GameObject.Instantiate(res);
            nl.transform.SetParent(container.transform.parent);
            nl.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            nl.transform.SetSiblingIndex(container.transform.GetSiblingIndex());
        }

        else if (dropMsg == "Variable")
        {
            GameObject nl = GameObject.Instantiate(var);
            nl.transform.SetParent(container.transform.parent);
            nl.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            nl.transform.SetSiblingIndex(container.transform.GetSiblingIndex());
        }

        DestroyImmediate(container);


    }
}
