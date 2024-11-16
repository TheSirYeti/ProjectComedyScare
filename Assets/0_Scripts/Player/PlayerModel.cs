using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private float _acceleration = 5f;
    [SerializeField] private float _deceleration = 5f;
    [SerializeField] private float _maxSpeed = 20f;
    
    Rigidbody _rb;

    private void Awake()
    {
        if (TryGetComponent(out Rigidbody rigidbody))
        {
            _rb = rigidbody;
        }
    }

    public void Move(Vector2 direction)
    {
        Vector3 movement = new Vector3(direction.x, 0, direction.y);
        
        if (movement != Vector3.zero)
        {
            _rb.AddForce(movement * _acceleration, ForceMode.Force);

            if (_rb.velocity.magnitude > _maxSpeed)
            {
                _rb.velocity = _rb.velocity.normalized * _maxSpeed;
            }
        }
        else
        {
            _rb.AddForce(_rb.velocity * -_deceleration, ForceMode.Force);
        }
    }
}
