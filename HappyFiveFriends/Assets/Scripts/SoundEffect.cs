using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    //Stackingsound will play when get good tray
    public AudioSource stackingSound;
    //Nope will play when get the bad tray
    public AudioSource nopeSound;
    //Brokenplate will play when all trays fall on the ground
    public AudioSource brokenPlate;
    //ShakingTowers will play when trays almost fall
    public AudioSource shakingTower;
    //GameOver will play when all plates fall down
    public AudioSource gameOver;
    //KidsYeah will play when you win
    public AudioSource kidsYeah;
    //TimerSound will play when time less than 10 seconds
    public AudioSource timerSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
