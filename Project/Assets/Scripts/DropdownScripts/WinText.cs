using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinText : MonoBehaviour
{

    public Text txt;
    public GameObject panel;
    string txtFull;

    private void Update()
    {
        panel.GetComponent<ScrollRect>().verticalNormalizedPosition = 0;
    }

    public void startDisplay()
    {
        StartCoroutine(display());
    }

    IEnumerator display()
    {
        LevelCounter lc = GameObject.Find("TopCanvas").GetComponent<LevelCounter>();
        int level = lc.getLevel();

        if (level == 1)
        {
            txtFull =
                "Locating file /data/data.txt . . . file not found\n\n" +
                "Creating file /data/data.txt . . . success\n\n" +
                "Setting file /data/data.txt owner to 'guest' . . . success\n\n" +
                "Configuration successful!\n\n\n" +
                "Press Next Level to continue . . .";
        }
        else if (level == 2)
        {
            txtFull =
                "Users present on system: 'guest'\n\n"+
                "Deleting user 'guest' . . . success\n\n"+
                "Creating user 'alice' . . . success\n\n"+
                "Configuring user 'alice' . . . success\n\n" +
                "Locating file '/data/log.txt' . . . file found\n\n"+
                "Configuring file '/data/log.txt' . . . success\n\n"+
                 "Configuration successful!\n\n\n" +
                "Press Next Level to continue . . .";
        }
        else if (level == 3)
        {
            txtFull = 
                "Users present on system: \n\n"+
                "Creating user 'alice' . . . success\n\n"+
                "Configuring user 'alice' . . . success\n\n"+
                "Locating directory '/disk/users/alice . . . directory not found\n\n"+
                "Creating directory '/disk/users/alice . . . success\n\n"+
                "Configuration Successful!\n\n\n"+
                "Press Next Level to continue . . .";
        }
        else if(level == 4)
        {
            txtFull =
                "Executing command 'apt-get update' . . . . . success\n\n" +
                "Locating package 'apache2' . . . not found\n\n" +
                "Installing package 'apache2' version latest . . . success\n\n" +
                "Starting service 'apache2' . . . success\n\n" +
                "Configuring service 'apache2' . . . success\n\n" +
                "Locating file '/etc/version' . . . file found\n\n" +
                "Configuring file '/etc/version . . . success\n\n" +
                "Configuration Successful!\n\n\n" +
                "Press Next Level to continue . . .";
        }
        else if(level == 5)
        {
            txtFull =
                "Users present on system: 'alice'\n\n"+
                "Deleting user 'alice' . . . success\n\n" +
                "Locating '/users/alice' . . . directory found\n\n" +
                "Deleting directory '/users/alice' . . . success\n\n" +
                "Configuration Successful!\n\n\n"+
                "Press Next Level to continue . . .";
        }
        else if(level == 6)
        {
            txtFull =
                "Locating package 'apache2.2' . . . package found\n\n" +
                "Deleting package 'apache2.2' . . . success\n\n" +
                "Locating package 'nginx' . . . not found\n\n" +
                "Installing package 'nginx' . . . success\n\n" +
                "Starting service 'nginx' . . . success\n\n" +
                "Configuring service 'nginx' . . . success\n\n" +
                "Locating package 'openssh-server' version '7.3' . . . found version '7.2'\n\n" +
                "Installing package 'openssh-server' version 7.3 . . . success\n\n" +
                "Locating directory '/etc/ssh' . . . not found\n\n" +
                "Creating directory '/etc/ssh' . . . success\n\n" +
                "Configuring directory '/etc/ssh' . . . success\n\n" +
                "Starting service 'sshd' . . . success\n\n" +
                "Configuring service 'sshd' . . . success\n\n" +
                "Executing command 'mkdir backup' . . . success\n\n" +
                "Configuration Successful!\n\n\n" +
                "Press Next Level to continue . . .";

        }
        txt.text = "";
        for (int x = 0; x < txtFull.Length; x++)
        {

            txt.text = txt.text + txtFull[x];
            if (txtFull[x] == '.' && txtFull[x-1] == ' ')
            {
                yield return new WaitForSecondsRealtime((float)0.5);
            }
            else if(txtFull[x] == '\n')
            {
                yield return new WaitForSecondsRealtime((float)0.02);
            }
            else
            {
                yield return new WaitForSecondsRealtime((float)0.015);
            }

        }
    }

}
