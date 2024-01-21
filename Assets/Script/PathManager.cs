using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField] Path[] _path;

    public Path getRandomPath() {
        return _path[Random.Range(0, _path.Length)];
    }
}
