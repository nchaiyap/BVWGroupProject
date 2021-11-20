using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARKit;
using UnityEngine.XR.ARSubsystems;

public class GameSoundTest : MonoBehaviour
{

    public ARRaycastManager aRRaycastManager;
    public ARSessionOrigin arOrigin;
    public bool placementPoseIsValid = false;
    public GameObject placementIndicatorObject;
    //public Pose placementPose;
    public GameObject tray;
    public GameObject placementIndicatorObject;
    private bool trayIsEnabled = false;
    public AudioSource mkBG;
    public AudioSource gameOverSound;
    public AudioSource objectCollision;
    public AudioSource fallObject;
    public AudioSource brokenPlate;
    public AudioSource winSoundYeah;
    public AudioSource winSoundWow;
    public AudioSource shakingTower;
    public AudioSource timeIsUp;
    public AudioSource clickButton;

    // Start is called before the first frame update
    void Start()
    {
        mkBG.play();
        gameObject.GetComponent<Button>().onClick.AddListener(TurnOnAndOff);
        tray.SetActive(trayIsEnabled);
    }

    // Update is called once per frame
    void Update()
    {
        // get the position at the middle of screen
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();

        // shoot out the laser (RayCast) out of the middle of the screen
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinBounds);

        // if the laser hit with the detected planes, get the position and the rotation of where the laser hits
        placementPoseIsValid = hits.Count > 0;
        
        if (placementPoseIsValid) {
            // align (both position & rotation aka pose) the crosshair with the detected planes
            placementPose = hits[0].pose;
        }

        var cameraForward = Camera.current.transform.forward;
        var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
        placementPose.rotation = Quaternion.LookRotation(cameraBearing);

        // if there's a valid plane where the camera is pointing at, then we're going to show the placementIndicator and make it aligned with the plane
        // if not, then hide it
        
        if (placementPoseIsValid)
        {
            placementIndicatorObject.SetActive(true);
            placementIndicatorObject.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
            objectCollision.play();
        }
        else {
            placementIndicatorObject.SetActive(false);
            mkBG.stop();
            brokenPlate.play();
            gameOverSound.play();
            
        }

        // detected button pressed, then reposition the character as aligning it with the plane

    }
}