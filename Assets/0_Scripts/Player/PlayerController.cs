using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerModel playerModel;
    [SerializeField] InputActionReference moveAction;

    private void Awake()
    {
        if (TryGetComponent(out PlayerModel model))
        {
            playerModel = model;
        }
    }

    private void Update()
    {
        Vector2 direction = moveAction.action.ReadValue<Vector2>();
        playerModel.Move(direction);
    }
}
