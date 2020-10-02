using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KBClassesController : MonoBehaviour
{
    public Button open;
    public Button close;

    public GameObject go_open;
    public GameObject go_close;
    public GameObject content;

    void Start()
    {
        content.SetActive(false);
        open.onClick.AddListener(openClick);
        close.onClick.AddListener(closeClick);
    }

    void openClick()
    {
        content.SetActive(true);
        go_open.SetActive(false);
        go_close.SetActive(true);
    }

    void closeClick()
    {
        content.SetActive(false);
        go_open.SetActive(true);
        go_close.SetActive(false);
    }
}
