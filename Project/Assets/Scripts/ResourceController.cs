using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceController : MonoBehaviour
{

    public Dropdown drop;
    public Button add;
    public Button delete;
    public GameObject container;
    public GameObject go_add;
    public GameObject go_start;
    public GameObject go_delete;

    public GameObject topPart;
    public GameObject botPart;
    public GameObject mid2Part;
    
    public SolutionAnalyzer solutionAnalyzer;

    public string name;
    public List<GameObject> definitions;

    public string dropMsg;

    

    // Start is called before the first frame update
    void Start()
    {
        add.onClick.AddListener(addClick);
        delete.onClick.AddListener(deleteClick);

        definitions = new List<GameObject>();

        solutionAnalyzer = GameObject.Find("rhsPanel").GetComponent<SolutionAnalyzer>();

    }

    void addClick()
    {
        string txt = container.GetComponent<UnityEngine.UI.Text>().text;
        int dropdownValue = drop.value;
        dropMsg = drop.options[dropdownValue].text;

        GameObject nl = GameObject.Instantiate(topPart);
        nl.transform.SetParent(container.transform);
        nl.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        nl.transform.SetAsFirstSibling();

        nl.GetComponent<UnityEngine.UI.Text>().text = dropMsg + " { ";

        GameObject nl2 = GameObject.Instantiate(mid2Part);
        nl2.transform.SetParent(container.transform);
        nl2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        nl2.transform.SetAsLastSibling();

        GameObject brack = GameObject.Instantiate(botPart);
        brack.transform.SetParent(container.transform);
        brack.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        brack.transform.SetAsLastSibling();

        //go_delete.transform.SetAsLastSibling();
      

        DestroyImmediate(go_start);


        if(container.name != "ClassResource")
        {
            solutionAnalyzer.resources.Add(container);
        }
        else
        {
            ClassController classController = container.transform.parent.transform.parent.GetComponent<ClassController>();
            classController.classResources.Add(container);
        }
    }

    public void deleteClick()
    {
        if(container.name != "ClassResource")
        {
            solutionAnalyzer.resources.Remove(container);
            DestroyImmediate(container);
        }
        else
        {
            ClassController classController = container.transform.parent.transform.parent.GetComponent<ClassController>();
            classController.classResources.Remove(container);
            GameObject wrapper = container.transform.parent.gameObject;

            DestroyImmediate(wrapper);
        }
    }
}
