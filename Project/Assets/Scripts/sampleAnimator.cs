using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sampleAnimator : MonoBehaviour
{
    public Button next1;
    public Button next;
    public Animator anim;
    public GameObject uidesc;
    public GameObject sampledesc;

    void Start()
    {
        next.onClick.AddListener(nextClick);
        next1.onClick.AddListener(nextClick1);
    }

    void nextClick()
    {
        uidesc.SetActive(false);
        sampledesc.SetActive(true);
        anim.SetTrigger("SampleFadeIn");
    }

    void nextClick1()
    {
        sampledesc.SetActive(false);
        StartCoroutine(ExecuteAfterTime((float)0.5));
        
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        anim.SetTrigger("SampleFadeOut");
    }

}
