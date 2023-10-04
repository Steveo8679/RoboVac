using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody PlayerBody;
    [Space]
    [SerializeField] private float Speed = 0.6f;
    [SerializeField] private float rotationSpeed = 120f;

    private Vector3 PlayerMovementInput;

    // Define an event delegate for player movement
    public static event Action OnPlayerMove;
    public static event Action OnPlayerStop;

    void Update()
    {
        // Get player input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Create a normalized movement vector
        PlayerMovementInput = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Check for player movement and trigger events
        if (PlayerMovementInput.magnitude > 0.1f)
        {
            OnPlayerMove?.Invoke();
        }
        else
        {
            OnPlayerStop?.Invoke();
        }

        MovePlayer();
        
    }

    private void MovePlayer()
    {
        // Rotate the character based on keyboard input
        float rotationInput = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotationInput);

        // Move the character based on keyboard input
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.forward * verticalInput;
        PlayerBody.velocity = new Vector3(moveDirection.x, PlayerBody.velocity.y, moveDirection.z) * Speed;
    }

}
