using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaetschelnAnimation : MonoBehaviour
{

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            anim.SetInteger("Timer", 2);//2 bel. Wert
        }
        else {
            anim.SetInteger("Timer", 2);
        }
    }
}
