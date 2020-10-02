using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceMidSelectDropdownRight : MonoBehaviour
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
            drop.AddOptions(new List<string> { "present", "\'root\'", "\'guest\'", "3", "5" });
        }
        else if (counter == 2)
        {
            drop.AddOptions(new List<string> { "present", "absent",  "\'sys\'", "\'/bin/bash\'", "\'/root\'", "directory", "1", "'0666'", "'root'", "'/alice'"});
        }
        else if (counter == 3)
        {
            drop.AddOptions(new List<string> { "present", "absent", "1", "0", "\"$dir/alice\"", "'$dir/alice'", "directory", "'/bin/bash'", "alice", "root" });
        }
        else if (counter == 4)
        {
            drop.AddOptions(new List<string> { "present", "file", "'0600'", "'root'", "'guest'", "'apt-get update'", "'/usr/bin'", "$version", "\"$version\"", "running", "true" });
        }
        else if (counter == 5)
        {
            drop.AddOptions(new List<string> { "present", "absent", "'root'", "'alice'" });
        }
        else if (counter == 6)
        {
            drop.AddOptions(new List<string> { "present", "absent", "directory", "running", "true", "installed", "$version", "'0600'", "'root'",
                "'/etc/ssh'", "'mkdir backup'", "File['/etc/ssh']", "Package['apache2.2']", "Package['nginx']", "Package['openssh-server']" });
            
        }
    }
}
