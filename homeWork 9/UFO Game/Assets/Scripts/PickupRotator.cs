﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotator : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
	{
		this.transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
	}
}