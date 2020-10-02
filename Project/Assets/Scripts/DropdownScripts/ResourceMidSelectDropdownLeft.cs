using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceMidSelectDropdownLeft : MonoBehaviour
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
            drop.AddOptions(new List<string> { "ensure", "uid", "owner" });
        }
        else if (counter == 2)
        {
            drop.AddOptions(new List<string> { "ensure", "groups", "uid", "gid", "shell", "home", "content", "owner", "mode" });
        }
        else if (counter == 3)
        {
            drop.AddOptions(new List<string> { "ensure", "groups", "uid", "gid", "shell", "home", "content", "owner", "mode" });
        }
        else if (counter == 4)
        {
            drop.AddOptions(new List<string> { "ensure", "groups", "content", "owner", "mode", "enable", "cwd", "command", "user" });
        }
        else if (counter == 5)
        {
            drop.AddOptions(new List<string> { "ensure", "groups", "content", "owner", "mode", "enable" });
        }
        else if (counter == 6)
        {
            drop.AddOptions(new List<string> { "ensure", "require", "owner", "mode", "cwd", "command", "enable" });
        }
    }
}
