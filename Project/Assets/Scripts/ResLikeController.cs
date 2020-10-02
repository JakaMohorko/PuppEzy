using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResLikeController : MonoBehaviour
{


    public GameObject container;


    public string name;
    public List<GameObject> classParams;

    public SolutionAnalyzer solutionAnalyzer;


    void Start()
    {

        classParams = new List<GameObject>();

        solutionAnalyzer = GameObject.Find("rhsPanel").GetComponent<SolutionAnalyzer>();

        solutionAnalyzer.resLike.Add(container);

    }

    public void del()
    {
        solutionAnalyzer.resLike.Remove(container);
        DestroyImmediate(container);
    }


}
