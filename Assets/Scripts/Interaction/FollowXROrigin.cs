using UnityEngine;

public class FollowXRCamera : MonoBehaviour
{
    [SerializeField] private Transform xrCamera; // Reference to the camera in the XR Origin

    private void Start()
    {
        // If xrCamera is not assigned, try to find it automatically
        if (xrCamera == null)
        {
            Camera mainCamera = Camera.main; // Assumes your XR camera is set as the main camera
            if (mainCamera != null)
            {
                xrCamera = mainCamera.transform;
            }
        }

        if (xrCamera == null)
        {
            Debug.LogError("XR Camera not found! Please assign it manually.");
        }
    }

    private void Update()
    {
        if (xrCamera != null)
        {
            // Keep this object's position aligned with the XR camera
            transform.position = xrCamera.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Triggered by: {other.gameObject.name}");
        // Add logic for trigger events here
    }
}
