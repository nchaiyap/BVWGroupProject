using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public static SoundEffect Instance {get; private set;}
    public AudioSource bgm;
    public AudioSource sfx;
    public AudioSource announce;
    public AudioClip stackingSound;
    public AudioClip nopeSound;
    public AudioClip brokenPlate;
    public AudioClip shakingTower;
    public AudioClip gameOver;
    public AudioClip kidsYeah;
    public AudioClip timerSound;
    public AudioClip backgroundMusic;
    public AudioClip endBackground;
    public float startingPitch = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        //random sounds bgm
        //AudioClip[] bgList= new AudioClip[]{backgroundMusic, endBackground}; 
        //bgm.clip = bgList[Random.Range(0,2)];
        //bgm.Play();
        //bgm.pitch = startingPitch;
    }

    // Update is called once per frame
    void Update()
    {
        //bg music
        //For Test coding
        /*
        if(Input.GetKey(KeyCode.Q))
        {
            bgm.Play();
            bgm.pitch = +4f;
        }

        if(Input.GetKey(KeyCode.W))
        {
            AudioClip[] sfxList= new AudioClip[]{stackingSound,nopeSound,shakingTower,brokenPlate}; 
            sfx.clip = sfxList[Random.Range(0,5)];
            sfx.Play();
        }

        if(Input.GetKey (KeyCode.E))
        {
            AudioClip[] announceList= new AudioClip[]{gameOver,kidsYeah,timerSound}; 
            announce.clip = announceList[Random.Range(0,4)];
            announce.Play();
        }
        */
    }
}
