using UnityEngine;

public class VacBrush : MonoBehaviour
{
    private float brushSpeed = 40f; //Degrees

    // Flag to track whether the player is currently moving
    private bool isPlayerMoving = false;

    void Start()
    {
        // Subscribe to the OnPlayerMove event
        Player.OnPlayerMove += () => isPlayerMoving = true;
        Player.OnPlayerStop += () => isPlayerMoving = false;
    }

    void FixedUpdate()
    {
        // Rotate the brushes if moving.
        if (isPlayerMoving)
        {
            transform.Rotate(0, brushSpeed, 0);
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe to the OnPlayerMove event
        Player.OnPlayerMove -= () => isPlayerMoving = true;
        Player.OnPlayerStop -= () => isPlayerMoving = false;
    }
}
