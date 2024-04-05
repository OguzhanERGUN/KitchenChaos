using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{

	[SerializeField] private KitchenObjectsSO tomatoPrefab;
	[SerializeField] private Transform counterTopPoint;
	[SerializeField] private ClearCounter secondClearCounter;
	[SerializeField] private bool testing;



	private KitchenObject kitchenObject;

	private void Update()
	{
		if (testing && Input.GetKeyDown(KeyCode.T))
		{
			if (kitchenObject != null)
			{
				kitchenObject.SetClearCounter(secondClearCounter);
				Debug.Log(kitchenObject.GetClearCounter());

			}
		}
	}

	public void Interact()
	{
		if (kitchenObject == null)
		{
			Debug.Log("Interact something");
			Transform kitchenObjectTransform = Instantiate(tomatoPrefab.prefab, counterTopPoint);
			kitchenObjectTransform.localPosition = Vector3.zero;

			kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
			kitchenObject.SetClearCounter(this);
		}
		else
		{
			Debug.Log(kitchenObject.GetClearCounter());
		}

	}

	public Transform GetKitchenObjectFollowTransform()
	{
		return counterTopPoint;
	}


	public void SetKitchenObject(KitchenObject kitchenObject)
	{
		this.kitchenObject = kitchenObject;
	}

	public KitchenObject GetKitchenObject() { return kitchenObject; }

	public void ClearKitchenObject()
	{
		kitchenObject = null;
	}

	public bool HasKitchenObject()
	{
		return kitchenObject != null;
	}
}
