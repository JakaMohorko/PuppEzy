using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeSelectClassDropdown : MonoBehaviour
{

    LevelCounter lc;
    public Dropdown drop;

    void Start()
    {
        lc = GameObject.Find("TopCanvas").GetComponent<LevelCounter>();

        int counter = lc.getLevel();
        drop.ClearOptions();


        if (counter == 1)
        {
            drop.AddOptions(new List<string> { "Resource" });
        }
        else if (counter == 2)
        {
            drop.AddOptions(new List<string> { "Resource" });
        }
        else if (counter == 3)
        {
            drop.AddOptions(new List<string> { "Resource", "Variable" });
        }
        else if (counter == 4)
        {
            drop.AddOptions(new List<string> { "Resource", "Variable" });
        }
        else if (counter == 5)
        {
            drop.AddOptions(new List<string> { "Resource"});
        }
        
        else if (counter == 6)
        {
            drop.AddOptions(new List<string> { "Resource"});
        }
    }
}
