using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closecontainer : MonoBehaviour
{

    public GameObject container;
    public Button close;
    public Button exit;
    public GameObject win;

    void Start()
    {
        close.onClick.AddListener(closeClick);
        exit.onClick.AddListener(exitClick);
    }

    void closeClick()
    {
        container.SetActive(false);
        win.SetActive(false);
    }

    void exitClick()
    {
        Application.Quit();
    }
}
