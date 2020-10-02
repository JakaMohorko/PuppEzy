using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReferenceController : MonoBehaviour
{
    public Button manifestsOpen;
    public Button manifestsClose;
    public Button resourcesOpen;
    public Button resourcesClose;
    public Button classesOpen;
    public Button classesClose;

    public Button variablesOpen;
    public Button variablesClose;

    public Button orderOpen;
    public Button orderClose;

    public GameObject res;

    public GameObject man;
    public GameObject cla;

    public GameObject ctrl;
    public GameObject var;

    void Start()
    {
        manifestsOpen.onClick.AddListener(manifestsOpenClick);
        manifestsClose.onClick.AddListener(manifestsCloseClick);
        resourcesOpen.onClick.AddListener(resourcesOpenClick);
        resourcesClose.onClick.AddListener(resourcesCloseClick);
        classesOpen.onClick.AddListener(classesOpenClick);
        classesClose.onClick.AddListener(classesCloseClick);
        orderOpen.onClick.AddListener(orderOpenClick);
        orderClose.onClick.AddListener(orderCloseClick);
        variablesOpen.onClick.AddListener(variablesOpenClick);
        variablesClose.onClick.AddListener(variablesCloseClick);

        res.SetActive(false);
        man.SetActive(false);
        cla.SetActive(false);
        var.SetActive(false);
        ctrl.SetActive(false);

        manifestsClose.gameObject.SetActive(false);
        resourcesClose.gameObject.SetActive(false);
        classesClose.gameObject.SetActive(false);
        variablesClose.gameObject.SetActive(false);
        orderClose.gameObject.SetActive(false);
    }

    void manifestsOpenClick()
    {
        man.SetActive(true);
        manifestsClose.gameObject.SetActive(true);
        manifestsOpen.gameObject.SetActive(false);
    }

    void manifestsCloseClick()
    {
        man.SetActive(false);
        manifestsOpen.gameObject.SetActive(true);
        manifestsClose.gameObject.SetActive(false);
    }

    void resourcesOpenClick()
    {
        res.SetActive(true);
        resourcesClose.gameObject.SetActive(true);
        resourcesOpen.gameObject.SetActive(false);
    }

    void resourcesCloseClick()
    {
        res.SetActive(false);
        resourcesClose.gameObject.SetActive(false);
        resourcesOpen.gameObject.SetActive(true);

    }

    void classesOpenClick()
    {
        cla.SetActive(true);
        classesClose.gameObject.SetActive(true);
        classesOpen.gameObject.SetActive(false);
    }

    void classesCloseClick()
    {
        cla.SetActive(false);
        classesClose.gameObject.SetActive(false);
        classesOpen.gameObject.SetActive(true);

    }

    void orderOpenClick()
    {
        ctrl.SetActive(true);
        orderClose.gameObject.SetActive(true);
        orderOpen.gameObject.SetActive(false);
    }

    void orderCloseClick()
    {
        ctrl.SetActive(false);
        orderClose.gameObject.SetActive(false);
        orderOpen.gameObject.SetActive(true);

    }

    void variablesOpenClick()
    {
        var.SetActive(true);
        variablesClose.gameObject.SetActive(true);
        variablesOpen.gameObject.SetActive(false);
    }

    void variablesCloseClick()
    {
        var.SetActive(false);
        variablesClose.gameObject.SetActive(false);
        variablesOpen.gameObject.SetActive(true);

    }

}
