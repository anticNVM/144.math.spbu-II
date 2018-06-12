using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Игрок (объект, за которым следует камера)
    /// </summary>
    public GameObject _player;

    /// <summary>
    /// Вектор перемещения камеры
    /// </summary>
    private Vector3 _offset;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    public void Start()
    {
		_player = GameObject.FindGameObjectWithTag("Player");
        _offset = this.transform.position - _player.transform.position;
    }

    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    public void LateUpdate()
    {
        this.transform.position = _player.transform.position + _offset;
    }
}
