using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private float _gravityForce;
    [SerializeField] private GroundCheckPoint _groundCheckPoint;
    [SerializeField] LayerMask _groundLayer;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private float _minMoveSpeed = 0.1f;
    private float _flipAngle = 180f;
    private bool _isGrounded = true;
    private bool _isFacingRight = false;
    private bool _isJumpKeyPressed = false;

    private const string HorizontalAxis = "Horizontal";
    private const string IsGrounded = "IsGrounded";
    private const string Speed = "Speed";

    private void Start()
    {
        _groundCheckPoint = GetComponentInChildren<GroundCheckPoint>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _rigidbody2D.gravityScale = 1.0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumpKeyPressed = true;
        }
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis(HorizontalAxis);

        Animate(horizontalInput);
        AddGravityForce();
        CheckGround();
        Move(horizontalInput);
        CheckMoveDirection(horizontalInput);

        if (_isJumpKeyPressed)
        {
            Jump(horizontalInput);
            _isJumpKeyPressed = false;
        }
    }

    private void AddGravityForce()
    {
        _rigidbody2D.AddForce(Vector2.down * _gravityForce);
    }

    private void Move(float horizontalInput)
    {
        _rigidbody2D.velocity = new Vector2(horizontalInput * _moveSpeed, _rigidbody2D.velocity.y);
    }

    private void Jump(float horizontalInput)
    {
        if (_isGrounded)
        {
            if (Mathf.Abs(_rigidbody2D.velocity.x) < _minMoveSpeed)
            {
                _rigidbody2D.AddForce(new Vector2(_rigidbody2D.velocity.x, _jumpForce), ForceMode2D.Impulse);
            }
            else if (Mathf.Sign(_rigidbody2D.velocity.x) == Mathf.Sign(horizontalInput))
            {
                _rigidbody2D.AddForce(new Vector2(_rigidbody2D.velocity.x, _jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    private void CheckGround()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheckPoint.transform.position, _groundCheckRadius, _groundLayer);
    }

    private void CheckMoveDirection(float horizontalInput)
    {
        if(horizontalInput > 0 && !_isFacingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && _isFacingRight)
        {
            Flip();
        }
    }

    private void Animate(float horizontalInput)
    {
        _animator.SetBool(IsGrounded, _isGrounded);
        _animator.SetFloat(Speed, Mathf.Abs(horizontalInput));
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(transform.position.x, _flipAngle, transform.position.z);
    }
}
