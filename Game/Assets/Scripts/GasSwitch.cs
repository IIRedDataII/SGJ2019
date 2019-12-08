using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasSwitch : MonoBehaviour
{

    public GameObject grabAura;
    public GameObject switchObject;

    public bool status;    // true means switch has been activated

    private void Start()
    {
        status = false;
    }
    
    // Update is called once per frame
    void Update()
    {

        // if (pressed E AND has no item AND has  in range AND has switch in range)
        if (Input.GetKeyDown(KeyCode.E) && gameObject.GetComponent<MoveItems>().grabbedItem == null && grabAura.GetComponent<GrabAuraBehaviour>().interactableObject != null)
        {

            if (!status) {
                if (gameObject.GetComponent<MoveItems>().movesLeft > 0)
                {
                    switchObject.transform.RotateAround(new Vector3(switchObject.transform.position.x, switchObject.transform.position.y, switchObject.transform.position.z), switchObject.transform.right, 45);
                    status = true;
                    gameObject.GetComponent<MoveItems>().movesLeft--;
                    gameObject.GetComponent<MoveItems>().movesLeftText.text = "Moves left: " + gameObject.GetComponent<MoveItems>().movesLeft;
                }
                else
                {
                    Debug.Log("You used up all moves");
                }
            }
            else
            {
                switchObject.transform.RotateAround(new Vector3(switchObject.transform.position.x, switchObject.transform.position.y, switchObject.transform.position.z), switchObject.transform.right, -45);
                status = false;
            }
        }
        
        
    }
    
    
}
