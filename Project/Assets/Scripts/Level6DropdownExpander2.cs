using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level6DropdownExpander2 : MonoBehaviour
{
    public GameObject template;
    void Start()
    {

        LevelCounter lc = GameObject.Find("TopCanvas").GetComponent<LevelCounter>();

        if (lc.getLevel() == 6 || lc.getLevel() == 4)
        {
            RectTransform rt = template.GetComponent<RectTransform>();

            rt.offsetMin = new Vector2(-15, -150);
            rt.offsetMax = new Vector2(15, 2);
        }
        
    }
}
