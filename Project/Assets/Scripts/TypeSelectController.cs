using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeSelectController : MonoBehaviour
{
    public GameObject go_drop;
    public GameObject go_add;
    public GameObject container;
    public GameObject res;
    public GameObject var;
    public GameObject cla;
    public GameObject go_del;
    public GameObject include;
    public GameObject paramClass;
    public GameObject resLike;
    public Button del;

    public Button add;
    public Dropdown drop;

    void Start()
    {
        add.onClick.AddListener(addClick);
        del.onClick.AddListener(delClick);
    }
    
    
    void addClick()
    {
        int dropdownValue = drop.value;
        string dropMsg = drop.options[dropdownValue].text;

        if(dropMsg == "Resource")
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
        else if (dropMsg == "Class")
        {
            GameObject nl = GameObject.Instantiate(cla);
            nl.transform.SetParent(container.transform.parent);
            nl.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            nl.transform.SetSiblingIndex(container.transform.GetSiblingIndex());
        }
        else if (dropMsg == "Include")
        {
            GameObject nl = GameObject.Instantiate(include);
            nl.transform.SetParent(container.transform.parent);
            nl.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            nl.transform.SetSiblingIndex(container.transform.GetSiblingIndex());
        }
        else if(dropMsg == "Parametrized Class")
        {
            GameObject nl = GameObject.Instantiate(paramClass);
            nl.transform.SetParent(container.transform.parent);
            nl.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            nl.transform.SetSiblingIndex(container.transform.GetSiblingIndex());
        }
        else if (dropMsg == "Res. Like Definition")
        {
            GameObject nl = GameObject.Instantiate(resLike);
            nl.transform.SetParent(container.transform.parent);
            nl.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            nl.transform.SetSiblingIndex(container.transform.GetSiblingIndex());
        }

        DestroyImmediate(container);


    }

    void delClick()
    {
        DestroyImmediate(container);
    }
}
