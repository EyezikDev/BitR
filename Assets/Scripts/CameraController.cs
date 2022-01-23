using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Public Variables
    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.2f;
    public float RotationSpeed = 5.0f;
    public bool LookAtPlayer = false;
    public bool RotateAroundPlayer = true;
    public GameObject player;

    // Private Variables
    private Vector3 offset;

    ///
    /// Update Called Before the First Frame
    /// 
    void Start()
    {
        // Create the off set based on the player position
        offset = transform.position - player.transform.position;
        // Currently rotating
        // Use this to change from constant rotation to allow a keypress to rotate
        RotateAroundPlayer = true;
    }

    /// 
    /// Update After Frame is Called
    /// 
    void LateUpdate()
    {
        // If currently rotating...
        // if(RotateAroundPlayer)
        // {
            // Create a camera turn angle based on the mouse x axis movement
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
            // Change the off set based on the camera turn angle
            offset = camTurnAngle * offset;
        // }
        // Create a new pos based on the new offset and the player
        // position then apply it to the camera transformer
        Vector3 newPos = player.transform.position + offset;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        // Make camera look at player
        transform.LookAt(player.transform);
    }
}
