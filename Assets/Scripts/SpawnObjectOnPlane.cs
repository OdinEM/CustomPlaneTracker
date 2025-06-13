using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class SpawnObjectOnPlane : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private GameObject spawnedObject;

    [SerializeField]
    private GameObject placeablePrefab;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    private void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (raycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = s_Hits[0].pose;
            Vector3 raisedPosition = hitPose.position + new Vector3(0f, 0.05f, 0f); // Raise 5cm above the plane

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(placeablePrefab, raisedPosition, hitPose.rotation);
                Debug.Log("✅ Spawned object at: " + raisedPosition);
            }
            else
            {
                spawnedObject.transform.position = raisedPosition;
                spawnedObject.transform.rotation = hitPose.rotation;
                Debug.Log("↪️ Moved existing object to: " + raisedPosition);
            }
        }
        else
        {
            Debug.Log("❌ No plane hit");
        }
    }
}
