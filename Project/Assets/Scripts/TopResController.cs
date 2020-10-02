using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopResController : MonoBehaviour
{

    public Dropdown drop;
    public Button add;
    public Button del;
    public Button delcont;
    public GameObject go_del;
    public GameObject go_drop;
    public GameObject go_add;
    public GameObject go_delcont;
    public GameObject container;
    public string dropMsg;

    public ResourceController resourceController;

    // Start is called before the first frame update
    void Start()
    {
        add.onClick.AddListener(addClick);
        del.onClick.AddListener(delClick);
        delcont.onClick.AddListener(delcontClick);
        go_del.SetActive(false);

        resourceController = container.transform.parent.GetComponent<ResourceController>();
    }

    void addClick()
    {
        go_del.SetActive(true);
        go_drop.SetActive(false);
        go_add.SetActive(false);

        string txt = container.GetComponent<UnityEngine.UI.Text>().text;
        int dropdownValue = drop.value;
        dropMsg = drop.options[dropdownValue].text;

        container.GetComponent<UnityEngine.UI.Text>().text = txt + dropMsg;

        resourceController.name = container.GetComponent<UnityEngine.UI.Text>().text;


    }

    void delClick()
    {
        string txt = container.GetComponent<UnityEngine.UI.Text>().text;
        string new_txt = "";

        for (int x = 0; x < txt.Length; x++)
        {
            new_txt += txt[x];
            if (txt[x] == '{')
            {
                break;
            }
        }
        container.GetComponent<UnityEngine.UI.Text>().text = new_txt + " ";

        resourceController.name = container.GetComponent<UnityEngine.UI.Text>().text;

        go_del.SetActive(false);
        go_drop.SetActive(true);
        go_add.SetActive(true);
    }

    void delcontClick()
    {
        resourceController.deleteClick();
    }
}
