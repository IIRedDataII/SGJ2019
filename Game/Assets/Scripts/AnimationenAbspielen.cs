using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationenAbspielen : MonoBehaviour
{
    Animator animMoerder;
    int wegMoerder, wegOpfer;
    public Abspielen2 mutter;


    // Start is called before the first frame update
    void Start()
    {
        //mutter = new Abspielen2();
        animMoerder = GetComponent<Animator>();
    }

    public void abhauen()
    {
        animMoerder.SetTrigger("Start");
        wegMoerder = 1;
        

    }

    public void wehtun()
    {
        animMoerder.SetTrigger("Start");
        wegMoerder = 6;
    }

    public void schiessen()
    {
        animMoerder.SetTrigger("Start");
        wegMoerder = 5;
    }

    public void nichtReinkommen()
    {
        animMoerder.SetTrigger("Start");
        wegMoerder = 2;
        Debug.Log("startet schonmal, nichtkreinkommen");
    }


    public void gasExplosion()
    {
        Debug.Log(mutter);
        Debug.Log(mutter.anim);
        animMoerder.SetTrigger("Start");
        mutter.anim.SetTrigger("Start");
        wegMoerder = 0;
        Debug.Log("startet schlagen");

    }

    private void OnTriggerEnter(Collider other)
    {
        //mutter + kind sterben
        if (other.tag == "vorTuer" && (wegMoerder == 0 || wegMoerder == 5))
        {
            animMoerder.SetInteger("WegEntscheid", wegMoerder);
            //methode die tür öffnet
        }

        if(other.tag == "hinterLady" && wegMoerder == 0)
        {
            
            animMoerder.SetTrigger("GasExplosion/AlleTot2");
            Debug.Log("explosionbeenden wird gestartet");
            mutter.explosionBeenden();
            //alles wird dunkel
        }


        //Kommt nicht rein
        if(other.tag == "vorTuer" && wegMoerder == 2)
        {
            animMoerder.SetInteger("WegEntscheid", wegMoerder);
        }

        //rutscht aus
        if (other.tag == "ausgang" && wegMoerder == 1)
        {
            animMoerder.SetTrigger("AusrutschenWegrennen3");
            mutter.ausrutschenAusloesen();
        }


    }
}



