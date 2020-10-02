using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VarSelectDropdownRight : MonoBehaviour
{
    public Dropdown drop;
    LevelCounter lc;

    void Start()
    {
        lc = GameObject.Find("TopCanvas").GetComponent<LevelCounter>();

        int counter = lc.getLevel();
        drop.ClearOptions();

        if (counter == 1)
        {
            drop.AddOptions(new List<string> { "" });
        }
        else if (counter == 2)
        {
            drop.AddOptions(new List<string> { "" });
        }
        else if (counter == 3)
        {
            drop.AddOptions(new List<string> { "'/disk/users'", "'/data/users'" });
        }
        else if (counter == 4)
        {
            drop.AddOptions(new List<string> { "2.6.1", "latest", "default" });
        }
        else if (counter == 5)
        {
            drop.AddOptions(new List<string> { "'bob'", "'alice'", "'default'", "/users", "'/users'" });
        }
        else if (counter == 6)
        {
            drop.AddOptions(new List<string> { "'2.4'", "'7.3'", "latest"});
        }
    }
}
