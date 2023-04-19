using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _lengthPatrolZone = 3;
    [SerializeField] private float _moveSpeed = 1.0f;

    private bool _isFacingRight = false;
    private float _flipAngle = 180f;
    private float _moveDirection;

    private void Update()
    {
        Move();
        CheckMoveDirection();
    }

    private void Move()
    {
        _moveDirection = Mathf.Cos(Time.time * _moveSpeed) * _lengthPatrolZone;

        transform.position = new Vector3(_moveDirection, transform.position.y, transform.position.z);
    }

    private void CheckMoveDirection()
    {
        if(_moveDirection > 0 && !_isFacingRight)
        {
            Flip();
        }
        else if(_moveDirection < 0 && _isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(transform.position.x, _flipAngle, transform.position.z);
    }
}
