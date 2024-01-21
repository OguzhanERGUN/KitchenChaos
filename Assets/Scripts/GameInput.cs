using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

	private PlayerInputActions inputActions;
	private void Awake()
	{
		inputActions = new PlayerInputActions();
		inputActions.Enable();
	}

	public Vector2 GetMovementVectorNormalized()
	{

		Vector2 inputVector = inputActions.Player.Move.ReadValue<Vector2>();

		Debug.Log(inputVector);
		inputVector = inputVector.normalized;

		return inputVector;
	}
}
