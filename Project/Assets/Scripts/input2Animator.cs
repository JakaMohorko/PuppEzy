using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class input2Animator : MonoBehaviour
{
    public Button next1;
    public Button next;
    public Animator anim;
    
    public GameObject desc;

    void Start()
    {
        next.onClick.AddListener(nextClick);
        next1.onClick.AddListener(nextClick1);
    }

    void nextClick()
    {

        desc.SetActive(true);
        
    }

    void nextClick1()
    {
        desc.SetActive(false);
        StartCoroutine(ExecuteAfterTime((float)0.5));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        anim.SetTrigger("Input2FadeOut");
    }

}
