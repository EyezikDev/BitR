using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    // Public Variables
    public float cubeSpeed;

    // Private Variables
    private float cubeTimer = 1.0f;
    private bool cubeDirection = true;

    /// 
    /// Update Called Once Per Frame
    /// 
    void FixedUpdate()
    {
        // If the direction is one way...
        if (cubeDirection == true)
        {
            // Move that way
            transform.Translate(1 * cubeSpeed, 0, 0);
        }
        // Else its the other way...
        else
        {
            // Move that way
            transform.Translate(-1 * cubeSpeed, 0, 0);
        }
        // Timer count down to swap sides
        cubeTimer = cubeTimer - Time.deltaTime;
        // If the timer hits 0...
        if (cubeTimer <= 0)
        {
            // Swap the directions and reset the timer
            cubeDirection = !cubeDirection;
            cubeTimer = 1.0f;
        }
    }
}
