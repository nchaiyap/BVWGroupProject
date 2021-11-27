using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackedTrigger : MonoBehaviour
{
    public int stackCount;
    public GameController gameController;
    Score scoreManager;
    
    // Start is called before the first frame update
    void Start()
    {
        stackCount=0;
        scoreManager = gameController.GetComponent<Score>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "goodTray")
        {
            //gameController.AddStackCount(1);
            //Debug.Log("stack count is "+gameController.stackCount);
            //stackCount = stackCount +1;
            scoreManager.AddScore(100);

        }
        
    }
}
