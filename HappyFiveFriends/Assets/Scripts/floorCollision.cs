using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorCollision : MonoBehaviour
{
    public GameController gameController; // linkage to Gamecontroller

    // Start is called before the first frame update
    void Start()
    {
        
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
            Debug.Log("collide!");
            gameController.GameOver();

        }
    }
}
