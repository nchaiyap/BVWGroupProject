using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Set up variable for coding
    public GameObject ctrlObj; // First tray for controlling direction
    public GameObject trayPrefab; // Dropping tray for stacking
    bool isGameEnd = false;
    int trayStackCount;
    public float timeRemaining = 30;
    public TMPro.TextMeshProUGUI remainingTime;
    public bool timeIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnTray());
        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {

        ControllerObj(ctrlObj);

        if (timeIsRunning) {

            if(timeRemaining > 0) {
                remainingTime.text = "Time Remaining: " + Mathf.FloorToInt(timeRemaining % 60);
                timeRemaining = timeRemaining - Time.deltaTime;
            }
        }
        else {
            timeIsRunning = false;
            isGameEnd = true;
            StopCoroutine(spawnTray());
        }
    }
    
    void ControllerObj(GameObject obj)
    {
        // Setup method for adding force to controlled obj
        Rigidbody rb;
        rb = obj.GetComponent<Rigidbody>();

        // Set speed for force
        float speed = 0.5f;
        // Add force by input axis
    
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        rb.AddForce(xInput*speed,0,zInput*speed,ForceMode.Impulse);

    }

    IEnumerator spawnTray()
    {
        while (isGameEnd == false && trayStackCount < 10)
        {
            yield return new WaitForSeconds(3f);

            float pRand = 0.5f;  // Set Random for positioning dropping tray

            float randomX = Random.Range(-pRand,pRand);
            float randomZ = Random.Range(-pRand,pRand);
            Vector3 randomSpawnPos = new Vector3(randomX,4f,randomZ);

            Instantiate(trayPrefab,randomSpawnPos,Quaternion.identity);

        }
    }
}
