using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE_SYSTEM : MonoBehaviour
{
	public GameObject DisplayBox;
	public GameObject PassBox;
	public int QTEGen;
	public int WaitingForKey = 1;
	public int CorrectKey;
	public int CountingDown;
	public float Time;
	public int ForceExit = 0;

	public void LaunchQTE(GameObject Car)
	{
		CountingDown = 0;
		WaitingForKey = 0;
		ForceExit = 0;
		CorrectKey = 0;
	}

	public void ExitQTE(GameObject Car)
	{
		PassBox.GetComponent<Text> ().text = "";
		DisplayBox.GetComponent<Text> ().text = "";
		ForceExit = 1;
	}

	void Update()
	{
		if (WaitingForKey == 0 && ForceExit == 0)
		{
			QTEGen = Random.Range (1, 4);
			CountingDown = 1;
			StartCoroutine(CountDown ());
			if (QTEGen == 1)
			{
				WaitingForKey = 1;
				DisplayBox.GetComponent<Text> ().text = "[A]";
			}
			if (QTEGen == 2)
			{
				WaitingForKey = 1;
				DisplayBox.GetComponent<Text> ().text = "[T]";
			}
			if (QTEGen == 3)
			{
				WaitingForKey = 1;
				DisplayBox.GetComponent<Text> ().text = "[E]";
			}
		}
		if (QTEGen == 1)
		{
			if (Input.anyKeyDown)
			{
				if (Input.GetButtonDown ("AKey"))
				{
					CorrectKey = 1;
					StartCoroutine (KeyPressing ());
				}
				else
				{
					CorrectKey = 2;
					StartCoroutine (KeyPressing ());
				}
			}
		}
		if (QTEGen == 2)
		{
			if (Input.anyKeyDown)
			{
				if (Input.GetButtonDown ("TKey"))
				{
					CorrectKey = 1;
					StartCoroutine (KeyPressing ());
				}
				else
				{
					CorrectKey = 2;
					StartCoroutine (KeyPressing ());
				}
			}
		}
		if (QTEGen == 3)
		{
			if (Input.anyKeyDown)
			{
				if (Input.GetButtonDown ("EKey"))
				{
					CorrectKey = 1;
					StartCoroutine (KeyPressing ());
				}
				else
				{
					CorrectKey = 2;
					StartCoroutine (KeyPressing ());
				}
			}
		}
	}
	IEnumerator KeyPressing()
	{
		QTEGen = 4;
		if (CorrectKey == 1 && ForceExit == 0)
		{
			CountingDown = 2;
			PassBox.GetComponent<Text> ().text = "PASS!";
			yield return new WaitForSeconds (Time);
			CorrectKey = 0;
			PassBox.GetComponent<Text> ().text = "";
			DisplayBox.GetComponent<Text> ().text = "";
			yield return new WaitForSeconds (Time);
			WaitingForKey = 0;
			CountingDown = 1;
		}
		if (CorrectKey == 2 && ForceExit == 0)
		{
			CountingDown = 2;
			PassBox.GetComponent<Text> ().text = "FAIL!!!!!!!";
			yield return new WaitForSeconds (Time);
			CorrectKey = 0;
			PassBox.GetComponent<Text> ().text = "";
			DisplayBox.GetComponent<Text> ().text = "";
			yield return new WaitForSeconds (Time);
			WaitingForKey = 0;
			CountingDown = 1;
		}
	}

	IEnumerator CountDown()
	{
		if (ForceExit == 0)
			yield return new WaitForSeconds(3.5f);
		if (CountingDown == 1 && ForceExit == 0)
		{
			QTEGen = 4;
			CountingDown = 2;
			PassBox.GetComponent<Text> ().text = "FAIL!!!!!!!";
			yield return new WaitForSeconds (Time);
			CorrectKey = 0;
			PassBox.GetComponent<Text> ().text = "";
			DisplayBox.GetComponent<Text> ().text = "";
			yield return new WaitForSeconds (Time);
			WaitingForKey = 0;
			CountingDown = 1;
		}
	}
}
