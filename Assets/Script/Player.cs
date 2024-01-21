using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int _points;
    private bool _policeStole;

    [SerializeField] Text _scoreUI;

    // Start is called before the first frame update
    void Awake()
    {
        _points = 0;
        _policeStole = false;
        _scoreUI = GameObject.FindGameObjectsWithTag("PlayerUI")[0].GetComponent<Text>();
        _scoreUI.text = "0";
    }

    void Update() {
        _scoreUI.text = _points.ToString();
    }

    public void addAmount(int amount) {
        if (!_policeStole) {
            _points += amount;
        }
        else
            _points += (amount * 2);
        print(_points);
    }

    public void addPolice() {
        _policeStole = true;
        _points *= 2;
    }
}
