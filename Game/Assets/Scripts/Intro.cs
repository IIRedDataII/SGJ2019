using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public GameManager gameManager;
    public Image newspaper;
    public Sprite alternative;

    void Awake ()
	{
        Debug.Log("Woke Intro");
        gameManager.setTest("Hello World");
        newspaper.sprite = alternative;
        //gameManager.SetGameState(GameState.INTRO);
	}
    void Start()
    {
        Debug.Log("Started Intro Script");
        gameManager.SetGameTest(GameTest.YES);
        if (gameManager.gameTest == GameTest.YES)
        {
            Debug.Log("First Yes");
        }
        
    }
}
