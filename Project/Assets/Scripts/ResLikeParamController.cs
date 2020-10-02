using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResLikeParamController : MonoBehaviour
{

    public Dropdown droplhs;
    public Dropdown droprhs;
    public Button add;
    public Button del;
    public Button mod;

    public GameObject go_mod;
    public GameObject go_droplhs;
    public GameObject go_droprhs;
    public GameObject go_add;
    public GameObject go_del;
    public GameObject container;
    public GameObject go_txt;
    public Text txt;
    public ResLikeController resLikeController;


    public string content = "";

    void Start()
    {
        go_mod.SetActive(false);
        add.onClick.AddListener(addClick);
        del.onClick.AddListener(delClick);
        mod.onClick.AddListener(modClick);
        resLikeController = container.transform.parent.transform.parent.GetComponent<ResLikeController>();

    }

    void modClick()
    {
        txt.text = "";

        go_mod.SetActive(false);
        go_add.SetActive(true);
        go_droplhs.SetActive(true);
        go_droprhs.SetActive(true);
        go_txt.SetActive(true);

        resLikeController.classParams.Remove(container);

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
        content = dropMsg1 + " => " + dropMsg2;

        txt.text = content;

        GameObject nextSibling = container.transform.parent.transform.parent.GetChild(container.transform.parent.GetSiblingIndex() + 1).gameObject;


        if (nextSibling.transform.name != "AddParameter")
        {
            txt.text = content + ',';
        }

        GameObject prevSibling = container.transform.parent.transform.parent.GetChild(container.transform.parent.GetSiblingIndex() - 1).gameObject;

        if (prevSibling.transform.name != "ResLikeTop")
        {
            string prevContent = prevSibling.transform.GetChild(1).GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text;

            if (!prevContent.EndsWith(",") && prevContent != "")
            {

                prevSibling.transform.GetChild(1).GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = prevContent + ",";
            }
        }

        go_mod.SetActive(true);
        go_add.SetActive(false);
        go_droplhs.SetActive(false);
        go_droprhs.SetActive(false);
        go_txt.SetActive(false);
        
        resLikeController.classParams.Add(container);

    }

    void delClick()
    {
        GameObject nextSibling = container.transform.parent.transform.parent.GetChild(container.transform.parent.GetSiblingIndex() + 1).gameObject;

        if (nextSibling.transform.name == "AddParameter")
        {
            GameObject prevSibling = container.transform.parent.transform.parent.GetChild(container.transform.parent.GetSiblingIndex() - 1).gameObject;
            string prevContent = prevSibling.transform.GetChild(1).GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text;
            if (prevContent.EndsWith(","))
            {
                prevSibling.transform.GetChild(1).GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = prevContent.Substring(0, prevContent.Length - 1);
            }
        }

        
        resLikeController.classParams.Remove(container);

        GameObject wrapper = container.transform.parent.gameObject;

        DestroyImmediate(wrapper);

    }


}
