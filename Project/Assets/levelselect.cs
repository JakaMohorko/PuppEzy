using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelselect : MonoBehaviour
{
    public Button btn;
    public GameObject final;


    void Start()
    {
        btn.onClick.AddListener(click);
    }

    void click()
    {
        LevelCounter lc = GameObject.Find("TopCanvas").GetComponent<LevelCounter>();
        if (lc.getLevel() != 6)
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
