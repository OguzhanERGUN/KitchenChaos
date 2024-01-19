using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	float moveSpeed = 7f;
	float roationSpeed = 10f;

	private bool isWalking;

	void Update()
    {

		Vector2 inputVector = new Vector2(0, 0);

		
		
		if (Input.GetKey(KeyCode.W))
        {
			inputVector.y = +1;
        }
		if (Input.GetKey(KeyCode.S))
		{
			inputVector.y = -1;
		}
		if (Input.GetKey(KeyCode.D))
		{
			inputVector.x = +1;
		}
		if (Input.GetKey(KeyCode.A))
		{
			inputVector.x = -1;
		}

		inputVector = inputVector.normalized;

		Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
		transform.position += moveDir * Time.deltaTime * moveSpeed;

		if (moveDir != Vector3.zero) { isWalking = true; }
		else { isWalking = false; }
		transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * roationSpeed);

		Debug.Log(inputVector);
	}

	public bool IsWalking()
	{
		return isWalking;
	}
}
