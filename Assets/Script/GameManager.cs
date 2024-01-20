using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _parkingPrefab;
    [SerializeField] GameObject _playerPrefab;
    private Camera              _mCamera;
    private GameObject          _player;
    private GameObject          _parking;

    // Start is called before the first frame update
    void Start()
    {
        _player = Instantiate(_playerPrefab);
        _player.transform.position = new Vector3(20.5f, 5, 0);
        _parking = Instantiate(_parkingPrefab);
        _mCamera = Camera.main;
        _mCamera.transform.position = new Vector3(20.5f, 5, -10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
