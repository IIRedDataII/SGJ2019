using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { INTRO, PLAY }
/*ExitState:
 * 0 - FAIL: Murder + Explosion
 * 1 - WARNING
 * 2 - KILL murderer
 * 3 - SCARE off murderer
 * 4 - DISABLE murderer
 * 5 - PREVENT murder
 * 6 - DOOR blocked
 */
public enum ExitState { FAIL, WITHOUT, WARNING, KILL, SCARE, DISABLE, DOOR}

public class GameManager: MonoBehaviour 
{
    public static GameManager instance = null;

    public GameState gameState { get; private set; }
    public ExitState exitState { get; private set; }
    public bool inStartup { get; private set; } = true;

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

    public void performedStartup()
    {
        this.inStartup = false;
    }

    public void endTry(ExitState result)
    {
        this.exitState = result;
        SceneManager.LoadScene("Scenes/Intro", LoadSceneMode.Single);
    }

    public void OnApplicationQuit()
	{
		GameManager.instance = null;
	}

}
