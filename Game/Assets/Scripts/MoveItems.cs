using System;
using System.Collections;
using UnityEngine;

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
        itemPulsate = null;
        markerPulsate = null;

        #endregion

    }

    private void Update()
    {

        #region Grabbing Aura Movement
        
        grabAura.transform.position = transform.position + transform.forward * 1;
        grabAura.transform.rotation = transform.rotation * Quaternion.Euler(90, 0, 0);
        
        #endregion

        #region Grabbed Item State

        if (grabbedItem != null)
        {
            grabbedItem.transform.position = transform.position + transform.forward * 1 + transform.up * -0.375f;
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

        
        if (Input.GetKeyDown(KeyCode.E)) {

            #region Grabbing Items
            
            // if no item grabbed yet
            if (grabbedItem == null)
            {
                
                // get available item (might be null if no item is in range)
                grabbedItem = grabAura.GetComponent<GrabAuraBehaviour>().grabbableItem;
                
                // make player lose if closed shranc is in way:
                GameObject openableShranc = grabAura.GetComponent<GrabAuraBehaviour>().openableShranc;
                // test if there is a shranc in general in the way
                if (openableShranc != null)
                {
                    // test if that shranc is closed
                    Transform child = openableShranc.transform.GetChild(0);
                    if (Math.Round(child.transform.rotation.y, 1) == Math.Round(0f, 1)) {
                        grabbedItem = null;
                    }
                }
                
                // if player got item make slots pulsate
                if (grabbedItem != null)
                {
                    StopCoroutine(itemPulsate);
                    pulsating = false;
                    SetAlpha(true, 1);
                }
                
                else
                    Debug.Log("Nothing to grab in range");
                
            }
            
            #endregion

            #region Releasing Items
            
            else
            {
                
                // get available slot (might be null if no slot is in range)
                selectedMarker = grabAura.GetComponent<GrabAuraBehaviour>().releasableSlot;
                
                // make player lose slot if closed shranc is in way:
                GameObject openableShranc = grabAura.GetComponent<GrabAuraBehaviour>().openableShranc;
                // test if there is a shranc in general in the way
                if (openableShranc != null)
                {
                    // test if that shranc is closed
                    Transform child = openableShranc.transform.GetChild(0);
                    if (Math.Round(child.transform.rotation.y, 1) == Math.Round(0f, 1))
                        selectedMarker = null;
                }
                
                // if player got slot, put item down & make items pulsate
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
            
            #endregion
        
            #region Opening and closing shrancs
        
            // get available shranc (might be null if no shranc is in range)
            GameObject shranc = grabAura.GetComponent<GrabAuraBehaviour>().openableShranc;
            
            // if player got shranc, possibly open or close it
            if (shranc != null)
            {
                
                // get children (doors)
                int i = 0;
                Transform[] children = new Transform[2];
                foreach (Transform child in shranc.transform)
                {
                    children[i] = child;
                    i++;
                }
                
                // if shranc is open
                if (Math.Round(children[0].transform.rotation.y, 1) == Math.Round(0.7f/*FOR SOME REASON 0.7 THIS IS THE VALUE WHEN DOOR IS OPEN*/, 1))
                {
                    // if player can grab no item
                    if (grabAura.GetComponent<GrabAuraBehaviour>().grabbableItem == null)
                    {
                        // close shranc (cause item will be grabbed also if he can)
                        children[0].RotateAround(
                            new Vector3(children[0].transform.position.x, children[0].transform.position.y,
                                children[0].transform.position.z), Vector3.up, -90);
                        children[1].RotateAround(
                            new Vector3(children[1].transform.position.x, children[1].transform.position.y,
                                children[1].transform.position.z), Vector3.up, 90);
                    }
                    // if player can grab item, prioritize it
                    else
                        Debug.Log("Prioritied item");
                }
                
                // if shranc is closed then open it
                else {
                    children[0].RotateAround(new Vector3(children[0].transform.position.x, children[0].transform.position.y, children[0].transform.position.z), Vector3.up, 90);
                    children[1].RotateAround(new Vector3(children[1].transform.position.x, children[1].transform.position.y, children[1].transform.position.z), Vector3.up, -90);
                }
                
            }
            
            else
                Debug.Log("No Shranc in range to open");
            
            #endregion
            
        }

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
            // is object is made out of child objects with materials
            if (_object.transform.childCount > 0)
            {
                foreach (Transform child in _object.transform)
                {
                    Renderer renderer = child.GetComponent<Renderer>();
                    Color color = renderer.material.color;
                    color.a = alpha;
                    renderer.material.color = color;
                }
            }
            // if object is just one object with material
            else
            {
                Renderer renderer = _object.GetComponent<Renderer>();
                Color color = renderer.material.color;
                color.a = alpha;
                renderer.material.color = color;
            }
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
