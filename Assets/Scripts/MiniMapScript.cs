using UnityEngine;

public class MiniMapScript : MonoBehaviour
{
    // Public Variables
    public Transform player;

    /// 
    /// Update After Frame is Called
    /// 
    void LateUpdate()
    {
        // Get current player pos
        Vector3 newPos = player.position;
        // Move the camera accordingly
        newPos.y = transform.position.y;
        transform.position = newPos;
    }
}
