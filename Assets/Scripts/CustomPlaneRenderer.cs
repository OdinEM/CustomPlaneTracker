using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]
public class CustomPlaneRenderer : MonoBehaviour
{
    [SerializeField] private Material customPlaneMaterial;
    private ARPlaneManager planeManager;
    private HashSet<ARPlane> updatedPlanes = new HashSet<ARPlane>();

    private void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
    }

    private void Update()
    {
        foreach (var plane in planeManager.trackables)
        {
            if (!updatedPlanes.Contains(plane))
            {
                ApplyCustomMaterial(plane);
                updatedPlanes.Add(plane);
            }
        }
    }

    private void ApplyCustomMaterial(ARPlane plane)
    {
        var renderer = plane.GetComponent<MeshRenderer>();
        if (renderer != null && customPlaneMaterial != null)
        {
            renderer.material = customPlaneMaterial;
        }
    }
}
