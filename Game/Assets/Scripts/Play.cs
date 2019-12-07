using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public GameManager gameManager;

    void Awake()
    {
        Debug.Log("Woke Play");
        if (gameManager.gameTest == GameTest.YES) 
        {
            Debug.Log("YES");
        }
        if (gameManager.gameTest == GameTest.NO)
        {
            Debug.Log("NO");
        }
        Debug.Log(gameManager.test);
        gameManager.SetGameState(GameState.PLAY);
    }
    void Start()
    {
        Debug.Log("Started Play");
        
    }
}
