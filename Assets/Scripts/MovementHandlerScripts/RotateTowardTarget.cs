
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardTarget : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float moveSpeed = 10f;

    public Vector3 rotationAxis = Vector3.forward;
    public bool shouldMove;
    public Transform target;

    protected void Update()
    {
            // Calculate the direction from the object to the intersection point
            Vector3 direction = target.position - transform.position;

            //Project the direction onto the desired rotation axis
            Vector3 projectedDirection = Vector3.ProjectOnPlane(direction, rotationAxis);

            // Use Quaternion.LookRotation to create a rotation towards the projected direction
            Quaternion rotation = Quaternion.LookRotation(projectedDirection, rotationAxis);

        // Apply the rotation to the object's transform
        //transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0,0,rotation.z), Time.deltaTime * rotationSpeed);
        transform.up = direction;

    }
}
