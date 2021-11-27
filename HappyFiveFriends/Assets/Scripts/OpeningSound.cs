using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningSound : MonoBehaviour
{
    public AudioSource sfxOpen;
    public AudioClip click;

    public void Clickeffect()
    {
        sfxOpen.PlayOneShot(click);
    }
}
