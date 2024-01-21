using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private int _timeToSteal;
    [SerializeField] private bool _randomCar;
    [SerializeField] private bool _policeCar;
    private bool _stole = false;

    [SerializeField] Sprite _brokenSprite;

    void Start() {
        if (_randomCar)
            _value = Random.Range(0,500);
    }

    public void setStole() { 
        _stole = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = _brokenSprite;
    }
    public bool getStole() { return _stole; }

    public bool getPoliceCar() { return _policeCar; }

    public int getTimeToSteal() { return _timeToSteal; }

    public int getValue() { return _value; }
}
