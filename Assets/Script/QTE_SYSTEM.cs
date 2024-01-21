using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE_SYSTEM : MonoBehaviour
{
	[SerializeField] Text 		_letterBox;
	[SerializeField] Text		_msgBox;
	[SerializeField] Player 	_player;
	[SerializeField] float 		_time;
	[SerializeField] AudioSource _soundSource;
	[SerializeField] AudioClip	_inProgressSound;
	[SerializeField] AudioClip	_failSound;
	[SerializeField] AudioClip	_successSound;

	private int 	_qteGen = 0;
	private int 	_correctKey = 0;
	private int 	_countingDown = 0;
	private int 	_cooldown = 0;
	private int 	_keyCounter = 0;
	private Car 	_actualCar = null;
	private bool 	_waitingForKey = true;
	private bool 	_activated = false;
	private bool 	_forceExit = true;

	public void Start()
	{
		_player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>();
		_letterBox = GameObject.FindGameObjectsWithTag("CarUI")[1].GetComponent<Text>();
		_msgBox = GameObject.FindGameObjectsWithTag("CarUI")[0].GetComponent<Text>();
	}

	IEnumerator sleep(float tts) {
		_letterBox.text = "";
		_soundSource.Play();
		yield return new WaitForSeconds(tts);
		_activated = true;
	}

	public void LaunchQTE(Car car)
	{
		_forceExit = false;
		_waitingForKey = false;
		_correctKey = 0;
		_keyCounter = 0;
		_actualCar = car;
		_soundSource.clip = _inProgressSound;
	}

	public void ExitQTE(Car car)
	{
		_msgBox.text = "";
		_letterBox.text = "";
		_forceExit = true;
		_activated = false;
		if (_cooldown == 0 && _activated)
			StartCoroutine(Cooldown());
		_keyCounter = 0;
		_soundSource.Stop();
	}

	IEnumerator Cooldown() {
		_cooldown = 5;
		while (_cooldown > 0) {
			if (!_forceExit && _actualCar && !_actualCar.getStole())
				_msgBox.text = "Cooldown: " + _cooldown + "s";
			else
				_msgBox.text = "";
			yield return new WaitForSeconds(1);
			_cooldown--;
		}
	}

	void Update()
	{
		if (!_activated && !_forceExit) {
			if (!_actualCar.getStole()) {
				_letterBox.text = "R to steal";
				if (Input.GetKeyDown(KeyCode.R))
					StartCoroutine(sleep(1));
			}
			else
				_letterBox.text = "already stolen";
		}
		else if (_activated) {
			if (_actualCar && !_actualCar.getStole() && _keyCounter == _actualCar.getTimeToSteal()) {
				if (_actualCar.getPoliceCar())
					_player.addPolice();
				else
					_player.addAmount(_actualCar.getValue());
				_actualCar.setStole();
				_soundSource.Stop();
				_soundSource.clip = _successSound;
				_soundSource.loop = false;
				_soundSource.Play();
				//Destroy(gameObject);
			}
			if (!_waitingForKey && !_forceExit && _cooldown == 0 
				&& _actualCar && !_actualCar.getStole() && _keyCounter < _actualCar.getTimeToSteal())
			{
				_qteGen = Random.Range (1, 4);
				_countingDown = 1;
				StartCoroutine(CountDown ());
				if (_qteGen == 1)
				{
					_waitingForKey = true;
					_letterBox.text = "[A]";
				}
				if (_qteGen == 2)
				{
					_waitingForKey = true;
					_letterBox.text = "[T]";
				}
				if (_qteGen == 3)
				{
					_waitingForKey = true;
					_letterBox.text = "[E]";
				}
			}
			if (_qteGen == 1)
			{
				if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.W))
				{
					if (Input.GetButtonDown ("AKey"))
					{
						_correctKey = 1;
						StartCoroutine (KeyPressing ());
					}
					else
					{
						_correctKey = 2;
						StartCoroutine (KeyPressing ());
					}
				}
			}
			if (_qteGen == 2)
			{
				if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.W))
				{
					if (Input.GetButtonDown ("TKey"))
					{
						_correctKey = 1;
						StartCoroutine (KeyPressing ());
					}
					else
					{
						_correctKey = 2;
						StartCoroutine (KeyPressing ());
					}
				}
			}
			if (_qteGen == 3)
			{
				if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.W))
				{
					if (Input.GetButtonDown ("EKey"))
					{
						_correctKey = 1;
						StartCoroutine (KeyPressing ());
					}
					else
					{
						_correctKey = 2;
						StartCoroutine (KeyPressing ());
					}
				}
			}
		}
	}
	IEnumerator KeyPressing()
	{
		_qteGen = 4;
		if (_correctKey == 1 && !_forceExit)
		{
			_countingDown = 2;
			_msgBox.text = "PASS!";
			_keyCounter++;
			yield return new WaitForSeconds (_time);
			_correctKey = 0;
			_msgBox.text = "";
			_letterBox.text = "";
			yield return new WaitForSeconds (_time);
			_waitingForKey = false;
		}
		if (_correctKey == 2 && !_forceExit)
		{
			_countingDown = 2;
			_msgBox.text = "FAIL!!!!!!!";
			_soundSource.clip = _failSound;
			_soundSource.loop = false;
			_soundSource.Play();
			yield return new WaitForSeconds (_time);
			_correctKey = 0;
			_msgBox.text = "";
			_letterBox.text = "";
			yield return new WaitForSeconds (_time);
			_waitingForKey = false;
			_countingDown = 1;
			_keyCounter = 0;
			StartCoroutine(Cooldown());
		}
	}

	IEnumerator CountDown()
	{
		if (!_forceExit)
			yield return new WaitForSeconds(_time * 2);
		if (_countingDown == 1 && !_forceExit)
		{
			_qteGen = 4;
			_countingDown = 2;
			_msgBox.text = "FAIL!!!!!!!";
			_soundSource.clip = _failSound;
			_soundSource.loop = false;
			_soundSource.Play();
			yield return new WaitForSeconds (_time);
			_correctKey = 0;
			_msgBox.text = "";
			_letterBox.text = "";
			yield return new WaitForSeconds (_time);
			_waitingForKey = false;
			_countingDown = 1;
			_keyCounter = 0;
			StartCoroutine(Cooldown());
		}
	}
}
