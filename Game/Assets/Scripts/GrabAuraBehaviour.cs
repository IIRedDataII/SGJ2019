using UnityEngine;

public class GrabAuraBehaviour : MonoBehaviour
{
    
    public GameObject grabbableItem;
    public GameObject releasableSlot;
    
    private void Start()
    {
        grabbableItem = null;
        releasableSlot = null;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
            grabbableItem = other.gameObject;
        else if (other.gameObject.tag == "Slot")
            releasableSlot = other.gameObject;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Item")
            grabbableItem = null;
        else if (other.gameObject.tag == "Slot")
            releasableSlot = null;
    }
    
}
