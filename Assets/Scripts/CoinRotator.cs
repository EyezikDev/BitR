using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    /// 
    /// Update Called Once Per Frame
    /// 
    void FixedUpdate()
    {
        // Rotate coin according to delta time
        transform.Rotate(new Vector3(0, 0, 120) * Time.deltaTime);
    }
}
