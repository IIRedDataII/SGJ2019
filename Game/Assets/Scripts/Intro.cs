using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public GameManager gameManager;
    public Image background;
    public Image newspaper;
    public Image explanation;
    public Text startButton;
    public Animator spin;
    public Animator begin;

    public Sprite fail;
    public Sprite warning;
    public Sprite kill;
    public Sprite scare;
    public Sprite disable;
    public Sprite door;
    public Sprite backgroundDark;

    bool shouldListen = false;
    bool hasShownNewspaper = false;

    void Awake ()
	{
        newspaper.CrossFadeAlpha(0, 0, true);
        Debug.Log("Woke Intro");
        if (!gameManager.inStartup) {
            conifgureNewspaper();
        }
        
	}
    void Start()
    {
        Debug.Log("Started Intro Script");
    }

    public void listen()
    {
        this.shouldListen = true;
    }

    public void openScene()
    {
        SceneManager.LoadScene("Scenes/Room 1", LoadSceneMode.Single);
    }
    void Update()
    {
        if (Input.anyKey && this.shouldListen && !this.hasShownNewspaper)
        {
               showNewspaper();
        }
    }

    private void showNewspaper()
    {
        Debug.Log("Show Newspaper");
        explanation.CrossFadeAlpha(0,0,true);
        background.CrossFadeAlpha((float)0.5, 0, true);
        newspaper.CrossFadeAlpha(1, 0, true);
        spin.Play("rotate", 0, 0);
        begin.Play("BeginButtonSlideIn", 0, 0);
        newspaper.enabled = true;
        hasShownNewspaper = true;
    }

    private void conifgureNewspaper()
    {
        switch (gameManager.exitState)
        {
            case ExitState.FAIL:
                Debug.Log("ExitState Fail");
                newspaper.sprite = fail;
                break;
            case ExitState.WARNING:
                Debug.Log("ExitState Warning");
                newspaper.sprite = warning;
                break;
            case ExitState.KILL:
                Debug.Log("ExitState Kill");
                newspaper.sprite = kill;
                break;
            case ExitState.SCARE:
                Debug.Log("ExitState Scare");
                newspaper.sprite = scare;
                break;
            case ExitState.DISABLE:
                Debug.Log("ExitState Disable");
                newspaper.sprite = disable;
                break;
            case ExitState.DOOR:
                Debug.Log("ExitState Door");
                newspaper.sprite = door;
                break;
        }
    }
}
