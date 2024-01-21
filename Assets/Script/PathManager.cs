using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField] Path[] _path;

    public Path getRandomPath() {
        int r = Random.Range(0, _path.Length);
        while (_path[r] == null)
            r = Random.Range(0, _path.Length);
        Path tmp = _path[r];
        _path[r] = null;
        return tmp;
    }
}
