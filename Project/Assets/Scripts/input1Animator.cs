using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class input1Animator : MonoBehaviour
{
    public Button next1;
    public Button next;
    public Animator anim;
    public Animator anim1;
    public Animator anim2;
    public GameObject desc;

    void Start()
    {
        next.onClick.AddListener(nextClick);
        next1.onClick.AddListener(nextClick1);
    }

    void nextClick()
    {
        anim.SetTrigger("input1FadeIn");
        anim1.SetTrigger("Input2FadeIn");
        anim2.SetTrigger("inputFadeIn");
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
        anim.SetTrigger("Input1FadeOut");
    }

}
