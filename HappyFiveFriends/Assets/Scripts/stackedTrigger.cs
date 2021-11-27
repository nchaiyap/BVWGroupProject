using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackedTrigger : MonoBehaviour
{
    public int stackCount;
    public GameController gameController;
    
    
    // Start is called before the first frame update
    void Start()
    {
        stackCount=0;
        Score scoreManager = gameController.GetComponent<Score>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "goodTray")
        {
            //gameController.AddStackCount(1);
            //Debug.Log("stack count is "+gameController.stackCount);
            stackCount = stackCount +1;
            //scoreManager.AddScore(100);
            //collider.gameObject.tag = "stacked";

        }
        
    }
    */

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "badTray")
        {
            Debug.Log("collide Bad Tray");
            //scoreManager.RemoveScore(100);
            Score.Instance.RemoveScore(100);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "goodTray")
        {
            Debug.Log("collide Good tray");
            //scoreManager.AddScore(100);
            Score.Instance.AddScore(100);
            collision.gameObject.tag = "stacked";
        }

    }
    
}
