using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [SerializeField] PathManager    _pathManager;
    [SerializeField] float          _speed;
    [SerializeField] AudioSource    _aggroSource;
    [SerializeField] AudioSource    _walkSource;
    [SerializeField] AudioClip      _runSound;
    [SerializeField] Transform      _player;
    [SerializeField] LayerMask    _layer;

    UnityEngine.AI.NavMeshAgent _agent;

    private Path _pathing;
    private Transform _nextStep;
    private int _index = 0;
    private bool _aggro = false;
    

    // Start is called before the first frame update
    void Awake()
    {
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _agent.updateRotation = false;
        _pathing = _pathManager.getRandomPath();
        transform.position = _pathing.getFirstWaypoint().position;
        _index = (_index + 1) % _pathing.getPathLength();
        _nextStep = _pathing.getNextWaypoint(_index);
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        if (!_aggro) {
            _player = GameObject.FindGameObjectsWithTag("Player")[0].gameObject.transform;
            Vector3 dir = _nextStep.position - transform.position;
            transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);

            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720f * Time.deltaTime);

            if (Vector3.Distance(transform.position, _nextStep.position) < 0.3f) {
                _index = (_index + 1) % _pathing.getPathLength();
                _nextStep = _pathing.getNextWaypoint(_index);
            }
        }
        else
            _agent.SetDestination(_player.position);
    }

    IEnumerator increaseSpeed() {
        while (true) {
            _speed++;
            yield return new WaitForSeconds(30);
        }

    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player" && !_aggro) {
            _player = collider.gameObject.transform;
            Vector2 player2d = new Vector2(_player.position.x, _player.position.y);
            Vector2 dir2d = player2d - new Vector2(transform.position.x, transform.position.y);
            RaycastHit2D hit = Physics2D.Raycast(player2d, dir2d, Vector3.Distance(_player.position, transform.position), _layer, 0, 0);

            if (hit.collider == null) {
                _aggro = true;
                StartCoroutine(increaseSpeed());
                _aggroSource.Play();
                _walkSource.clip = _runSound;
                _walkSource.Play();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.collider.tag == "Player") {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #elif UNITY_WEBPLAYER
            Application.OpenURL(webplayerQuitURL);
            #else
            Application.Quit();
            #endif
        }
    }
}
