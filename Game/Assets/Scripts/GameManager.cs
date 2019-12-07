using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { INTRO, PLAY }
public enum GameTest { NO, YES }

public class GameManager: MonoBehaviour 
{
    public static GameManager instance = null;
    public GameState gameState { get; private set; }
    public GameTest gameTest { get; private set; }
    public string test { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public static GameManager Instance
	{
        get
		{
			return instance;
		}
	}

    public void SetGameState(GameState state)
	{
		this.gameState = state;
	}

    public void setTest(string text)
    {
        this.test = text;
    }
    public void SetGameTest(GameTest test)
    {
        this.gameTest = test;
    }
    public void OnApplicationQuit()
	{
		GameManager.instance = null;
	}

}
