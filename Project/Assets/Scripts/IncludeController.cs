using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncludeController : MonoBehaviour
{

    public Dropdown drop;

    public Button add;
    public Button del;
    public Button del2;

    public GameObject go_del;
    public GameObject go_drop;
    public GameObject go_add;
    public GameObject go_txt;
    public GameObject go_del2;

    public string content;

    public GameObject container;

    public SolutionAnalyzer solutionAnalyzer;

    public string dropMsg;

    void Start()
    {
        add.onClick.AddListener(addClick);
        del.onClick.AddListener(delClick);
        del2.onClick.AddListener(del2Click);
        go_del.SetActive(false);

        solutionAnalyzer = GameObject.Find("rhsPanel").GetComponent<SolutionAnalyzer>();

    }

    void del2Click()
    {
        solutionAnalyzer.includes.Remove(container);
        DestroyImmediate(container);
    }

    void addClick()
    {
        go_del.SetActive(true);
        go_drop.SetActive(false);
        go_add.SetActive(false);
        go_txt.SetActive(false);

        int dropdownValue = drop.value;
        dropMsg = drop.options[dropdownValue].text;

        string txt = container.GetComponent<UnityEngine.UI.Text>().text;

        container.GetComponent<UnityEngine.UI.Text>().text = "include " + dropMsg;

        content = container.GetComponent<UnityEngine.UI.Text>().text;

        solutionAnalyzer.includes.Add(container);

    }

    void delClick()
    {
        solutionAnalyzer.includes.Remove(container);
        go_del.SetActive(false);
        go_drop.SetActive(true);
        go_add.SetActive(true);
        go_txt.SetActive(true);
    }
}
