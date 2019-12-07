using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public GameManager gameManager;

    void Awake()
    {
        Debug.Log("Awake Play");
    }
    void Start()
    {
        Debug.Log("Started Play");
    }
}
