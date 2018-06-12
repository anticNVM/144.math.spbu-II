using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Тело игрока
    /// </summary>
    private Rigidbody2D _playersRB;

    /// <summary>
    /// Количество собранных пикапов на данный момент
    /// </summary>
    private int _count;

    /// <summary>
    /// Количество пикапов всего на карте в начале игры
    /// </summary>
	private int _amountOfPickups;

    /// <summary>
    /// Скорость игрока
    /// </summary>
    private float _speed = 10;

    /// <summary>
    /// Текст с текущим счетом
    /// </summary>
    public Text _scoreText;

    /// <summary>
    /// Текст при победе
    /// </summary>
	public Text _winText;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    public void Start()
    {
        _playersRB = GetComponent<Rigidbody2D>();
        _amountOfPickups = GameObject.FindGameObjectsWithTag("PickUp").Length;
    }

    /// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	public void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector2(moveHorizontal, moveVertical);

        _playersRB.AddForce(movement * _speed);
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            _count++;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        _scoreText.text = "Score: " + _count.ToString();
        if (_count >= _amountOfPickups)
        {
            _winText.text = "You Win!!!";
        }
    }
}
