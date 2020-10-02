using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotController : MonoBehaviour
{
    public Button del;
    public GameObject container;

    public ResourceController resourceController;


    void Start()
    {
        del.onClick.AddListener(delClick);
        resourceController = container.transform.parent.GetComponent<ResourceController>();
    }

    void delClick()
    {
        resourceController.deleteClick();
    }
}
