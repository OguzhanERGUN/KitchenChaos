using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	float moveSpeed = 7f;
	float roationSpeed = 10f;
	float playerRadius = 0.7f;
	float playerHeight = 2.0f;
	float moveDistance;

	[SerializeField] private GameInput gameInput;
	[SerializeField] private LayerMask countersLayerMask;
	private bool isWalking;

	private Vector3 lastInteractDirection;


	private void Start()
	{
		gameInput.OnInteractAction += GameInput_OnInteractAction;
	}

	

	void Update()
	{
		HandleMovement();
		HandleInteractions();
	}

	public bool IsWalking()
	{
		return isWalking;
	}

	private void HandleInteractions()
	{

		Vector2 inputVector = gameInput.GetMovementVectorNormalized();

		Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

		if (moveDir != Vector3.zero)
		{
			lastInteractDirection = moveDir;
		}

		float interactDistance = 2f;

		if (Physics.Raycast(transform.position, lastInteractDirection, out RaycastHit raycastHit, interactDistance,countersLayerMask))
		{
			if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
			{
			}
		}
	}

	private void GameInput_OnInteractAction(object sender, System.EventArgs e)
	{
		Vector2 inputVector = gameInput.GetMovementVectorNormalized();

		Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

		if (moveDir != Vector3.zero)
		{
			lastInteractDirection = moveDir;
		}

		float interactDistance = 2f;

		if (Physics.Raycast(transform.position, lastInteractDirection, out RaycastHit raycastHit, interactDistance, countersLayerMask))
		{
			if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
			{
				clearCounter.Interact();
			}
		}
	}

	private void HandleMovement()
	{

		Vector2 inputVector = gameInput.GetMovementVectorNormalized();

		Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

		moveDistance = moveSpeed * Time.deltaTime;
		bool canMove = !Physics.CapsuleCast(transform.position,
			transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

		if (!canMove)
		{
			Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
			canMove = !Physics.CapsuleCast(transform.position,
			transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

			if (canMove)
			{
				moveDir = moveDirX;
			}
			else
			{
				Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
				canMove = !Physics.CapsuleCast(transform.position,
			transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

				if (canMove)
				{

					moveDir = moveDirZ;
				}

			}
		}
		if (canMove) transform.position += moveDir * Time.deltaTime * moveSpeed;

		if (moveDir != Vector3.zero) { isWalking = true; }
		else { isWalking = false; }

		transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * roationSpeed);

	}

}
