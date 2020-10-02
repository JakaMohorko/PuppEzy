using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReferenceResourceController : MonoBehaviour
{
    public GameObject container;

    public Button expandTop;
    public Button collapseTop;

    public GameObject go_expandTop;
    public GameObject go_collapseTop;

    public Button expandAttr;
    public Button collapseAttr;

    public GameObject go_expandAttr;
    public GameObject go_collapseAttr;

    public GameObject attrs;
    public GameObject expl;

    public GameObject attrs_inner;

    void Start()
    {
        expandTop.onClick.AddListener(expandTopClick);
        collapseTop.onClick.AddListener(collapseTopClick);

        expandAttr.onClick.AddListener(expandAttrClick);
        collapseAttr.onClick.AddListener(collapseAttrClick);

        attrs.SetActive(false);
        expl.SetActive(false);
        go_collapseTop.SetActive(false);
        go_collapseAttr.SetActive(false);

    }


    void expandTopClick()
    {
        expl.SetActive(true);
        attrs.SetActive(true);
        attrs_inner.SetActive(false);

        go_expandTop.SetActive(false);
        go_collapseTop.SetActive(true);
    }

    void collapseTopClick()
    {
        attrs_inner.SetActive(false);
        expl.SetActive(false);
        attrs.SetActive(false);

        go_expandTop.SetActive(true);
        go_collapseTop.SetActive(false);

        go_collapseAttr.SetActive(false);
        go_expandAttr.SetActive(true);
    }

    void expandAttrClick()
    {
        go_collapseAttr.SetActive(true);
        go_expandAttr.SetActive(false);
        attrs_inner.SetActive(true);
    }

    void collapseAttrClick()
    {
        attrs_inner.SetActive(false);
        go_collapseAttr.SetActive(false);
        go_expandAttr.SetActive(true);
        
    }
}
