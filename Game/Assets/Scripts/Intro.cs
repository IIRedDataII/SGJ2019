using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public GameManager gameManager;
    public Image newspaper;
    public Text startButton;

    public Sprite fail;
    public Sprite warning;
    public Sprite kill;
    public Sprite scare;
    public Sprite disable;
    public Sprite door;

    void Awake ()
	{
        Debug.Log("Woke Intro");
        if (!gameManager.inStartup) {
            conifgureNewspaper();
        }
        
	}
    void Start()
    {
        if (gameManager.inStartup)
        {
            Debug.Log("Should startup");
            startButton.text = "Spiel starten";
            gameManager.performedStartup();
        }
        Debug.Log("Started Intro Script");
    }

    private void conifgureNewspaper()
    {
        switch (gameManager.exitState)
        {
            case ExitState.FAIL:
                Debug.Log("ExitState Fail");
                break;
            case ExitState.WARNING:
                Debug.Log("ExitState Warning");
                break;
            case ExitState.KILL:
                Debug.Log("ExitState Kill");
                break;
            case ExitState.SCARE:
                Debug.Log("ExitState Scare");
                break;
            case ExitState.DISABLE:
                Debug.Log("ExitState Disable");
                break;
            case ExitState.DOOR:
                Debug.Log("ExitState Door");
                break;
        }
    }
}
