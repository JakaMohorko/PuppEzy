using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public Button next;
    LevelCounter lc;
    public GameObject final;

    void Start()
    {
        lc = GameObject.Find("TopCanvas").GetComponent<LevelCounter>();
        next.onClick.AddListener(nextClick);
    }

   void nextClick()
    {
        if(lc.getLevel() != 6)
        {
            lc.incrementLevel();
            SceneManager.LoadScene("LevelIntro");
        }
        else
        {
            FinalScreen fs = final.GetComponent<FinalScreen>();
            final.SetActive(true);
            fs.startDisplay();
        }
    }
}
