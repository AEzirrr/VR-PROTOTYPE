using UnityEngine;

public class CanvasToggleOnTrigger: MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;      // The panel or UI element to show/hide

    private void Start()
    {
        if (uiPanel == null)
        {
            Debug.LogError("UI Panel not assigned! Please assign it in the inspector.");
        }
        else
        {
            // Ensure the UI panel starts hidden
            uiPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has the "Collider" tag
        if (other.CompareTag("Collider"))
        {
            Debug.Log("Collider with 'Collider' tag detected. Showing UI.");
            if (uiPanel != null)
            {
                uiPanel.SetActive(true);
            }
            else
            {
                Debug.LogError("UI Panel is not assigned or is missing.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object has the "Collider" tag when it exits
        if (other.CompareTag("Collider"))
        {
            Debug.Log("Collider with 'Collider' tag left the trigger. Hiding UI.");
            if (uiPanel != null)
            {
                uiPanel.SetActive(false);
            }
        }
    }
}
