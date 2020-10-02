using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnowledgeBaseLevelHide : MonoBehaviour
{
    LevelCounter lc;

    public GameObject order;
    public GameObject vars;
    public GameObject classes;

    public GameObject group;
    public GameObject service;
    public GameObject exec;
    public GameObject package;

    public GameObject reslike;
    public GameObject param;


    public GameObject content;
    public GameObject groupattr;
    public GameObject mode;
    public GameObject groups;
    public GameObject gid;
    public GameObject shell;
    public GameObject home;

    void Start()
    {
        lc = GameObject.Find("TopCanvas").GetComponent<LevelCounter>();

        int counter = lc.getLevel();
        


        if (counter == 1)
        {
            order.SetActive(false);
            vars.SetActive(false);
            classes.SetActive(false);
            service.SetActive(false);
            exec.SetActive(false);
            package.SetActive(false);
            group.SetActive(false);

            content.SetActive(false);
            groupattr.SetActive(false);
            mode.SetActive(false);
            groups.SetActive(false);
            gid.SetActive(false);
            shell.SetActive(false);
            home.SetActive(false);
        }
        else if (counter == 2)
        {
            order.SetActive(false);
            vars.SetActive(false);
            classes.SetActive(false);
            service.SetActive(false);
            exec.SetActive(false);
            package.SetActive(false);
        }
        else if (counter == 3)
        {
            order.SetActive(false);
            service.SetActive(false);
            exec.SetActive(false);
            package.SetActive(false);
            reslike.SetActive(false);
            param.SetActive(false);
        }
        else if (counter == 4)
        {
            order.SetActive(false);
            reslike.SetActive(false);
            param.SetActive(false);
        }
        else if (counter == 5)
        {
            order.SetActive(false);
        }

        else if (counter == 6)
        {
            
        }
    }

    
}
