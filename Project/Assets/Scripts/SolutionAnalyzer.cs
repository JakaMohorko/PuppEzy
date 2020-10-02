using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolutionAnalyzer : MonoBehaviour
{

    public List<GameObject> variables;
    public List<GameObject> resources;
    public List<GameObject> classes;
    public List<GameObject> includes;
    public List<GameObject> resLike;

    public List<string> solVars;
    public List<string> solIncludes;
    public List<List<string>> solRes;

    public List<List<string>> solResLike;

    public List<string> classNames;
    public List<List<List<string>>> classResourcesSol;
    public List<List<string>> classVariablesSol;
    public List<List<string>> classParamsSol;

    public Button submit;
    public GameObject submitScreen;

    public Button close;

    public GameObject fail;
    public GameObject nextLvl;

    public Text submitErrorText;

    LevelCounter lc;

    string errorMsg;
    public GameObject win;

    void Start()
    {
        variables = new List<GameObject>();
        resources = new List<GameObject>();
        classes = new List<GameObject>();
        includes = new List<GameObject>();
        resLike = new List<GameObject>();

        solVars = new List<string>();
        solIncludes = new List<string>();
        solRes = new List<List<string>>();
        classResourcesSol = new List<List<List<string>>>();
        classVariablesSol = new List<List<string>>();
        classNames = new List<string>();
        classParamsSol = new List<List<string>>();
        solResLike = new List<List<string>>();

        lc = GameObject.Find("TopCanvas").GetComponent<LevelCounter>();

        int counter = lc.getLevel();

        if (counter == 1)
        {
            solRes = new List<List<string>>
            {
                new List<string>
                {
                    "file { '/data/data.txt':",
                    "\tensure => present",
                    "\towner => 'guest'"
                }
            };

        }
        else if (counter == 2)
        {
            solRes = new List<List<string>>
            {
                new List<string>
                {
                    "file { '/data/log.txt':",
                    "\tensure => present",
                    "\towner => 'root'",
                    "\tmode => '0666'"
                },
                new List<string>
                {
                    "user { 'guest':",
                    "\tensure => absent",
                },
                new List<string>
                {
                    "user { 'alice':",
                    "\tensure => present",
                    "\tuid => 1",
                    "\tshell => '/bin/bash'",
                    "\thome => '/alice'"
                }
            };
        }
        else if (counter == 3)
        {
            classNames = new List<string>
            {
                "class alice { "
            };

            classResourcesSol = new List<List<List<string>>>
            {
                new List<List<string>>
                {
                     new List<string>
                    {
                        "user { 'alice':",
                        "\tensure => present",
                        "\tuid => 1",
                        "\thome => \"$dir/alice\""
                    },
                     new List<string>
                    {
                        "file { \"$dir/alice\":",
                        "\tensure => directory"
                    }
                }
            };

            solIncludes = new List<string>
            {
                "include alice"
            };

            classVariablesSol = new List<List<string>>
            {
                new List<string>
                {
                    "$dir = '/disk/users'"
                }
            };

            classParamsSol = new List<List<string>>
            {
                new List<string>
                {

                }
            };
        }
        else if (counter == 4)
        {
            classNames = new List<string>
            {
                "class apache { "
            };
            classVariablesSol = new List<List<string>>
            {
                new List<string>
                {
                    "$version = latest"
                }
            };
            classResourcesSol = new List<List<List<string>>>
            {
                new List<List<string>>
                {
                    new List<string>
                    {
                        "exec { 'apt-get-update':",
                        "\tcwd => '/usr/bin'",
                        "\tuser => 'root'",
                        "\tcommand => 'apt-get update'"
                    },
                    new List<string>
                    {
                        "package { 'apache2':",
                        "\tensure => $version"
                    },
                    new List<string>
                    {
                        "service { 'apache2':",
                        "\tensure => running",
                        "\tenable => true"
                    },
                    new List<string>
                    {
                        "file { '/etc/version':",
                        "\tensure => file",
                        "\tmode => '0600'",
                        "\towner => 'root'",
                        "\tcontent => \"$version\""
                    }
                }
            };
            classParamsSol = new List<List<string>>
            {
                new List<string>
                {

                }
            };
            solIncludes = new List<string>
            {
                "include apache"
            };
        }
        else if (counter == 5)
        {
            classNames = new List<string>
            {
                "class delete_user ( "
            };

            classParamsSol = new List<List<string>>
            {
                new List<string>
                {
                    "$user = 'default'",
                    "$dir = 'default'"
                }
            };
            classResourcesSol = new List<List<List<string>>>
            {
                new List<List<string>>
                {
                    new List<string>
                    {
                        "user { $user:",
                        "\tensure => absent"
                    },
                    new List<string>
                    {
                        "file { \"$dir/$user\":",
                        "\tensure => absent"
                    }

                }
            };
            classVariablesSol = new List<List<string>>
            {
                new List<string>()
            };
            solResLike = new List<List<string>>
            {
                new List<string>
                {
                    "class { 'delete_user':",
                    "$user => 'alice'",
                    "$dir => '/users'"
                }
            };
        }
        else if (counter == 6)
        {
            classNames = new List<string>
            {
                "class nginx { ",
                "class openssh ( "
            };
            classResourcesSol = new List<List<List<string>>>
            {
                new List<List<string>>
                {
                    new List<string>
                    {
                        "package { 'apache2.2':",
                        "\tensure => absent"
                    },
                    new List<string>
                    {
                        "package { 'nginx':",
                        "\tensure => installed",
                        "\trequire => Package['apache2.2']"
                    },
                    new List<string>
                    {
                        "service { 'nginx':",
                        "\tensure => running",
                        "\trequire => Package['nginx']"
                    }
                },
                new List<List<string>>
                {
                    new List<string>
                    {
                        "package { 'openssh-server':",
                        "\tensure => $version"
                    },
                    new List<string>
                    {
                        "service { 'sshd':",
                        "\tensure => running",
                        "\tenable => true",
                        "\trequire => Package['openssh-server']"
                    },
                    new List<string>
                    {
                        "file { '/etc/ssh':",
                        "\tensure => directory",
                        "\tmode => '0600'",
                        "\towner => 'root'",
                        "\trequire => Package['openssh-server']"
                    },
                    new List<string>
                    {
                        "exec { 'mkdir_backup':",
                        "\tcwd => '/etc/ssh'",
                        "\tcommand => 'mkdir backup'",
                        "\trequire => File['/etc/ssh']"
                    }
                }
            };

            classParamsSol = new List<List<string>>
            {
                new List<string>(),
                new List<string>
                {
                    "$version = latest"
                }
            };
            solIncludes = new List<string>
            {
                "include nginx"
            };
            solResLike = new List<List<string>>
            {
                new List<string>
                {
                    "class { 'openssh':",
                    "$version => '7.3'"
                }
            };
            classVariablesSol = new List<List<string>>
            {
                new List<string>(),
                new List<string>()
            };
        }
        

        close.onClick.AddListener(closeClick);
        submit.onClick.AddListener(compare);
    }

    public void compare()
    {
        bool solved = true;


       
        if (includeCompare() && solved)
        {
            Debug.unityLogger.Log("tag", "right include solution");
        }
        else
        {
            Debug.unityLogger.Log("tag", "wrong include solution");
            incorrect();
            solved = false;
        }

        if (resLikeCompare() && solved)
        {
            Debug.unityLogger.Log("tag", "right reslike solution");
        }
        else
        {
            incorrect();
            Debug.unityLogger.Log("tag", "wrong reslike solution");
            solved = false;
        }

        if (varCompare() && solved)
        {
            Debug.unityLogger.Log("tag", "right var solution");
        }
        else
        {
            Debug.unityLogger.Log("tag", "wrong var solution");
            incorrect();
            solved = false;
        }

        if (resCompare())
        {
            Debug.unityLogger.Log("tag", "right resource solution");
        }
        else
        {
            solved = false;
            Debug.unityLogger.Log("tag", "wrong resource solution");
            incorrect();
        }

        if (classCompare() && solved)
        {
            Debug.unityLogger.Log("tag", "right class solution");
        }
        else
        {
            Debug.unityLogger.Log("tag", "wrong class solution");
            incorrect();
            solved = false;
        }
        if (solved)
        {
 
                nextLvl.SetActive(true);
                win.SetActive(true);
                WinText wt = GameObject.Find("Winscreen").GetComponent<WinText>();
                wt.startDisplay();
 
        }

    }
    
    void incorrect()
    {
        submitScreen.SetActive(true);
        fail.SetActive(true);
        //succ.SetActive(false);
        nextLvl.SetActive(false);

        submitErrorText.text = errorMsg;
    }

    void closeClick()
    {
        submitScreen.SetActive(false);
    }


    bool varCompare()
    {
        VarController currentObject = null;
        string[] currentSolution;
        string[] currentVariable;
        Debug.unityLogger.Log("tag", "In varCompare");
        bool found = false;

        /*if (solVars.Count != variables.Count)
        {
            Debug.unityLogger.Log("tag", "Wrong number of variables");
            return false;
        }*/

        for(int x = 0; x < solVars.Count; x++)
        {
            Debug.unityLogger.Log("tag", "Current variable: " + solVars[x]);
            currentSolution = solVars[x].Split('=');

            if (currentSolution[1].EndsWith(","))
            {
                currentSolution[1].Remove(currentSolution[1].Length - 1);
            }

            for (int z = 0; z < variables.Count; z++)
            {
                currentObject = variables[z].GetComponent<VarController>();
                currentVariable = currentObject.content.Split('=');
                if(currentVariable[0] == currentSolution[0])
                {

                    if (currentSolution[1] == currentVariable[1]) // var match found
                    {
                            found = true;
                    }
                    else // wrong content of var
                    {

                        Debug.unityLogger.Log("tag", "Wrong content of variable");
                        errorMsg = "The content of a variable is incorrect.";
                        return false;
                    }
                }

                
            }
            if (found == false)
            {
                errorMsg = "A Variable declaration is missing.";
                return false;
            }
            found = false;
        }

        for (int x = 0; x < variables.Count; x++)
        {
            currentObject = variables[x].GetComponent<VarController>();
            currentVariable = currentObject.content.Split('=');
            if (currentVariable[1].EndsWith(","))
            {
                currentVariable[1].Remove(currentVariable[1].Length - 1);
            }
            for (int z = x+1; z < variables.Count; z++)
            {
                if(currentVariable[0] == variables[z].GetComponent<VarController>().content.Split('=')[0])  // var with name x has been defined twice
                {
                    Debug.unityLogger.Log("tag", "variable " + currentVariable[0] + " has been defined 2 times");
                    errorMsg = "A variable with the same name has been defined more than once.";
                    return false;
                }
            }
        }


        return true;
    }

    bool resCompare()
    {

        string currentName = "";
        string resName = "";
        ResourceController currentResource = null;

        bool found = false;

        for (int x = 0; x < solRes.Count; x++)
        {
            currentName = solRes[x][0];
            Debug.unityLogger.Log("tag", "Currently checking: " + currentName);

            for (int z = 0; z < resources.Count; z++) //find resource with the same name
            {

                resName = resources[z].GetComponent<ResourceController>().name;
                Debug.unityLogger.Log("tag", "Resource name: " + resName);

                for (int y = z+1; y <resources.Count; y++)
                {
                    if(resName == resources[y].GetComponent<ResourceController>().name)
                    {
                        //double definition of resource
                        Debug.unityLogger.Log("tag", "Double definition of resource " + resName);
                        errorMsg = "A resource with the same name and type has been defined more than once.";
                        return false;
                    }
                }

                if (resName == currentName)
                {
                    currentResource = resources[z].GetComponent<ResourceController>();
                    found = true;
                }
                
            }

            if (found == false)
            {
                Debug.unityLogger.Log("tag", "no resource with correct name found");
                errorMsg = "There is a missing resource declaration, or a resource is incorrectly named.";
                return false; //no resource with correct name found
            }

            found = false;

            for (int y = 1; y < solRes[x].Count; y++)
            {

                Debug.unityLogger.Log("tag", "sol: " + solRes[x][y]);

                if (currentResource.definitions.Count > solRes[x].Count - 1)
                {
                    Debug.unityLogger.Log("tag", "incorrect number of constraints");
                    errorMsg = "Resource declaration '" + currentResource.name + "' has too many Attribute => Value pairs";
                    return false; //incorrect number of constraints
                }

                for (int z = 0; z < currentResource.definitions.Count; z++)
                {
                    ResourceMidController resMid = currentResource.definitions[z].GetComponent<ResourceMidController>();
                    string resDef = resMid.content;
                    Debug.unityLogger.Log("tag", "comparing to: " + resDef);
                    if (resDef.EndsWith(","))
                    {
                        resDef.Remove(resDef.Length - 1);
                    }

                    if(resDef == solRes[x][y])
                    {
                        found = true;
                    }
                }

                if(found == false) //resource def not found
                {
                    Debug.unityLogger.Log("tag", "resource def not found");
                    errorMsg = "Resource '" + currentResource.name + "' is missing one or more Attribute => Value declarations, or a declaration is incorrect";
                    return false;
                }

                found = false;
            }

            found = false;
        }

        return true;
    }
    

    bool classCompare()
    {
        ClassController currentClass = null;
        ResourceController currentRes = null;
        VarController currentVarObject = null;

        string currentClassName = "";
        string[] currentVariableSol;
        string[] currentVariableContent;

        bool found = false;


        for(int x = 0; x < classNames.Count; x++)
        {
            // Name checking and class lookup
            Debug.unityLogger.Log("tag", "checking class name: " + classNames[x]);
            for (int y = 0; y < classes.Count; y++)
            {
                ClassController tempClass = classes[y].GetComponent<ClassController>();
                string tempClassName = tempClass.name;
                for (int z = y+1; z < classes.Count; z++)
                {
                    if(tempClassName == classes[z].GetComponent<ClassController>().name)
                    {
                        Debug.unityLogger.Log("tag", "duplicate found " + tempClassName);
                        errorMsg = "A resource within a class has been defined more than once.";
                        return false; //duplicate class found
                    }
                }

                if(tempClassName == classNames[x])
                {
                    currentClass = classes[y].GetComponent<ClassController>();
                    currentClassName = currentClass.name;
                    found = true;
                }
            }

            if(found == false)
            {
                Debug.unityLogger.Log("tag", "No matching class name found");
                errorMsg = "There is a class definition missing, or a class has been named incorrectly.";
                return false; // no matching class name found
            }

            found = false;

            // Class parameter checking
            for (int y = 0; y < classParamsSol[x].Count; y++)
            {
                string[] currentParamSol = classParamsSol[x][y].Split('=');
                ParamVarController currentParam;
                string[] currentParamContent;
                Debug.unityLogger.Log("tag", "checking parameter: " + currentParamSol[0] + " " + currentParamSol[1]);

                for (int z = 0; z < currentClass.classParams.Count; z++)
                {
                    currentParam = currentClass.classParams[z].GetComponent<ParamVarController>();
                    currentParamContent = currentParam.content.Split('=');
                    Debug.unityLogger.Log("tag", "comparing to: " + currentParamContent[0] + " " + currentParamContent[1]);

                    if (currentParamContent[1].EndsWith(","))
                    {
                        currentParamContent[1].Remove(currentParamContent[1].Length - 1);
                    }

                    if (currentParamContent[0] == currentParamSol[0])
                    {
                        if(currentParamContent[1] == currentParamSol[1])
                        {
                            found = true;
                        }
                        else
                        {
                            Debug.unityLogger.Log("tag", "Wrong content of param");
                            errorMsg = "The content of a class parameter is incorrect.";
                            return false;
                        }
                    }
                }
                if (found == false)
                {
                    // Class parameter not found
                    Debug.unityLogger.Log("tag", "Class param not found");
                    errorMsg = "There is either one or more missing class parameter definitions, or an incorrect variable name has been used within a parameter definition.";
                        return false;
                }
                found = false;
            }

            found = false;

            for (int y = 0; y < currentClass.classParams.Count; y++)
            {
                ParamVarController currentParam;
                string[] currentParamContent;

                currentParam = currentClass.classParams[y].GetComponent<ParamVarController>();
                currentParamContent = currentParam.content.Split('=');

                if (currentParamContent[1].EndsWith(","))
                {
                    currentParamContent[1].Remove(currentParamContent[1].Length - 1);
                }

                for (int z = y + 1; z < currentClass.classParams.Count; z++)
                {
                    if (currentParamContent[y] == currentClass.classParams[z].GetComponent<ParamVarController>().content.Split('=')[0])
                    {
                        // duplicate parameter definition
                        Debug.unityLogger.Log("tag", "parameter " + currentParamContent[0] + " has been defined 2 times");
                        errorMsg = "A class parameter with the same variable name has been defined more than once.";
                        return false;
                    }
                }
            }


            // Class variable checking
            for (int y = 0; y < classVariablesSol[x].Count; y++)
            {

                currentVariableSol = classVariablesSol[x][y].Split('='); 

                for (int z = 0; z < currentClass.classVariables.Count; z++)
                {
                    currentVarObject = currentClass.classVariables[z].GetComponent<VarController>();
                    currentVariableContent = currentVarObject.content.Split('=');

                    if (currentVariableContent[1].EndsWith(","))
                    {
                        currentVariableContent[1].Remove(currentVariableContent[1].Length - 1);
                    }

                    Debug.unityLogger.Log("tag", "comparing to var: " + currentVariableContent[0] + " " + currentVariableContent[1]);
                    if (currentVariableContent[0] == currentVariableSol[0])
                    {

                        if (currentVariableSol[1] == currentVariableContent[1]) // var match found
                        {
                            found = true;
                        }
                        else // wrong content of var
                        {
                            Debug.unityLogger.Log("tag", "Wrong content of variable");
                            errorMsg = "The content of a class variable in '" + currentClass.name + "' is incorrect.";
                            return false;
                        }
                    }


                }
                if (found == false)
                {
                    // Class variable not found
                    Debug.unityLogger.Log("tag", "Class variable not found");
                    errorMsg = "There is a class variable missing in class '" + currentClass.name + "'.";
                    return false;
                }
                found = false;
            }

            found = false;

            for (int y = 0; y < currentClass.classVariables.Count; y++)
            {
                currentVarObject = currentClass.classVariables[y].GetComponent<VarController>();
                currentVariableContent = currentVarObject.content.Split('=');

                if (currentVariableContent[1].EndsWith(","))
                {
                    currentVariableContent[1].Remove(currentVariableContent[1].Length - 1);
                }

                for (int z = y + 1; z < currentClass.classVariables.Count; z++)
                {
                    if (currentVariableContent[y] == currentClass.classVariables[z].GetComponent<VarController>().content.Split('=')[0])  
                    {
                        // duplicate variable definition
                        Debug.unityLogger.Log("tag", "variable " + currentVariableContent[0] + " has been defined 2 times");
                        errorMsg = "A class variable with the same name has been defined more than once.";
                        return false;
                    }
                }
            }

            // Class resource checking


            if (classResourcesSol[x].Count < currentClass.classResources.Count)
            {
                //incorrect amount of in class resource definitions
                Debug.unityLogger.Log("tag", "incorrect amount of in class resource definitions");
                errorMsg = "Class '" + currentClass.name + "' has too many variable definitions.";
                return false;
            }

            for (int y = 0; y < classResourcesSol[x].Count; y++)
            {

                string resNameSol = classResourcesSol[x][y][0];
                Debug.unityLogger.Log("tag", "current resource: " + resNameSol);


                // Resource name checking and resource lookup
                for (int z = 0; z < currentClass.classResources.Count; z++)
                {

                    ResourceController tempResource = currentClass.classResources[z].GetComponent<ResourceController>();
                    string tempResName = tempResource.name;

                    for (int k = z + 1; k < currentClass.classResources.Count; k++)
                    {
                        if (tempResName == currentClass.classResources[k].GetComponent<ResourceController>().name)
                        {
                            // duplicate resource definition within class
                            Debug.unityLogger.Log("tag", "duplicate resource definition within class");
                            errorMsg = "A class resource with the same name and type has been defined more than once within a class.";
                            return false;
                        }
                    }

                    if (tempResName == resNameSol)
                    {
                        Debug.unityLogger.Log("tag", "resource match found");
                        currentRes = currentClass.classResources[z].GetComponent<ResourceController>();
                        found = true;
                    }

                }

                if (found == false)
                {
                    Debug.unityLogger.Log("tag", "no resource with correct name found");
                    errorMsg = "There is a missing or incorrect resource definition in class '" + currentClass.name + "'.";
                    return false; //no resource with correct name found
                }

                found = false;

                // Resource attributes checking
                if (classResourcesSol[x][y].Count-1 < currentRes.definitions.Count)
                {
                    //incorrect number of definitions
                    Debug.unityLogger.Log("tag", "incorrect number of definitions");
                    errorMsg = "Resource '" + currentRes.name + "' in class '" + currentClass.name + "' has too many Attribute => Value definitions.";
                    return false;
                }

                for (int z = 1; z < classResourcesSol[x][y].Count; z++)
                {
                    Debug.unityLogger.Log("tag", "checking attribute: " + classResourcesSol[x][y][z]);
                    for (int k = 0; k < currentRes.definitions.Count; k++)
                    {
                        string currentDef = currentRes.definitions[k].GetComponent<ResourceMidController>().content;
                        Debug.unityLogger.Log("tag", "comparing to: " + currentDef);
                        if (currentDef.EndsWith(","))
                        {
                            currentDef.Remove(currentDef.Length - 1);
                        }

                        if (classResourcesSol[x][y][z] == currentDef)
                        {
                            found = true;
                        }
                    }
                    if(found == false)
                    {
                        // definition not found in resource
                        Debug.unityLogger.Log("tag", "definition not found in resource: " + classResourcesSol[x][y][z]);
                        errorMsg = "There is one or more missing or incorrect Attribute => Value pairs in class '" + currentClass.name + "' in the '" + currentRes.name + "' resource declaration.";
                        return false;
                    }
                    found = false;
                }
            

            }

        }
        return true;
    }

    bool includeCompare()
    {
        IncludeController currentObject = null;
        string currentSolution;
        string currentInclude;
        Debug.unityLogger.Log("tag", "In includeCompare");
        bool found = false;

        if (solIncludes.Count < includes.Count)
        {
            Debug.unityLogger.Log("tag", "Wrong number of includes");
            errorMsg = "Too many include statements.";
            return false;
        }

        for (int x = 0; x < solIncludes.Count; x++)
        {
            Debug.unityLogger.Log("tag", "Current include: " + solIncludes[x]);
            currentSolution = solIncludes[x];
            for (int z = 0; z < includes.Count; z++)
            {
                currentObject = includes[z].GetComponent<IncludeController>();
                currentInclude = currentObject.content;
                if (currentInclude == currentSolution)
                {
                    found = true;
                }
            }
            if (found == false)
            {
                errorMsg = "One or more missing or incorrect include functions.";
                return false;
            }
            found = false;
        }

        return true;
    }

    bool resLikeCompare()
    {
        string currentName = "";
        string resName = "";
        ResLikeController currentResLike = null;

        bool found = false;

        for (int x = 0; x < solResLike.Count; x++)
        {
            currentName = solResLike[x][0];
            Debug.unityLogger.Log("tag", "Currently checking: " + currentName);

            for (int z = 0; z < resLike.Count; z++) //find resource with the same name
            {

                resName = resLike[z].GetComponent<ResLikeController>().name;
                Debug.unityLogger.Log("tag", "Resource name: " + resName);

                for (int y = z + 1; y < resLike.Count; y++)
                {
                    if (resName == resources[y].GetComponent<ResLikeController>().name)
                    {
                        //double definition of resource
                        Debug.unityLogger.Log("tag", "Double definition of reslike " + resName);
                        errorMsg = "A class has been invoked more than once using a resource-like class definition.";
                        return false;
                    }
                }

                if (resName == currentName)
                {
                    currentResLike = resLike[z].GetComponent<ResLikeController>();
                    found = true;
                }

            }

            if (found == false)
            {
                Debug.unityLogger.Log("tag", "no reslike with correct name found");
                errorMsg = "There is a missing or incorrect resource-like class definition.";
                return false; //no resource with correct name found
            }

            found = false;

            for (int y = 1; y < solResLike[x].Count; y++)
            {

                Debug.unityLogger.Log("tag", "sol: " + solResLike[x][y]);

                if (currentResLike.classParams.Count > solResLike[x].Count - 1)
                {
                    Debug.unityLogger.Log("tag", "incorrect number of constraints");
                    errorMsg = "A resource-like class definition has too many Parameter => Value definitions.";
                    return false; //incorrect number of constraints
                }

                for (int z = 0; z < currentResLike.classParams.Count; z++)
                {
                    ResLikeParamController param = currentResLike.classParams[z].GetComponent<ResLikeParamController>();
                    string paramDef = param.content;
                    Debug.unityLogger.Log("tag", "comparing to: " + paramDef);
                    if (paramDef.EndsWith(","))
                    {
                        paramDef.Remove(paramDef.Length - 1);
                    }

                    if (paramDef == solResLike[x][y])
                    {
                        found = true;
                    }
                }

                if (found == false) //resource def not found
                {
                    Debug.unityLogger.Log("tag", "reslike param not found");
                    errorMsg = "A Parameter => Value definition is missing from a resource-like class definition.";
                    return false;
                }

                found = false;
            }

            found = false;
        }

        return true;
    }

}