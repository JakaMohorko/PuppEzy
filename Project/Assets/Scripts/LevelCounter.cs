using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCounter : MonoBehaviour
{
    private static int levelCounter = 1;

    public int getLevel()
    {
        return levelCounter;
    }
    public void incrementLevel()
    {
        levelCounter++;
    }
    public void decrementLevel()
    {
        levelCounter--;
    }

}
