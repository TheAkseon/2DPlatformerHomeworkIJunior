using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private LayerMask _wall;

    private Rigidbody2D _rigidbody2D;
    private Collider2D _triggerCollider;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _triggerCollider = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        Move();
        CheckMoveDirection();
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(_moveSpeed, _rigidbody2D.velocity.y);
    }

    private void CheckMoveDirection()
    {
        if(!_triggerCollider.IsTouchingLayers(_ground) || _triggerCollider.IsTouchingLayers(_wall))
        {
            Flip();
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        _moveSpeed *= -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
