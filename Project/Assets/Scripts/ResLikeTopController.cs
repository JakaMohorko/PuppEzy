using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResLikeTopController : MonoBehaviour
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

    public GameObject container;
    public string name;

    public ResLikeController resLikeController;

    public string dropMsg;

    // Start is called before the first frame update
    void Start()
    {
        add.onClick.AddListener(addClick);
        del.onClick.AddListener(delClick);
        del2.onClick.AddListener(del2Click);
        go_del.SetActive(false);

        resLikeController = container.transform.parent.GetComponent<ResLikeController>();

    }

    void del2Click()
    {
        resLikeController.del();
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

        container.GetComponent<UnityEngine.UI.Text>().text = "class { '" + dropMsg + "':";
 


        name = container.GetComponent<UnityEngine.UI.Text>().text;
        resLikeController.name = name;

    }

    void delClick()
    {

        container.GetComponent<UnityEngine.UI.Text>().text = "";
        name = container.GetComponent<UnityEngine.UI.Text>().text;

        resLikeController.name = name;


        go_del.SetActive(false);
        go_drop.SetActive(true);
        go_add.SetActive(true);
        go_txt.SetActive(true);
    }
}
