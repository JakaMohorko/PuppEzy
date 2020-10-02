using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class buttonAnimator : MonoBehaviour
{
    public Button next1;
    public Button next;
    public Button nextscene;
    public Animator anim;
    public GameObject desc;
    public GameObject desc2;

    void Start()
    {
        next.onClick.AddListener(nextClick);
        next1.onClick.AddListener(nextClick1);
        nextscene.onClick.AddListener(nextsceneClick);
    }

    void nextClick()
    {

        desc.SetActive(true);
        anim.SetTrigger("ButtonsFadeIn");
    }

    void nextClick1()
    {
        desc2.SetActive(true);
        desc.SetActive(false);
        anim.SetTrigger("ButtonsFadeOut");
    }

    void nextsceneClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
