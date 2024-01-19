using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
	private const string IS_WALKÝNG = "IsWalking";

	[SerializeField] private Player player;
	private Animator playerAnimator;

	private void Awake()
	{
		playerAnimator = GetComponent<Animator>();

	}

	private void Update()
	{
		playerAnimator.SetBool(IS_WALKÝNG,player.IsWalking());

	}
}
