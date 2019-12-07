using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItems : MonoBehaviour
{

    // Constants
    private Vector3 item1Pos = new Vector3(-24, -4, 10);
    private Vector3 item2Pos = new Vector3(0, -4, 10);
    private Vector3 item3Pos = new Vector3(24, -4, 10);

    // Unity variables
    public GameObject grabAura;
    public GameObject item;

    void Update()
    {

        grabAura.transform.position = transform.position + transform.forward * 10;
        //grabAura.transform.rotation = transform.rotation * Quaternion.Euler(45, 45, 0);
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.Equals("Item1"))
        {
            Debug.Log("Item 1");
        }
        else if (other.gameObject.name.Equals("Item2"))
        {
            Debug.Log("Item 1");
        }
        else if (other.gameObject.name.Equals("Item3"))
        {
            
            Debug.Log("Item 1");
        }
        
    }
    
}
