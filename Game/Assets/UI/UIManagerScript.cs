using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    public Animator dialog;
    public Animator settings;
    public Animator start;
    public Animator quit;
    public Animator explanation;

    public void openSettings()
    {
        settings.SetBool("isHidden", true);
        start.SetBool("isHidden", true);
        quit.SetBool("isHidden", true);
        dialog.SetBool("isHidden", false);
    }

    public void hideControlls()
    {
        settings.SetBool("isHidden", true);
        start.SetBool("isHidden", true);
        quit.SetBool("isHidden", true);
        dialog.SetBool("isHidden", true);
    }

    public void closeSettings()
    {
        settings.SetBool("isHidden", false);
        start.SetBool("isHidden", false);
        quit.SetBool("isHidden", false);
        dialog.SetBool("isHidden", true);
    }

    public void showExplanation()
    {
        explanation.SetBool("isHidden", false);
    }
}
