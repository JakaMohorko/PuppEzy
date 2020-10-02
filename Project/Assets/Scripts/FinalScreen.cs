using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScreen : MonoBehaviour
{
    public Text txt1;
    public Text txt2;
    string txtFull;


    void Start()
    {

        txt2.gameObject.SetActive(false);
       
       
    }
    public void startDisplay()
    {
        txt1.gameObject.SetActive(true);
        StartCoroutine(display1());
    }
    

    IEnumerator display1()
    {
        txtFull = string.Copy(txt1.text);
        txt1.text = "";
        
        for (int x = 0; x < txtFull.Length; x++)
        {

            txt1.text = txt1.text + txtFull[x];

            yield return new WaitForSecondsRealtime((float)0.008);

        }
        StartCoroutine(display2());
    }

    IEnumerator display2()
    {
        txtFull = string.Copy(txt2.text);
        txt2.text = "";
        txt2.gameObject.SetActive(true);
        for (int x = 0; x < txtFull.Length; x++)
        {

            txt2.text = txt2.text + txtFull[x];

            yield return new WaitForSecondsRealtime((float)0.015);

        }
    }

}

