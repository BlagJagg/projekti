using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Speed of the player movement
    [SerializeField] private float playerSpeed = 5.0f;
    // The force of the jump
    [SerializeField] private float jumpForce = 5.0f;
    // Multiplier to apply when falling to make the fall faster
    [SerializeField] private float fallMultiplier = 2.5f;
    // Multiplier to apply when jumping and releasing the jump button to make the jump less high
    [SerializeField] private float lowJumpMultiplier = 2.0f;

    // Rigidbody component of the player
    private Rigidbody2D _playerRigidbody;
    // Whether the player is currently touching the ground or not
    private bool _isGrounded;

    private void Start()
    {
        // Get the Rigidbody component of the player and print an error message if it's missing
        _playerRigidbody = GetComponent<Rigidbody2D>();
        if (_playerRigidbody == null)
        {
            Debug.LogError("Player is missing a Rigidbody2D component");
        }
    }

    private void Update()
    {
        // Move the player horizontally
        MovePlayer();

        // Jump when the player presses the jump button and is touching the ground
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }

        // Apply the fall multiplier to the player's velocity when falling
        ApplyFallMultiplier();
    }

    private void MovePlayer()
    {
        // Get the horizontal input from the player and set the player's velocity accordingly
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);
    }

    private void Jump()
    {
        // Set the player's vertical velocity to the jump force and mark the player as not grounded
        _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, jumpForce);
        _isGrounded = false;
    }

    private void ApplyFallMultiplier()
    {
        // Apply the fall multiplier to the player's velocity when falling
        if (_playerRigidbody.velocity.y < 0)
        {
            _playerRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        // Apply the low jump multiplier to the player's velocity when jumping and releasing the jump button early
        else if (_playerRigidbody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            _playerRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Mark the player as grounded when colliding with an object tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Mark the player as not grounded when no longer colliding with an object tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}