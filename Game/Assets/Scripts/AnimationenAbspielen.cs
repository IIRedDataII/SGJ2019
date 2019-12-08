using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationenAbspielen : MonoBehaviour
{
    Animator animMoerder;
    int wegMoerder, wegOpfer;
    public Abspielen2 mutter = new Abspielen2();


    // Start is called before the first frame update
    void Start()
    {
        animMoerder = GetComponent<Animator>();
        gasExplosion();
    }


    public void gasExplosion()
    {
        animMoerder.SetTrigger("Start");
        wegMoerder = 0;

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
            
            animMoerder.SetTrigger("GasExplosion/AlleTot2");
            mutter.explosionBeenden();
            //alles wird dunkel
        }
    }
}



