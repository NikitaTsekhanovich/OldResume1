using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // public float dumping = 2f;
    // [SerializeField] float leftLimit;
    // [SerializeField] float rightLimit;
    // [SerializeField] float bottomLimit;
    // [SerializeField] float upperLimit;
    // public Vector3 offset;
    public Transform target;
    private Vector3 _position;

    void Start()
    {
        _position = target.InverseTransformPoint(transform.position);
        // CameraFollowsPlayer();
    }
    void Update()
    {
        var currentPosition = target.TransformPoint(_position);
        transform.position = currentPosition;
        transform.LookAt(target);
    }
    private void CameraFollowsPlayer()
    {
        // transform.position = new Vector3(
        //     playerTransform.position.x + offset.x, 
        //     playerTransform.position.y + offset.y + 2, 
        //     playerTransform.position.z + offset.z);
        // transform.Rotate(0, 0,0);
        // поворот на 360 playerTransform.position.z + offset.z
        // изменять в пределах [-9;9], а transform.Rotate(0, 180,0);
    }
}
