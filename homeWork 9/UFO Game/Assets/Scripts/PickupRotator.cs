using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotator : MonoBehaviour 
{
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	public void Update()
	{
		this.transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);		
	}
}
