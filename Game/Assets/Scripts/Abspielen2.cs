using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abspielen2 : MonoBehaviour
{
    public Animator anim;
    int wegOpfer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        gasExplosion();

    }


    public void gasExplosion()
    {
        anim.SetTrigger("Start");
        wegOpfer = 1;

    }

    public void explosionBeenden()
    {
        StartCoroutine(gasBeenden());
    }

    IEnumerator gasBeenden()
    {
        yield return new WaitForSeconds(1f);
        anim.SetInteger("AnfangsEntscheidung", wegOpfer);
    }



}
