using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abspielen2 : MonoBehaviour
{
    public Animator anim;
    int wegOpfer;
    public AnimationenAbspielen moerder = new AnimationenAbspielen(); 

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        erschiessen();

    }

    public void erschiessen()
    {//falsch
        anim.SetTrigger("Start");
        anim.SetInteger("AnfangsEntscheidung", 3);
        wegOpfer = 4;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "knarre") {
            anim.SetTrigger("Erschiessen1");
            
        }


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
