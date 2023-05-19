using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2.0f;

    private Rigidbody2D _playerRigidbody;
    private bool _isGrounded;

    private GameManager gameManager;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        if (_playerRigidbody == null)
        {
            Debug.LogError("Player is missing a Rigidbody2D component");
        }

        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        Vector3 viewportPosition = gameManager.mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.y < 0)
        {
            gameManager.LoseGame();
        }

        MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }

        ApplyFallMultiplier();
    }

    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);
    }

    private void Jump()
    {
        _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, jumpForce);
        _isGrounded = false;
    }

    private void ApplyFallMultiplier()
    {
        if (_playerRigidbody.velocity.y < 0)
        {
            _playerRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_playerRigidbody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            _playerRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }
}

