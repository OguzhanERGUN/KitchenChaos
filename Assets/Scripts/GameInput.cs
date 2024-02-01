using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

	private PlayerInputActions inputActions;
	public event EventHandler OnInteractAction;

	private void Awake()
	{
		inputActions = new PlayerInputActions();
		inputActions.Enable();
		inputActions.Player.Interact.performed += Interract_performed;
	}

	private void Interract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		OnInteractAction?.Invoke(this, EventArgs.Empty);
	}

	public Vector2 GetMovementVectorNormalized()
	{

		Vector2 inputVector = inputActions.Player.Move.ReadValue<Vector2>();

		inputVector = inputVector.normalized;

		return inputVector;
	}
}
