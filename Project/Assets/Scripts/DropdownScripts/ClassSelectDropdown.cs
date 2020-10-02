using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassSelectDropdown : MonoBehaviour
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
            drop.AddOptions(new List<string> { "root", "bob", "sys", "alice" });
        }
        else if (counter == 4)
        {
            drop.AddOptions(new List<string> {  "alice", "openssh", "apache", "apt-get" });
        }
        else if (counter == 5)
        {
            drop.AddOptions(new List<string> { "users", "delete_user" });
        }
        else if (counter == 6)
        {
            drop.AddOptions(new List<string> { "apache", "openssh", "nginx" });
        }
    }
}
