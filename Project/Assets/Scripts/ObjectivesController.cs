using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesController : MonoBehaviour
{
    public Button obj;

    public LevelCounter lc;
    public Text txt;
    public Text lvlTxt;

    void Start()
    {
        lc = GameObject.Find("TopCanvas").GetComponent<LevelCounter>();
        int counter = lc.getLevel();
        lvlTxt.text = "Level " + counter.ToString() + ":";

        if(counter == 1)
        {
            txt.text =
                "- Define a Resource which enforces that a file titled 'data.txt' exists in the '/data' folder and is owned by the user 'guest'.\n\n" +
                "- Make sure to check the given sample code for reference!\n\n";
        }
        else if(counter == 2)
        {
            txt.text =
                "- Ensure that a file log.txt exists in the ‘/data’ folder, is owned by ‘root’ and has a mode of 0666.\n\n" +
                "- Make sure that there is no ‘guest’ user present in our system.\n\n" +
                "- Ensure that a user ‘alice’ is present with a user ID 1, with shell access to the shell at ‘/bin/bash’ and its home directory set to ‘/alice’.\n\n";
                
        }
        else if(counter == 3)
        {
            txt.text =
                "- Create and invoke a class titled alice.\n\n" +
                "When the class alice is invoked:\n" +
                "- a user ‘alice’ with uid 1 and a home directory ‘/disk/users/alice’ must be created.\n\n" +
                "- ‘/disk/users/alice’ must be ensured to be a directory.\n\n" +
                "Note: Make use of the $dir variable when setting the home directories and resource names.\n\n";

        }
        else if(counter == 4)
        {
            txt.text =
                "- Create and invoke a class ‘apache’.\n\n\n" +
                "Within the class:\n" +
                "- Execute the command ‘apt-get update’ as the user ‘root’ from the folder ‘/usr/bin’. The command must be in a resource named ‘apt-get-update’.\n\n" +
                "- Ensure that the latest version of the package ‘apache2’ is installed.\n\n" +
                "- Ensure that the ‘apache2’ service is enabled and running.\n\n" +
                "- Ensure that the file ‘/etc/version’ is a file and not a directory, with its mode set to 0600 and owned be ‘root. The content of the file must contain " +
                "the version of the apache2 package being used.\n\n" +
                "Note: When specifying the version of ‘apache2’ in any context, make use of the variable $version. When using a variable as a part of a text/string entry, remember " +
                "surround the variable in quotation marks (\"\")\n\n";

        }
        else if(counter == 5)
        {
            txt.text =
                "- Create a parametrized class delete_user with its parameters $user and $dir set to ‘default’.\n\n\n"+
                "Within the class:\n"+
                "- The user specified in the class parameters must not be present on the system.\n\n"+
                "- The directory /users/alice must not exist. Make use of the class parameters when specifying the directory path.\n\n\n"+
                "- Invoke the class ‘delete_user’ and set the $user parameter to ‘alice’ and $dir parameter to ‘/users’.\n\n";

        }
        else if(counter == 6)
        {
            txt.text =
                "- Create a parametrized class openssh with the default value of $version set to latest and a non-parametrized class nginx.\n\n\n" +

                "Within class nginx:\n" +
                "- The ‘apache2.2’ package must not be installed.\n\n" +
                "- The ‘nginx’ package must be installed. It can only be installed if the ‘apache2.2’ package not installed.\n\n" +
                "- The ‘nginx’ service must be running. The ‘nginx’ package must be installed beforehand.\n\n\n" +

                "Within class openssh :\n" +
                "- The package ‘openssh-server’ must be of version specified by the class parameters.\n\n" +
                "- The ‘sshd’ service must be running and enabled, but only after the ‘openssh-server’ package is installed.\n\n" +
                "- ‘/etc/ssh’ must be a directory with mode 0600, owned by root. It can only be created after the ‘openssh-server’ package is installed.\n\n" +
                "- The command ‘mkdir backup’ must be executed from the ‘/etc/ssh’ folder and can only be executed after the directory ‘/etc/ssh’ has been confirmed to exist.\n\n" +
                "The resource name of the resource executing the command 'mkdir backup' must be set to ‘mkdir_backup’.\n\n\n" +

                "- Invoke classes nginx and openssh with an appropriate method. When invoking openssh, set the version value to ‘7.3’.\n\n";

        }
    }

    
}
