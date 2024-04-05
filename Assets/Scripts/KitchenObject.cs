using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
	[SerializeField] private KitchenObjectsSO objectsSO;
	private ClearCounter clearCounter;


	public KitchenObjectsSO GetKitchenObjectsSO()
	{
		return objectsSO;
	}

	public void SetClearCounter(ClearCounter clearCounter)
	{
		if (this.clearCounter != null)
		{
			this.clearCounter.ClearKitchenObject();
		}
		this.clearCounter = clearCounter;
		clearCounter.SetKitchenObject(this);

		transform.parent =	clearCounter.GetKitchenObjectFollowTransform();
		transform.localPosition = Vector3.zero;	
	}

	public ClearCounter GetClearCounter()
	{
		return clearCounter;
	}


}
