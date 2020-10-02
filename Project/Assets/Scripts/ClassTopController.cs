using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassTopController : MonoBehaviour
{

    public Dropdown drop;

    public Button add;
    public Button del;
    public Button del2;

    public GameObject go_del;
    public GameObject go_drop;
    public GameObject go_add;
    public GameObject go_txt;
    public GameObject go_txt2;
    public GameObject go_del2;

    public GameObject container;
    public string name;

    public ClassController classController;

    public string dropMsg;

    // Start is called before the first frame update
    void Start()
    {
        add.onClick.AddListener(addClick);
        del.onClick.AddListener(delClick);
        del2.onClick.AddListener(del2Click);
        go_del.SetActive(false);

        classController = container.transform.parent.GetComponent<ClassController>();

    }

    void del2Click()
    {
        classController.del();
    }

    void addClick()
    {
        go_del.SetActive(true);
        go_drop.SetActive(false);
        go_add.SetActive(false);
        go_txt.SetActive(false);
        go_txt2.SetActive(false);
        
        int dropdownValue = drop.value;
        dropMsg = drop.options[dropdownValue].text;

        string txt = container.GetComponent<UnityEngine.UI.Text>().text;

        if (container.transform.parent.name == "ClassWithParams(Clone)")
        {
            container.GetComponent<UnityEngine.UI.Text>().text = "class " + dropMsg + " ( ";
        }
        else
        {
            container.GetComponent<UnityEngine.UI.Text>().text = "class " + dropMsg + " { ";
        }
        

        name = container.GetComponent<UnityEngine.UI.Text>().text;
        classController.name = name;

    }

    void delClick()
    {

        container.GetComponent<UnityEngine.UI.Text>().text = "";
        name = container.GetComponent<UnityEngine.UI.Text>().text;

        classController.name = name;


        go_del.SetActive(false);
        go_drop.SetActive(true);
        go_add.SetActive(true);
        go_txt.SetActive(true);
        go_txt2.SetActive(true);
    }
}
