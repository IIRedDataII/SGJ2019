using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveItems : MonoBehaviour
{
    
    #region Variables
    
    // Variables
    private bool pulsating;
    private GameObject grabbedItem;
    private GameObject selectedMarker;
    private Coroutine itemPulsate;
    private Coroutine markerPulsate;

    // Unity variables
    public GameObject grabAura;
    
    #endregion
    
    private void Start()
    {
        
        #region Initialization
        
        pulsating = false;
        grabbedItem = null;
        selectedMarker = null;
        
        #endregion

    }

    private void Update()
    {

        #region Grabbing Aura Movement
        
        grabAura.transform.position = transform.position + transform.forward * 10;
        
        #endregion

        #region Grabbed Item State

        if (grabbedItem != null)
        {
            grabbedItem.transform.position = transform.position + transform.forward * 5 + transform.up * -2;
            grabbedItem.transform.rotation = transform.rotation * Quaternion.Euler(45, 45, 0);
        }

        #endregion
        
        #region Coroutine Managing

        if (!pulsating)
        {
            if (grabbedItem == null)
                itemPulsate = StartCoroutine(Pulsate(true));
            else
                markerPulsate = StartCoroutine(Pulsate(false));
        }
        
        #endregion

        #region Grabbing & Releasing Items
        
        if (Input.GetKeyDown(KeyCode.E)) {

            // grabbing
            if (grabbedItem == null)
            {
                grabbedItem = grabAura.GetComponent<GrabAuraBehaviour>().grabbableItem;
                if (grabbedItem != null)
                {
                    StopCoroutine(itemPulsate);
                    pulsating = false;
                    SetAlpha(true, 1);
                }
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
                    StopCoroutine(markerPulsate);
                    pulsating = false;
                    SetAlpha(false, 0);
                }
                else
                    Debug.Log("No place to drop the item in range");
            }
            
        }
        
        #endregion
        
    }

    #region Helper Functions
    
    private void SetAlpha(bool isItem, float alpha)
    {
        GameObject[] objects;
        if (isItem) 
            objects = GameObject.FindGameObjectsWithTag("Item");
        else
            objects = GameObject.FindGameObjectsWithTag("Marker");
        foreach (GameObject _object in objects)
        {
            Renderer renderer = _object.GetComponent<Renderer>();
            Color color = renderer.material.color;
            color.a = alpha;
            renderer.material.color = color;
        }
    }
    
    #endregion
    
    #region Coroutines

    IEnumerator Pulsate(bool isItem)
    {
        pulsating = true;
        
        // Fade in
        for (float i = 0; i <= 1; i += 0.1f)
        {
            i = (float)Math.Round(i, 2);
            SetAlpha(isItem, i);
            yield return new WaitForSeconds(0.05f);
        }
        
        // Fade out
        for (float i = 1; i >= 0; i -= 0.1f)
        {
            i = (float)Math.Round(i, 2);
            SetAlpha(isItem, i);
            yield return new WaitForSeconds(0.05f);
        }
        
        // Force opaque items in at the end of the last coroutine
        if (isItem && grabbedItem != null)
            SetAlpha(true, 1);
        
        pulsating = false;
    }
    
    #endregion

}
