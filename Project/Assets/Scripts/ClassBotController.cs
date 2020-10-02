using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassBotController : MonoBehaviour
{
    public Button del;
    public GameObject container;

    public ClassController classController;


    void Start()
    {
        del.onClick.AddListener(delClick);
        classController = container.transform.parent.GetComponent<ClassController>();
    }

    void delClick()
    {
        classController.del();
    }
}
