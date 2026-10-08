using UnityEngine;

public class DinoScript : MonoBehaviour
{
    [SerializeField] private float jumpForce = 8.0f;
    private Rigidbody2D rigidBody2D;
    private AudioSource audioSource;
    private bool onGround;
    private bool jumping;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Use GetButtonDown to read the "Jump" input defined in the Input Manager
        if (Input.GetButtonDown("Jump") && onGround)
        {
            // mark as not on ground immediately to avoid double-jump while physics not updated
            onGround = false;
            audioSource.Play();
            jumping = true;
        }

    }

    private void FixedUpdate()
    {
        if (jumping == true)
        {
        rigidBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumping = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            onGround = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "cactus") 
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            onGround = false;
        }
    }
}
