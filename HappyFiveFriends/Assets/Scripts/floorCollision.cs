using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorCollision : MonoBehaviour
{
    public GameController gameController; // linkage to Gamecontroller
    Score scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = gameController.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Collider collider;
        if(collision.gameObject.tag == "goodTray" )
        {
            
            collision.transform.localScale =  collision.transform.localScale / 2;
            //Debug.Log("collide!");
            Destroy(collision.gameObject);
            scoreManager.RemoveScore(50);
            //gameController.GameOver();

        }
        else if(collision.gameObject.tag == "badTray")
        {
            collision.transform.localScale =  collision.transform.localScale / 2;
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "stacked")
        {
            //collision.transform.localScale =  collision.transform.localScale / 2;
            //Destroy(collision.gameObject);
            gameController.GameOver();
        }
    }
}
