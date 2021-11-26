using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackedTrigger : MonoBehaviour
{
    public int stackCount;
    
    // Start is called before the first frame update
    void Start()
    {
        stackCount=0;
        
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
            stackCount = stackCount +1;

        }
        
    }
}
