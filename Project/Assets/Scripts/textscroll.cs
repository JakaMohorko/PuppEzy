using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class textscroll : MonoBehaviour
{
    List<string> txtFull;
    string txtCurrent;
    
    int counter;
    int clickCounter;
    int oldcounter;
    int pages;

    public Button cont;
    public Text txt;
    public Text btnTxt;

    bool running;

    Coroutine current;
    LevelCounter lc;
    int currentLvl;

    void Start()
    {
        cont.onClick.AddListener(scrolltext);
        counter = 0;
        oldcounter = 0;
        txtCurrent = "";
        running = false;
        
        

        lc = GameObject.Find("TopCanvas").GetComponent<LevelCounter>();
        currentLvl = lc.getLevel();

        if (currentLvl == 1)
        {
            pages = 4;

            txtFull = new List<string>
            {
                "Hello and welcome to PuppEzy - your comprehensive guide on Puppet!\nWell, not quite…\n\n"+
                "Puppet is an enormous tool that helps you, a student of system administration, configure and manage system infrastructures.\n\n"+
                "It takes the system parameters that you specify and applies them to the device you want to configure.\n\n"+
                "As we cannot possibly squeeze all aspects of puppet into this game, we will instead explore some basic concepts of the programming language used in Puppet.",

                "Puppet code is mostly composed of resource declarations which are written into Puppet program files – manifests."+
                "\nYou will soon be creating manifests of your own!"+
                "\n\nA resource declaration describes a part of the system, such as whether a file should exist or if a user should be present in a system."+
                "\n\nThe Puppet configuration management tool looks at the manifests and configures the system state of desired devices according to what’s written in the manifests.",

                "Resource declarations have a type, eg. user, a name such as ‘peter’ and attributes with their values. They’re formatted like this:\n\n"+
                "type { ‘name’:\n"+
                "\tattribute => value,\n"+
                "\t...\n"+
                "}\n\n"+
                "with an example of a file declaration:\n\n"+
                "file { ‘/data/log.txt’:\n"+
                "\tensure => present,\n"+
                "\towner => root\n"+
                "}",

                "For now, we will be using the following resource types and some of their attributes:\n\n"+
                "file attributes: ensure, owner\n"+
                "user attributes: ensure, uid\n\n"+
                "A description of the workings of each attribute is available within each level."
            };
        }
        else if (currentLvl == 2)
        {
            pages = 3;

            txtFull = new List<string>
            {
                "Nicely done!\n\n"+
                "However, you are still but a young apprentice dipping your toes into a vast ocean of utility, possibilities and confusion offered by Puppet.",

                "Within the next level we are introducing a few new resource types and their attributes and values:\n\n"+
                "Types: group\n\n"+
                "user attributes:  groups, gid, uid, shell, home\n"+
                "file attributes: content, group, mode\n"+
                "group attributes: ensure, gid\n\n\n"+
                "Check the knowledge base in each level to review the new additions!",

                "Oh, and also!\n\n"+
                "Don’t worry about the order of your resources. Puppet is a declarative language where the order of resources (and later classes) does not matter (until it does).\n\n"+
                "Within this game, as long as your components like resources and classes have the correct contents, the solution will be correct."


            };
        }
        else if (currentLvl == 3)
        {
            pages = 5;

            txtFull = new List<string>
            {
                "We’ve got resources down in no time!\n\n"+
                "Time to introduce two new features – classes and variables.\n\n",

                "Variables are storage units that store values so they can be accessed later. In Puppet, variables can’t be reassigned and must be defined before they're used.\n " +
                "Although they can be defined outside of classes, within the scope of our game, you will only be able to define them only in classes.\n\n"+
                "Variables are templated as follows:\n\n"+
                "\t$variable_name = value\n\n",

                "You can then use the variable as a replacement for a value in an attribute value pair or a name of a resource.\n\n"+
                "Example:\n"+
                "\t$user => ‘alice’\n"+
                "\tfile { “/data/$user”\n"+
                "\t\towner => $user\n"+
                "\t}\n\n"+
                "Note: If you want to use the text stored in a variable as a part of a text entry for any value, the text containing the variable must be " +
                "enclosed in quotation marks(“) as opposed to single apostrophes(‘) - eg. \"/data/$user\".",

                "Classes are named blocks that are stored for later use and are applied once invoked by name – for now we will be using the command include for that.\n"+
                "Classes are templated as follows:\n"+
                "\tclass name\n"+
                "\t{\n"+
                "\t\t$variable_name = value\n"+
                "\t\tres { 'resource1':\n"+
                "\t\t\tattr => value,\n"+
                "\t\t\t...\n"+
                "\t\t}\n"+
                "\t\tres { 'resource2:\n"+
                "\t\t\tattr => value\n"+
                "\t\t\t...\n"+
                "\t\t}\n"+
                "\t\t...\n"+
                "\t}\n\n",

                "You can then invoke a class by adding a line\n\n"+
                "\tinclude class_name\n\n"+
                "within your puppet program.\n\n\n"+
                "Good luck!"
            };
        }
        else if (currentLvl == 4)
        {
            pages = 4;

            txtFull = new List<string>
            {
                "Dealing only with files, groups and users has become quite stale, don’t you think?\n\n"+
                "It’s high time we introduced a few new resources that give us many new options.\n\n"+
                "These are:\n"+
                "exec, package and service",

                "A resource of type exec will execute any external command specified. An example of a command to run would be ‘mkdir data’ or ‘apt-get update’.\n\n"+
                "We will be using the following attributes of exec:\n\n"+
                "- command: specifies the command to execute, \n\teg. command => ‘apt-get update’\n"+
                "- cwd: specifies the directory from which to run the command, \n\teg. cwd => ‘/root/bin’\n"+
                "- user: specifies the user to run the command, \n\teg. user => ‘root’\n",


                "A resource of type package is used to manage packages. We will be looking at packages " +
                "like web servers ‘apache2’ and ‘nginx’, and ‘openssh - server’, the server component of OpenSSH listening for client SSH connections.\n\n"+
                "Attributes of package that we will be using:\n"+
                "- ensure: installed, absent, latest, text input of desired version, eg. ‘7.3’\n\n"+
                "The packages to be installed default to the name of the resource, \n\teg. package { ‘openssh - server’\n would manage the ‘openssh - server’ package.",


                "A resource of type service is used to manage running services like ‘apache’, ‘nginx’ or ‘sshd’.\n"+
                "The service we are managing once again defaults to the name of the resource.\n\n"+
                "Attributes of service that we will be using:\n"+
                "- ensure: running, stopped\n"+
                "- enable: true, false\n\n"+
                "If any of the knowledge did not stick with you, remember to check the Knowledge Base, or replay the Level Intro using the Restart Level button.\n\n"+
                "Good luck!"

            };
        }
        else if (currentLvl == 5)
        {

            pages = 4;
            txtFull = new List<string>
            {
                "Congratulations on making it this far!\n\n"+
                "With only two levels to go and two Puppet features to explore, you’re almost ready to call yourself a proper Puppet apprentice!\n\n"+
                "Within this level we explore a new way of defining and invoking classes – Parametrized Classes and Resource-Like Class Definitions.",

                "Parametrized classes have variables defined as class parameters within parenthesis before the main body of the class:\n\n"+
                "\tclass apache (\n"+
                "\t\t$version = latest,\n"+
                "\t\t…\n"+
                "\t\t)\n"+
                "\t{\n"+
                "\t\t…\n"+
                "\t}\n\n",

                "\tclass apache (\n"+
                "\t\t$version = latest,\n"+
                "\t\t…\n"+
                "\t\t)\n"+
                "\t{\n"+
                "\t\t…\n"+
                "\t}\n\n"+
                "All class parameters can be used as normal variables inside the class definition.\n"+
                "Parameters allow a class to request external data and are set based on user input when the class is declared.\n\n"+
                "If there is no user input for the parameter values, they will use the default values specified in the class definition ($version would default to latest in the example above).",



               "In order to set the values of class parameters, we invoke parametrized classes using resource-like class definitions.\n\n"+
               "A resource-like definition is a new way of invoking a class, next to using ‘include’. As the name suggests, the resource-like definitions are templated similarly to a resource:\n\n"+
	            "\tclass { ‘class_name’:\n"+
		        "\t\t$param1 => ‘value’,\n"+
		        "\t\t$param2 => ‘value’,\n"+
		        "\t\t…\n"+
	            "\t}\n\n"+
               "This allows us to write more general classes which we can customize with parameters such as versions, data paths, user names and more."

            };
        }
        else if (currentLvl == 6)
        {
            pages = 4;

            txtFull = new List<string>
            {
                "Well done!\n\n"+
                "We are now approaching the final boss – the last level.\n\n"+
                "You know almost everything necessary to solve this level, we’ll just introduce 1 last bit of Puppet.\n\n"+
                "\tExecution order control",

                "Execution order control can be an immensely confusing. As we said earlier, order of code in Puppet does most of the time not matter. " +
                "Resources and classes will be applied at an order that fits the mood of the deployment tool in Puppet.\n\n"+
                "However, we have a way of controlling that order!\n\n"+
                "Sometimes, packages or services that we are using require other things to be installed first. " +
                "There are other options in Puppet, but within the game we will be using the attribute ‘require’ to adjust the execution order.",

                "The require attribute, when present in a resource, applies the current resource after the target one.\n\n"+
                "Require follows the template of:\n"+
                "\trequire => Resource_type[‘target_resource_name’]\n\n",

                "An example of usage would be:\n"+
                "\tpackage { ‘apache2’:\n"+
                "\t\tensure => installed\n"+
                "\t}\n"+
                "\tservice { ‘apache2’:\n"+
                "\t\tensure => running,\n"+
                "\t\trequire => Package[‘apache2’]\n"+
                "\t}\n\n"+
                "The 'apache2' service requires the 'apache2' package to be installed on the system. Therefore the 'apache2' service resource can only be applied" +
                " after the 'apache2' package is verified to be installed.\n\n"+
                "Note: The Resource_type in the require value must be capitalized."
            };
    }


        running = true;
        clickCounter++;
        current = StartCoroutine(display());

    }

    void scrolltext()
    {
        clickCounter++;
        
        


        if (running == true)
        {
            StopCoroutine(current);
            if (counter == oldcounter)
            {
                counter++;
            }
            running = false;
            clickCounter--;

            if (clickCounter == pages)
            {
                btnTxt.text = "Start Level";
            }
            txt.text = txtFull[counter-1];
        }
        else if (counter != txtFull.Count)
        {
            
            oldcounter = counter;
            running = true;
            current = StartCoroutine(display());
        }
        else
        {
            currentLvl = lc.getLevel();
            if (currentLvl == 1)
            {
                SceneManager.LoadScene("UIdescription");
            }
            else
            {
                SceneManager.LoadScene("SampleScene");
            }
            
        }

        
    }


    IEnumerator display()
    {
        txt.text = "";
        for (int x = 0; x < txtFull[counter].Length; x++)
        {
           
            txt.text = txt.text+ txtFull[counter][x];
            if(txtFull[counter][x] == '\n')
            {
                yield return new WaitForSecondsRealtime((float)0.25);
            }
            if(txtFull[counter][x] == '!')
            {
                yield return new WaitForSecondsRealtime((float)0.5);
            }
            else
            {
                yield return new WaitForSecondsRealtime((float)0.02);
            }
            
        }
        if(clickCounter == pages)
        {
            btnTxt.text = "Start Level";
        }
        counter++;
        running = false;
    }
    
}
