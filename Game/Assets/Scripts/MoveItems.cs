using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItems : MonoBehaviour
{
    
    #region Variables
    
    // Variables
    private bool smthGrabbed;
    private GameObject grabbedItem;
    private GameObject selectedMarker;

    // Unity variables
    public GameObject grabAura;
    
    #endregion
    
    private void Start()
    {
        // set initial states
        smthGrabbed = false;
        grabbedItem = null;
    }
    
    private void Update()
    {

        #region Grabbing Aura Movement
        
        grabAura.transform.position = transform.position + transform.forward * 10;
        
        #endregion
        
        #region Grabbed Item Movement

        if (grabbedItem != null)
        {
            grabbedItem.transform.position = transform.position + transform.forward * 10;
            grabbedItem.transform.rotation = transform.rotation * Quaternion.Euler(45, 45, 0);
        }

        #endregion

        #region Grabbing & Releasing Items
        
        if (Input.GetKeyDown(KeyCode.E)) {

            // grabbing
            if (!smthGrabbed)
            {
                grabbedItem = grabAura.GetComponent<GrabAuraBehaviour>().grabbableItem;
                if (grabbedItem != null)
                    smthGrabbed = true;
                else
                    Debug.Log("Nothing to grab in range");
            }

            // releasing
            else
            {
                selectedMarker = grabAura.GetComponent<GrabAuraBehaviour>().releasableSlot;
                if (selectedMarker != null)
                {
                    grabbedItem.transform.position = selectedMarker.transform.position;
                    grabbedItem.transform.rotation = selectedMarker.transform.rotation;
                    grabbedItem = null;
                    smthGrabbed = false;
                }
                else
                    Debug.Log("No place to drop the item in range");
            }
            
        }
        
        #endregion
        
    }

}
