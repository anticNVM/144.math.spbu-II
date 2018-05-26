using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	public GameObject _player;
	private Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		offset = this.transform.position - _player.transform.position;	
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		this.transform.position = _player.transform.position + offset;
	}
}
