using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstTrayTrigger : MonoBehaviour
{
    
    public GameController gameController;

    public int stackCount;
    Score scoreManager;


    // Start is called before the first frame update
    void Start()
    {
        stackCount = 0;
        scoreManager = gameController.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "stacked")
        {
            //gameController.AddStackCount(1);
            //Debug.Log("stack count is "+gameController.stackCount);
            stackCount +=1;
            

        }
        
    }



    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "goodTray")
        {
            SoundEffect.Instance.sfx.PlayOneShot(SoundEffect.Instance.kidsYeah);
            scoreManager.AddScore(100);
            //Score.Instance.AddScore(100);
            collision.gameObject.tag = "stacked";
        }
        else if (collision.gameObject.tag == "badTray")
        {
            SoundEffect.Instance.sfx.PlayOneShot(SoundEffect.Instance.nopeSound);
            scoreManager.RemoveScore(100);
            //Score.Instance.RemoveScore(100);
            collision.transform.localScale =  collision.transform.localScale / 2;
            Destroy(collision.gameObject);

        }
    }
}
