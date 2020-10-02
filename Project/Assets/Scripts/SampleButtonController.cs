using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleButtonController : MonoBehaviour
{
    public GameObject textWindow1;
    public GameObject textWindow2;
    public GameObject textWindow3;

    public Button button1;
    public Button button2;
    public Button button3;

    // Start is called before the first frame update
    void Start()
    {
        textWindow1.SetActive(true);
        textWindow2.SetActive(false);
        textWindow3.SetActive(false);

        button1.onClick.AddListener(btn1click);
        button2.onClick.AddListener(btn2click);
        button3.onClick.AddListener(btn3click);

    }

    // Update is called once per frame
    void btn1click()
    {
        textWindow1.SetActive(true);
        textWindow2.SetActive(false);
        textWindow3.SetActive(false);
    }

    void btn2click()
    {
        textWindow1.SetActive(false);
        textWindow2.SetActive(true);
        textWindow3.SetActive(false);
    }
    void btn3click()
    {
        textWindow1.SetActive(false);
        textWindow2.SetActive(false);
        textWindow3.SetActive(true);
    }
}
