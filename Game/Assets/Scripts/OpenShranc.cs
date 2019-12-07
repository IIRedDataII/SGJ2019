using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShranc : MonoBehaviour
{

    private void Start()
    {
        
        foreach (Transform child in transform)
        {
            Debug.Log(child);
        }
        
    }
    
}
