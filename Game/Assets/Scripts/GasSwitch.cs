using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasSwitch : MonoBehaviour
{

    public GameObject grabAura;
    public GameObject switchObject;

    private bool status;

    private void Start()
    {
        status = false;
    }
    
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && grabAura.GetComponent<GrabAuraBehaviour>().interactableObject != null && grabAura.GetComponent<GrabAuraBehaviour>().interactableObject.name == "TriggerSwitch")
        {

            if (!status) {
                switchObject.transform.RotateAround(new Vector3(switchObject.transform.position.x, switchObject.transform.position.y, switchObject.transform.position.z), switchObject.transform.right, 45);
                status = true;
            }
            else
            {
                switchObject.transform.RotateAround(new Vector3(switchObject.transform.position.x, switchObject.transform.position.y, switchObject.transform.position.z), switchObject.transform.right, -45);
                status = false;
            }
        }
        
        
    }
    
    
}
