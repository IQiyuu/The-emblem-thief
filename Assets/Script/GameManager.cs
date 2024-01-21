using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Path       _arroundPath;
    [SerializeField] GameObject _parkingPrefab;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _ennemyPrefab;
    [SerializeField] int        _ennemyNumber;
    private Camera              _mCamera;
    private GameObject          _parking;
    

    // Start is called before the first frame update
    void Start()
    {
        _player.transform.position = new Vector3(20.5f, 5, 0);
        _parking = Instantiate(_parkingPrefab);
        _mCamera = Camera.main;
        _mCamera.transform.position = new Vector3(20.5f, 5, -10);
        for (int i = 0; i < _ennemyNumber; i++)
            Instantiate(_ennemyPrefab);
        GameObject tmpEnnemy = Instantiate(_ennemyPrefab);
        int r = Random.Range(0,4);
        int r2;
        r2 = r;
        tmpEnnemy.GetComponent<Ennemy>()._index = r;
        tmpEnnemy.GetComponent<Ennemy>()._pathing = _arroundPath;
        tmpEnnemy.GetComponent<Ennemy>()._arroundEnnemy = true;
        tmpEnnemy.transform.position = _arroundPath.getNextWaypoint(r).position;
        if (r < 3)
            r++;
        else
            r = 0;
        tmpEnnemy.GetComponent<Ennemy>()._nextStep = _arroundPath.getNextWaypoint(r);
        r = Random.Range(0,4);
        tmpEnnemy = Instantiate(_ennemyPrefab);
        tmpEnnemy.GetComponent<Ennemy>()._pathing = _arroundPath;
        while (r == r2)
            r = Random.Range(0,4);
        tmpEnnemy.GetComponent<Ennemy>()._index = r;
        tmpEnnemy.GetComponent<Ennemy>()._arroundEnnemy = true;
        tmpEnnemy.transform.position = _arroundPath.getNextWaypoint(r).position;
        if (r < 3)
            r++;
        else
            r = 0;
        tmpEnnemy.GetComponent<Ennemy>()._nextStep = _arroundPath.getNextWaypoint(r);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
