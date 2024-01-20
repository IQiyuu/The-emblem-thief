using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _points;
    private bool _policeStole;

    // Start is called before the first frame update
    void Start()
    {
        _points = 0;   
        _policeStole = false;
    }

    public void add_(int amount) {
        if (!_policeStole)
            _points += amount;
        else
            _points += (amount * 2);
    }
}
