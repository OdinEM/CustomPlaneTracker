using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class TapToPlace : MonoBehaviour
{
    public GameObject objectToPlace;
    public ARRaycastManager raycastManager;

    private GameObject placedObject;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        // Only respond to one tap and if object hasn't been placed yet
        if (Input.touchCount > 0 && placedObject == null)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;

                    placedObject = Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
                }
            }
        }
    }
}
