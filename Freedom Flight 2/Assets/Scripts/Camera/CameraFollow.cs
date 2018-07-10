using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private float distance_x;
    private float distance_y;
    public float distance_z;

    void Update()
    {
        Vector3 myTransform = transform.position;
        myTransform.z = target.position.z - distance_z;
        //myTransform.y = target.position.y - distance_y;
        //myTransform.x = target.position.x - distance_x;
        transform.position = myTransform;
    }
}
