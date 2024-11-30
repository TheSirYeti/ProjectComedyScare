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
    [SerializeField] CameraController _cameraController;

    private void Awake()
    {
        if (TryGetComponent(out Rigidbody rigidbody))
        {
            _rb = rigidbody;
        }
        else Debug.LogError("No Rigidbody on PlayerModel");
    }

    private void Update()
    {
        //transform.rotation = new Quaternion(transform.rotation.x, _cameraController.transform.rotation.y, transform.rotation.z, transform.rotation.w);
    }

    public void Move(Vector2 direction)
    {
        //Vector3 movement = new Vector3(direction.x, 0, direction.y);
        Vector3 movement = _cameraController.transform.right * direction.x + _cameraController.transform.forward * direction.y;
        
        if (movement != Vector3.zero)
        {
            _rb.AddForce(movement * _acceleration, ForceMode.Force);

            if (_rb.linearVelocity.magnitude > _maxSpeed)
            {
                _rb.linearVelocity = _rb.linearVelocity.normalized * _maxSpeed;
            }
        }
        else
        {
            _rb.AddForce(_rb.linearVelocity * - _deceleration, ForceMode.Force);
        }
    }
}
