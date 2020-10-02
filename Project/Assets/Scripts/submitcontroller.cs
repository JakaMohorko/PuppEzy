using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class submitcontroller : MonoBehaviour
{
    public Button expand;
    public Button collapse;

    public GameObject text;
    public Button close;

    void Start()
    {
        expand.onClick.AddListener(expandClick);
        collapse.onClick.AddListener(collapseClick);
        close.onClick.AddListener(collapseClick);

        collapse.gameObject.SetActive(false);
        text.SetActive(false);
    }

    void expandClick()
    {
        expand.gameObject.SetActive(false);
        collapse.gameObject.SetActive(true);
        text.SetActive(true);
    }
    void collapseClick()
    {
        expand.gameObject.SetActive(true);
        collapse.gameObject.SetActive(false);
        text.SetActive(false);
    }

}
