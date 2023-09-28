using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] float rotationSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Assuming your character's forward direction is along the Z-axis.
        Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Check if there is any movement.
        if (movementDirection != Vector3.zero)
        {
            // Calculate the rotation angle based on the movement direction.
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection.normalized);

            // Smoothly rotate the character towards the target rotation.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move the character forward.
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
