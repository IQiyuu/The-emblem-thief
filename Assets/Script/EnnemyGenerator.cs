using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject _ennemyPrefab;
    [SerializeField] int        _size;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _size; i++)
            Instantiate(_ennemyPrefab);
    }
}
