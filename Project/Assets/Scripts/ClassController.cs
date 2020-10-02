using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassController : MonoBehaviour
{
    

    public GameObject container;


    public string name;
    public List<GameObject> classResources;
    public List<GameObject> classVariables;
    public List<GameObject> classParams;

    public SolutionAnalyzer solutionAnalyzer;


    void Start()
    {

        classResources = new List<GameObject>();
        classVariables = new List<GameObject>();
        classParams = new List<GameObject>();

        solutionAnalyzer = GameObject.Find("rhsPanel").GetComponent<SolutionAnalyzer>();

        solutionAnalyzer.classes.Add(container);
        

    }

    public void del()
    {
        solutionAnalyzer.classes.Remove(container);
        DestroyImmediate(container);
    }


}
