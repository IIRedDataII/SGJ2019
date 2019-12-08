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
    private bool movedItems;

    // Unity variables
    public GameObject grabAura;
    public float maxAlpha;
    public float pulseSpeed;
    
    #endregion
    
    private void Start()
    {
        
        #region Initialization
        
        pulsating = false;
        grabbedItem = null;
        selectedMarker = null;
        itemPulsate = null;
        markerPulsate = null;
        movedItems = false;

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


        if (Input.GetKeyDown(KeyCode.E))
        {

            movedItems = false;

            #region Grabbing Items

            // if no item grabbed yet
            if (grabbedItem == null)
            {

                // get available item (might be null if no item is in range)
                grabbedItem = grabAura.GetComponent<GrabAuraBehaviour>().grabbableItem;
                Debug.Log("Grabbing: Grabbed Item: " + grabbedItem);

                // make player lose if closed shranc is in way:
                GameObject openableShranc = grabAura.GetComponent<GrabAuraBehaviour>().openableShranc;
                Debug.Log("Grabbing: Shranc in way: " + openableShranc);
                // test if there is a shranc in general in the way
                if (openableShranc != null)
                {
                    Debug.Log("Grabbing: There is a shranc in the way");
                    // test if that shranc is closed
                    Transform child = openableShranc.transform.GetChild(0);
                    if (Math.Round(child.transform.rotation.y, 1) == Math.Round(0f, 1))
                    {
                        Debug.Log("Grabbing: The shranc thats in the way is closed");
                        grabbedItem = null;
                    }
                }

                // if player got item make slots pulsate
                if (grabbedItem != null)
                {
                    Debug.Log("Grabbing: Got item!");
                    StopCoroutine(itemPulsate);
                    pulsating = false;
                    SetAlpha(true, 1);
                    movedItems = true;
                }

                else
                    Debug.Log("Grabbing: Nothing to grab in range");

            }

            #endregion

            #region Releasing Items

            else
            {

                // get available slot (might be null if no slot is in range)
                selectedMarker = grabAura.GetComponent<GrabAuraBehaviour>().releasableSlot;
                Debug.Log("Releasing: Selected Slot: " + selectedMarker);

                // make player lose slot if closed shranc is in way:
                GameObject openableShranc = grabAura.GetComponent<GrabAuraBehaviour>().openableShranc;
                Debug.Log("Releasing: Shranc in way: " + openableShranc);
                // test if there is a shranc in general in the way
                if (openableShranc != null)
                {
                    Debug.Log("Releasing: There is a shranc in the way");
                    // test if that shranc is closed
                    Transform child = openableShranc.transform.GetChild(0);
                    if (Math.Round(child.transform.rotation.y, 1) == Math.Round(0f, 1))
                    {
                        Debug.Log("Releasing: The shranc thats in the way is closed");
                        selectedMarker = null;
                    }
                }

                // test if player got slot:
                if (selectedMarker != null)
                {
                    Debug.Log("Releasing: Player got a slot");
                    // test if slot is not occupied yet
                    GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
                    bool occupied = false;
                    foreach (GameObject item in items)
                    {
                        if (item.transform.position == selectedMarker.transform.position)
                            occupied = true;
                    }

                    if (!occupied)
                    {
                        Debug.Log("Releasing: slot was not occupied, item got placed");
                        // put item down & make items pulsate
                        grabbedItem.transform.position = selectedMarker.transform.position;
                        grabbedItem.transform.rotation = selectedMarker.transform.rotation;
                        grabbedItem = null;
                        StopCoroutine(markerPulsate);
                        pulsating = false;
                        SetAlpha(false, 0);
                        movedItems = true;
                    }
                    else
                        Debug.Log("Releasing: Slot already occupied");

                }

                else
                    Debug.Log("Releasing: No place to drop the item in range");

            }

            #endregion

            #region Opening and closing shrancs

            // if played has moved items so far, dont do anything with shrancs anymore
            if (!movedItems) {

                // get available shranc (might be null if no shranc is in range)
                GameObject shranc = grabAura.GetComponent<GrabAuraBehaviour>().openableShranc;
                Debug.Log("Shrancs: Openable Shranc: " + shranc);

                // if player got shranc, possibly open or close it
                if (shranc != null)
                {
                    Debug.Log("Shrancs: Player got a shranc");
                    // get children (doors)
                    int i = 0;
                    Transform[] children = new Transform[2];
                    foreach (Transform child in shranc.transform)
                    {
                        children[i] = child;
                        i++;
                    }

                    // if shranc is open
                    if (Math.Round(children[0].transform.rotation.y, 1) == Math.Round(0.7f /*FOR SOME REASON 0.7 THIS IS THE VALUE WHEN DOOR IS OPEN*/, 1))
                    {
                        Debug.Log("Shrancs: Shranc is open");
                        // if there is no item and no slot in range and no item grabbed
                        if (grabAura.GetComponent<GrabAuraBehaviour>().grabbableItem == null &&
                            (grabbedItem == null || grabAura.GetComponent<GrabAuraBehaviour>().releasableSlot == null))
                        {
                            Debug.Log("Shrancs: Theres no item in range");
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
                            Debug.Log("Shrancs: Prioritied item");
                    }

                    // if shranc is closed then open it
                    else
                    {
                        Debug.Log("Shrancs: Opened shranc");
                        children[0].RotateAround(
                            new Vector3(children[0].transform.position.x, children[0].transform.position.y,
                                children[0].transform.position.z), Vector3.up, 90);
                        children[1].RotateAround(
                            new Vector3(children[1].transform.position.x, children[1].transform.position.y,
                                children[1].transform.position.z), Vector3.up, -90);
                    }

                }

                else
                    Debug.Log("Shrancs: No Shranc in range to open");
            }

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
            GameObject child = _object.transform.GetChild(0).gameObject;
            Renderer renderer = child.GetComponent<Renderer>();
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
        for (float i = 0; i <= (isItem ? maxAlpha : 1); i += maxAlpha / 10)
        {
            i = (float)Math.Round(i, 4);
            SetAlpha(isItem, i);
            yield return new WaitForSeconds(pulseSpeed);
        }
        
        // Fade out
        for (float i = (isItem ? maxAlpha : 1); i >= 0; i -= maxAlpha / 10)
        {
            i = (float)Math.Round(i, 4);
            SetAlpha(isItem, i);
            yield return new WaitForSeconds(pulseSpeed);
        }
        
        // Force opaque items in at the end of the last coroutine
        if (isItem && grabbedItem != null)
            SetAlpha(true, 1);
        
        pulsating = false;
    }
    
    #endregion

}
