using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARKit;
//using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARSubsystems;

public class PlacematIndicator : MonoBehaviour
{

    public ARRaycastManager aRRaycastManager;
    public ARSessionOrigin arOrigin;
    public bool placementPoseIsValid = false;
    public GameObject placementIndicatorObject;
    public Pose placementPose;

    // Start is called before the first frame update
    void Start()
    {
        
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
            GameController.Instance.placematPose = placementPose;
            GameController.Instance.isPlacematFound = true;
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
        }
        else {
            placementIndicatorObject.SetActive(false);
        }

        // detected button pressed, then reposition the character as aligning it with the plane

    }
}
