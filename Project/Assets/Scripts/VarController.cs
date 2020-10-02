using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VarController : MonoBehaviour
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
    public  SolutionAnalyzer solutionAnalyzer;
   

    public string content = "";

    void Start()
    {
        go_mod.SetActive(false);
        add.onClick.AddListener(addClick);
        del.onClick.AddListener(delClick);
        mod.onClick.AddListener(modClick);
        solutionAnalyzer = GameObject.Find("rhsPanel").GetComponent<SolutionAnalyzer>();
    }

    void modClick()
    {
        txt.text = "";

        go_mod.SetActive(false);
        go_add.SetActive(true);
        go_droplhs.SetActive(true);
        go_droprhs.SetActive(true);
        go_txt.SetActive(true);

        if (container.name != "ClassVar")
        {
            solutionAnalyzer.variables.Remove(container);
        }
        else
        {
            ClassController classController = container.transform.parent.transform.parent.GetComponent<ClassController>();
            classController.classVariables.Remove(container);
        }
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
        content = dropMsg1 + " = " + dropMsg2;
        
        txt.text = content;

        go_mod.SetActive(true);
        go_add.SetActive(false);
        go_droplhs.SetActive(false);
        go_droprhs.SetActive(false);
        go_txt.SetActive(false);

        if (container.name != "ClassVar")
        {
            solutionAnalyzer.variables.Add(container);
        }
        else
        {
            ClassController classController = container.transform.parent.transform.parent.GetComponent<ClassController>();
            classController.classVariables.Add(container);
        }

    }

    void delClick()
    {
        if(container.name != "ClassVar")
        {
            solutionAnalyzer.variables.Remove(container);
            DestroyImmediate(container);
        }
        else
        {
            ClassController classController = container.transform.parent.transform.parent.GetComponent<ClassController>();
            classController.classVariables.Remove(container);
            GameObject wrapper = container.transform.parent.gameObject;

            DestroyImmediate(wrapper);
        }
        
    }


}
