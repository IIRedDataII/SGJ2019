using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShranc : MonoBehaviour
{

    public GameObject grabAura;
    private GameObject shranc;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            shranc = grabAura.GetComponent<GrabAuraBehaviour>().openableShranc;
            Debug.Log(shranc);
            if (shranc != null)
            {
                int i = 0;
                Transform[] children = new Transform[2];
                foreach (Transform child in shranc.transform)
                {
                    children[i] = child;
                    i++;
                }
                children[0].RotateAround(new Vector3(children[0].transform.position.x, children[0].transform.position.y, children[0].transform.position.z), Vector3.up, 90);
                children[1].RotateAround(new Vector3(children[1].transform.position.x, children[1].transform.position.y, children[1].transform.position.z), Vector3.up, -90);
            }
            
            else
                Debug.Log("No Shranc in range to open");

        }
        
    }
    
}
