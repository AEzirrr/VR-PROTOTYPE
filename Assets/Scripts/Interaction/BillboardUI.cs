using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    [SerializeField] private Transform targetCamera; // Reference to the player's camera

    private void Start()
    {
        // Automatically find the main camera if not assigned
        if (targetCamera == null)
        {
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                targetCamera = mainCamera.transform;
            }
        }

        if (targetCamera == null)
        {
            Debug.LogError("Target Camera not found! Please assign it in the inspector.");
        }
    }

    private void Update()
    {
        if (targetCamera != null)
        {
            // Get the direction from the canvas to the camera
            Vector3 direction = targetCamera.position - transform.position;

            // Make the canvas face the camera (invert the direction for correct orientation)
            transform.rotation = Quaternion.LookRotation(-direction);

            // Optional: Lock the rotation to avoid tilting (comment out if you don't want this)
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
    }
}
