using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Rigidbody BoxRigid;
    public int score;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnCollisionEnter(Collision stacking)
    {
        if (stacking.gameObject.tag == "goodTray")
        {
            stacking.transform.parent = this.transform;
            Debug.Log("Hit");
            score++;
        }
        Debug.Log("Hit");
        //score++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
