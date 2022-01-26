using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Public Variables
    public float speed;
    public float jumpForce;
    public Vector3 checkPoint;
    public Camera mainCamera;
    public AudioClip coinSound;
    public GameObject doorway;
    public TextMeshProUGUI txtCoin;

    // Private Variables
    private int coins;
    private Collider playerCollider;
    private Rigidbody rb;
    private AudioSource audioSource;

    ///
    /// Update Called Before the First Frame
    /// 
    void Start()
    {
        // Make cursor invisib
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        // Assign Components of player
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        playerCollider = GetComponent<SphereCollider>();
    }

    ///
    /// Update Called Before Frame
    /// 
    private void Update()
    {
        // if it falls below -10 or if the R key is pressed...
        if (transform.position.y <= -10.0f || Input.GetKeyDown("r"))
        {
            // TP player back to checkPoint
            transform.position = checkPoint;
        }
        // If the Space key is pressed and the ball is on the ground...
        if (Input.GetKeyDown("space") && IsGrounded() && Time.timeScale != 0f)
        {
           // Add force upwards
           rb.AddForce(Vector3.up * jumpForce);
        }
    }

    /// 
    /// Update Called Once Per Frame
    /// 
    void FixedUpdate()
    {
        // Movement math and input
        // ...Forward and Backward
        Vector3 flatForwardBackward = new Vector3(mainCamera.transform.forward.x, 0, mainCamera.transform.forward.z).normalized;
        flatForwardBackward = flatForwardBackward * Input.GetAxisRaw("Vertical") * speed;
        // ...Left and Right
        Vector3 flatleftRight = new Vector3(mainCamera.transform.right.x, 0, mainCamera.transform.right.z).normalized;
        flatleftRight = flatleftRight * Input.GetAxisRaw("Horizontal") * speed;
        // Add the force to move
        rb.AddForce(flatForwardBackward + flatleftRight);
    }

    /// 
    /// Coin Trigger Activate Check
    /// 
    private void OnTriggerEnter(Collider coin)
    {
        // If the object has a Pickup tag...
        if (coin.gameObject.CompareTag("Pickup"))
        {
            // Make is disappear
            coin.gameObject.SetActive(false);
            // Play coin sound
            audioSource.PlayOneShot(coinSound, 1.0f);
            // Add to coin counter
            coins = coins + 1;
            // Change coin text in UI
            txtCoin.text = coins.ToString();
        }
        // If they have collected every coin in the first area...
        if (coins >= 24)
        {
            // Take down the door way
            GameObject.Destroy(doorway);
        }
    }

    ///
    /// Ground Check
    /// 
    private bool IsGrounded()
    {
        // Return a true or false weather the raycast touchs the ground
        return Physics.Raycast(transform.position, -Vector3.up, playerCollider.bounds.extents.y + 0.1f);
    }
}
