using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationenAbspielen : MonoBehaviour
{
    Animator animOpfer;
    Animator animMoerder;
    int wegMoerder, wegOpfer;


    // Start is called before the first frame update
    void Start()
    {
        animOpfer = GetComponent<Animator>();
        animMoerder = GetComponent<Animator>();
        gasExplosion();
    }


    public void gasExplosion()
    {
        animMoerder.SetTrigger("Start");
        animOpfer.SetTrigger("Start");
        wegMoerder = 0;
        wegOpfer = 1;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "vorTuer" && wegMoerder == 0)
        {
            animMoerder.SetInteger("WegEntscheid", wegMoerder);
            //methode die tür öffnet
        }

        if(other.tag == "hinterLady" && wegMoerder == 0)
        {
            //animMoerder.SetInteger("testint", 3);
            animMoerder.SetTrigger("GasExplosion/AlleTot2");
            animOpfer.SetInteger("AnfangsEntscheidung", wegOpfer);
            //alles wird dunkel
        }
    }
}



