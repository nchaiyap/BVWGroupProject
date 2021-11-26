using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Rigidbody BoxRigid;
    public int score;
    public TMPro.TextMeshProUGUI txtScore;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 300;
    }

    // Update is called once per frame
    void Update()
    {
        txtScore.text = "Score: " + score;
        if (Input.GetKeyDown(KeyCode.A))
            AddScore(50);

        if (Input.GetKeyDown(KeyCode.B))
            RemoveScore(-100);

        if (Input.GetKeyDown(KeyCode.C))
            ResetScore(300);

    }
    public void AddScore(int amount)
    {
        score += amount;
    }
    public void RemoveScore(int amount)
    {
        score -= -amount;
    }
    public void ResetScore(int amount)
    {
        score = 300;
    }

}
