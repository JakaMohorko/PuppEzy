using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level6DropdownExpander : MonoBehaviour
{
    public GameObject template;
    void Start()
    {

        LevelCounter lc = GameObject.Find("TopCanvas").GetComponent<LevelCounter>();

        if(lc.getLevel() == 6)
        {
            RectTransform rt = template.GetComponent<RectTransform>();

            rt.offsetMin = new Vector2(-50, -150);
            rt.offsetMax = new Vector2(50, 2);
        }

        if (lc.getLevel() == 2 ||lc.getLevel() == 3 )
        {
            RectTransform rt = template.GetComponent<RectTransform>();

            rt.offsetMin = new Vector2(-5, -150);
            rt.offsetMax = new Vector2(5, 2);
        }

        if(lc.getLevel() == 4)
        {
            RectTransform rt = template.GetComponent<RectTransform>();

            rt.offsetMin = new Vector2(-20, -150);
            rt.offsetMax = new Vector2(20, 2);
        }
    }
}
