using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceMidController : MonoBehaviour
{

    public Dropdown droplhs;
    public Dropdown droprhs;
    public Button add;
    public Button del;
    public Button mod;

    public GameObject go_droplhs;
    public GameObject go_droprhs;
    public GameObject go_add;
    public GameObject go_del;
    public GameObject container;
    public GameObject go_txt;
    public GameObject go_mod;

    public ResourceController resourceController;

    public string content = "";

    void Start()
    {
        go_del.SetActive(true);
        go_mod.SetActive(false);
        add.onClick.AddListener(addClick);
        del.onClick.AddListener(delClick);
        mod.onClick.AddListener(modClick);
        resourceController = container.transform.parent.GetComponent<ResourceController>();
    }
    
    void modClick()
    {
        container.GetComponent<UnityEngine.UI.Text>().text = "";
        
        go_add.SetActive(true);
        go_droplhs.SetActive(true);
        go_droprhs.SetActive(true);
        go_txt.SetActive(true);
        go_mod.SetActive(false);

        resourceController.definitions.Remove(container);
    }

    void addClick()
    {
        string dropMsg1 = "";
        string dropMsg2 = "";
        int dropdownValue1;
        int dropdownValue2;
        
        dropdownValue1 = droplhs.value;
        dropdownValue2 = droprhs.value;
        dropMsg1 = droplhs.options[dropdownValue1].text;
        dropMsg2 = droprhs.options[dropdownValue2].text;
        content = "\t" + dropMsg1 + " => " + dropMsg2;

        container.GetComponent<UnityEngine.UI.Text>().text = content;
   
        GameObject nextSibling = container.transform.parent.GetChild(container.transform.GetSiblingIndex()+1).gameObject;


        if (nextSibling.transform.name != "ResMidClass2(Clone)" && nextSibling.transform.name != "resourcemid2(Clone)")
        {
            container.GetComponent<UnityEngine.UI.Text>().text = content + ',';

            
        }

        GameObject prevSibling = container.transform.parent.GetChild(container.transform.GetSiblingIndex() - 1).gameObject;
        string prevContent = prevSibling.GetComponent<UnityEngine.UI.Text>().text;
        if(prevSibling.transform.name != "resourcetop(Clone)" && prevSibling.transform.name != "ResTopClass(Clone)")
        {
            if (!prevContent.EndsWith(",") && prevContent != "")
            {
                prevSibling.GetComponent<UnityEngine.UI.Text>().text = prevContent + ",";
            }
        }
        
        go_add.SetActive(false);
        go_droplhs.SetActive(false);
        go_droprhs.SetActive(false);
        go_txt.SetActive(false);
        go_mod.SetActive(true);

        resourceController.definitions.Add(container);

    }

    void delClick()
    {
        GameObject nextSibling = container.transform.parent.GetChild(container.transform.GetSiblingIndex() + 1).gameObject;

        if (nextSibling.transform.name != "ResMidClass2(Clone)" && nextSibling.transform.name != "resourcemid2(Clone)")
        {
            GameObject prevSibling = container.transform.parent.GetChild(container.transform.GetSiblingIndex() - 1).gameObject;
            string prevContent = prevSibling.GetComponent<UnityEngine.UI.Text>().text;
            if (prevContent.EndsWith(","))
            {
                prevSibling.GetComponent<UnityEngine.UI.Text>().text = prevContent.Substring(0, prevContent.Length - 1);
            }
        }
        

        resourceController.definitions.Remove(container);
        DestroyImmediate(container);
    }


}
