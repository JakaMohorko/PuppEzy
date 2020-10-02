using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceTopSelectDropdown : MonoBehaviour
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
            drop.AddOptions(new List<string> { "'/data/log.txt':", "\'guest\':", "\'/data/data.txt':" });
        }
        else if (counter == 2)
        {
            drop.AddOptions(new List<string> { "\'/data/log.txt':", "\'guest':", "\'/data/users.txt':", "\'sys\':", "\'bob\':", "\'alice\':" , "\'root\':" });
        }
        else if (counter == 3)
        {
            drop.AddOptions(new List<string> { "$dir:", "\'root\':", "\'guest\':", "'alice':", "\"$dir/alice\":", "\'$dir/alice\':" });
        }
        else if (counter == 4)
        {
            drop.AddOptions(new List<string> { "'apt-get-update':", "'openssh-server':", "'sshd':", "'apache2':", "'/etc/version':" });
        }
        else if (counter == 5)
        {
            drop.AddOptions(new List<string> { "$user:", "'$dir/$user':", "\"$dir/$user\":" });
        }
        else if (counter == 6)
        {
            drop.AddOptions(new List<string> { "'apache2.2':", "'nginx':",  "'sshd':", "'mkdir_backup':", "'openssh-server':", "'/etc/ssh':"  });
        }
    }
}
