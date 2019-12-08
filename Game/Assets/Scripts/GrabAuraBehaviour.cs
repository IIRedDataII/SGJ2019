using UnityEngine;

public class GrabAuraBehaviour : MonoBehaviour
{
    
    public GameObject grabbableItem;
    public GameObject releasableSlot;
    public GameObject openableShranc;
    public GameObject interactableObject;
    
    private void Start()
    {
        grabbableItem = null;
        releasableSlot = null;
        openableShranc = null;
        interactableObject = null;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
            grabbableItem = other.gameObject;
        else if (other.gameObject.tag == "Slot")
            releasableSlot = other.gameObject;
        else if (other.gameObject.tag == "Openable")
            openableShranc = other.gameObject;
        else if (other.gameObject.tag == "Interactable")
            interactableObject = other.gameObject;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Item")
            grabbableItem = null;
        else if (other.gameObject.tag == "Slot")
            releasableSlot = null;
        else if (other.gameObject.tag == "Openable")
            openableShranc = null;
        else if (other.gameObject.tag == "Interactable")
            interactableObject = null;
    }
    
}
