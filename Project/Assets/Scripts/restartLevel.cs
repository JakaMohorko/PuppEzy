using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class restartLevel : MonoBehaviour
{
    public Button restart;


    void Start()
    {
        restart.onClick.AddListener(restartClick);
    }

    void restartClick()
    {

        SceneManager.LoadScene("LevelIntro");
    }
}
