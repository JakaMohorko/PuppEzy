using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResourceAddController : MonoBehaviour
{

    public Button newResource;
    public GameObject newLine;
    public List<GameObject> lines;
    
    

    // Start is called before the first frame update
    void Start()
    {
        newResource.onClick.AddListener(btnclick);
        lines = new List<GameObject>();
    }

    void btnclick()
    {

        GameObject nl = GameObject.Instantiate(newLine);
        lines.Add(nl);
        nl.transform.SetParent(GameObject.Find("rhsPanel").transform);
        nl.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        

       // newResource.transform.SetAsLastSibling();
    }
}
