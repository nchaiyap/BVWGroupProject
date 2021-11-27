using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance {get; private set;}
    //public Rigidbody BoxRigid;
    public int score;
    public TMPro.TextMeshProUGUI txtScore;
    //GameController gameController;
    

    // Start is called before the first frame update
    void Start()
    {
        //score = 100;
        //gameController = (this.gameObject).GetComponent<GameController>();
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
        txtScore.text = "Score: " + score;

        //For Test method
        /*
        if (Input.GetKeyDown(KeyCode.A))
            AddScore(50);

        if (Input.GetKeyDown(KeyCode.B))
            RemoveScore(-100);

        if (Input.GetKeyDown(KeyCode.C))
            ResetScore(300);
        */

        if(score <= 0)
        {
            GameController.Instance.GameOver();
            //Debug.Log("Game Over");
        }

    }
    public void AddScore(int amount)
    {
        score += amount;
    }
    public void RemoveScore(int amount)
    {
        score -= amount;
    }
    public void ResetScore(int amount)
    {
        score = amount;
    }

}
