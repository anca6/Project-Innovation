using System.Numerics;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    // Speed at which the object rotates automatically
    public float autoRotationSpeed = 30f;

    // Speed at which the object rotates when controlled by player
    public float playerRotationSpeed = 100f;

    // Flag to track if the player is interacting with the object
    private bool isPlayerInteracting = false;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInteracting)
        {
            // Rotate the object based on player input
            float rotationInput = Input.GetAxis("Vertical"); // Adjust axis as needed
            transform.Rotate(UnityEngine.Vector3.right, rotationInput * playerRotationSpeed * Time.deltaTime);
        }
        else
        {
            // Rotate the object automatically if player is not interacting
            transform.Rotate(UnityEngine.Vector3.up, autoRotationSpeed * Time.deltaTime);
        }
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player is interacting with the object
            isPlayerInteracting = true;
        }
    }

    // OnTriggerExit is called when the Collider other has stopped touching the trigger
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player is no longer interacting with the object
            isPlayerInteracting = false;
        }
    }
}
