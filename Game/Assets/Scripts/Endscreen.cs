using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endscreen : MonoBehaviour
{
	public GameManager gameManager;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
		{
			gameManager.showMenu();
		}
		{

		}
    }
}
