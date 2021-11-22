using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Rigidbody BoxRigid;
    public int score;
    public TMPro.TextMeshProUGUI txtScore;
    private bool _onCollision;

    private enum platformStates
    {
        moving,
        dropping

    }
    private platformStates _currentPlatformState;

    // Start is called before the first frame update
    void Start()
    {
        score = 40;
    }
    private void OnCollisionEnter(Collision stacking)
    {
        if (stacking.gameObject.tag == "goodTray")
        {
            stacking.transform.parent = this.transform;
            Debug.Log("Hit");
            AddScore(1);
        }

        if (stacking.gameObject.tag == "badTray")
        {
            stacking.transform.parent = this.transform;
            Debug.Log("Hit");
            RemoveScore(1);    

        }

        Debug.Log("Hit Peace");
        //score++;
    }

    // Update is called once per frame
    void Update()
    {
        txtScore.text ="Score: " + score;
    }

    public void AddScore (int amount)
    {
        score += amount;
    }
    public void RemoveScore (int amount)
    {
        score -= 10-amount;
    }
}
