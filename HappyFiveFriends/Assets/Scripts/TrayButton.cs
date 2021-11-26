using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrayButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tray;
    public GameObject placementIndicatorObject;
    private bool trayIsEnabled = false;
    public AudioSource mouseClicking;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TurnOnAndOff);
        tray.SetActive(trayIsEnabled);
    }

    public void TurnOnAndOff(){
        Debug.Log("TurnOnAndOff");
        if(!trayIsEnabled) {
            trayIsEnabled = true;
            mouseClicking.Play();
            tray.SetActive(trayIsEnabled);
        }
        tray.transform.position = new Vector3(placementIndicatorObject.transform.position.x, placementIndicatorObject.transform.position.y, placementIndicatorObject.transform.position.z);
        Debug.Log("tray.transform.position ->"+tray.transform.position);
        Debug.Log("indicatorObject.transform.position; ->" +placementIndicatorObject.transform.position);
    }
}