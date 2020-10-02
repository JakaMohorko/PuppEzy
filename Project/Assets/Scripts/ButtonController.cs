using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button objOpen;
    public Button objClose;
    public GameObject objContainer;

    public Button refOpen;
    public Button refClose;
    public GameObject refContainer;

    void Start()
    {
        objOpen.onClick.AddListener(objOpenClick);
        objClose.onClick.AddListener(objCloseClick);
        objContainer.SetActive(true);

        refOpen.onClick.AddListener(refOpenClick);
        refClose.onClick.AddListener(refCloseClick);
        refContainer.SetActive(false);
    }
    
    void objOpenClick()
    {
        objContainer.SetActive(true);
    }

    void objCloseClick()
    {
        objContainer.SetActive(false);
    }

    void refOpenClick()
    {
        refContainer.SetActive(true);
    }

    void refCloseClick()
    {
        refContainer.SetActive(false);
    }
}
