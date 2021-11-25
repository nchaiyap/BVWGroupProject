using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMOpening : MonoBehaviour
{
    private static BGMOpening mkOpening;

    void Awake()
    {
        if(BGMOpening == null)
        {
            BGMOpening = this;
            dontDestroyOnLoad(BGMOpening);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
