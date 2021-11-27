using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
    public static GameController Instance {get; private set;}
    // Set up variable for coding
    public GameObject ctrlObj;  //{get; private set;} // First tray for controlling direction
    public GameObject trayPrefab; // Dropping tray for stacking
    public GameObject badTrayPrefab; // Dropping bad tray
    public GameObject placeMat; // Define floor
    bool isGameEnd = false;
    int trayStackCount;
    GameObject lastTray;
    public float timeRemaining = 30;
    public TMPro.TextMeshProUGUI remainingTime;
    public bool timeIsRunning = false;
    public Score scoreManager;

    public int stackCount; // Set up for stack count

    private float dragDistance; // Set up for touch control obj
    private Vector3 lastTouchPos;
    private Vector3 currentTouchPos;
    private int i;
    
    List<GameObject> stackedList = new List<GameObject>();

     

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Score.Instance.ResetScore(300);
        //Score.Instance.ResetScore(200);
        StartCoroutine(spawnTray());
        timeIsRunning = true;
        stackCount =0;
        dragDistance = Screen.width * 5 / 100;
        //var stackedList = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        ControllerObj(ctrlObj);
        //TouchControlObj(ctrlObj);
        if (timeIsRunning) {

            if(timeRemaining > 0) 
            {
                remainingTime.text = "Time Remaining: " + Mathf.FloorToInt(timeRemaining % 60);
                timeRemaining = timeRemaining - Time.deltaTime;
            } 
            else 
            {
                timeIsRunning = false;
                isGameEnd = true;
                remainingTime.text = "Time's UP!!";
            }
        }
        if(isGameEnd)
        {
            StopCoroutine(spawnTray());
            
            //SceneManager.LoadScene("End Scene",LoadSceneMode.Single);
            Invoke("LoadEndScene",2.0f);

        }
        
    }
    
    void ControllerObj(GameObject obj)
    {
        // Setup method for adding force to controlled obj
        Rigidbody rb;
        rb = obj.GetComponent<Rigidbody>();

        // Set speed for force
        float speed = 0.4f;

        // Add force by input axis
    
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        rb.AddForce(xInput*speed,0,zInput*speed,ForceMode.Impulse);

    }

    void TouchControlObj (GameObject obj)
    {
        Rigidbody rb;
        rb = obj.GetComponent<Rigidbody>();
        
        // for control obj by touch screen
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                lastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                currentTouchPos = lastTouchPos;
                float xInput = currentTouchPos.x;
                float zInput = currentTouchPos.z;
                rb.AddForce(xInput*dragDistance,0, zInput*dragDistance,ForceMode.Impulse);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                lastTouchPos = currentTouchPos = new Vector3();
            }
        }
    }

    IEnumerator spawnTray()
    {
        while (isGameEnd == false && trayStackCount < 10)
        {
            yield return new WaitForSeconds(4f);

            float pRand = 0.2f;  // Set Random for positioning dropping tray

            float randomX = Random.Range(-pRand,pRand);
            float randomZ = Random.Range(-pRand,pRand);
            Vector3 randomSpawnPos = new Vector3(randomX,6f,randomZ);
            GameObject[] trayArray  = new GameObject[] {trayPrefab,badTrayPrefab,trayPrefab};
            
            lastTray = Instantiate(trayArray[Random.Range(0,3)],randomSpawnPos,Quaternion.identity);
            stackedList.Add(lastTray) ;

        }
    }

    public void GameOver()
    {
        isGameEnd = true;
    }

    public void AddStackCount(int count)
    {
        stackCount = stackCount + count;
    }

    void LoadEndScene()
    {
        SceneManager.LoadScene("End Scene",LoadSceneMode.Single);
    }
}
