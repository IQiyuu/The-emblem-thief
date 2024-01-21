using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //what we are following
    public Transform target;
    //zeros out velocity
    Vector3 velocity = Vector3.zero;
    //time to follow target
    public float smoothTime = .15f;

    public Vector3 offset;

    // Update is called once per frame
    void Update ()
    {
        if (target == null)
            target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, -10);

    }
}

