using UnityEngine;

public class TriggerDoorFall : MonoBehaviour
{
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;

    [SerializeField] private float targetYPosition = -15f; // Y position where the doors will stop falling
    [SerializeField] private float fallSpeed = 2f;       // Speed of the fall

    private bool isFalling = false;
    private Vector3 door1StartPos;
    private Vector3 door2StartPos;
    private Vector3 door1TargetPos;
    private Vector3 door2TargetPos;

    private void Start()
    {
        // Save initial positions of the doors
        if (door1 != null)
        {
            door1StartPos = door1.transform.position;
            door1TargetPos = new Vector3(door1StartPos.x, targetYPosition, door1StartPos.z);
        }

        if (door2 != null)
        {
            door2StartPos = door2.transform.position;
            door2TargetPos = new Vector3(door2StartPos.x, targetYPosition, door2StartPos.z);
        }
    }

    private void Update()
    {
        if (isFalling)
        {
            // Animate the doors falling
            if (door1 != null)
            {
                door1.transform.position = Vector3.Lerp(door1.transform.position, door1TargetPos, fallSpeed * Time.deltaTime);
            }

            if (door2 != null)
            {
                door2.transform.position = Vector3.Lerp(door2.transform.position, door2TargetPos, fallSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Start the falling animation when triggered
        isFalling = true;
        Debug.Log("Trigger activated! Doors are falling.");
    }
}
