using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class SendInputHandler : NetworkBehaviour
{
    public float rotationSpeed = 10f;
    public float moveSpeed = 10f;

    public Vector3 rotationAxis = Vector3.up;
    public Quaternion rotatingDirection;
    public Vector3 moveDirection;

    // Update is called once per frame
    void Update()
    {
        if (!Object.HasInputAuthority)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Perform a raycast to determine the intersection point with the scene
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Calculate the direction from the object to the intersection point
            Vector3 direction = hit.point - transform.position;

            //Project the direction onto the desired rotation axis
            Vector3 projectedDirection = Vector3.ProjectOnPlane(direction, rotationAxis);

            // Use Quaternion.LookRotation to create a rotation towards the projected direction
            Quaternion rotation = Quaternion.LookRotation(projectedDirection, rotationAxis);

            // Apply the rotation to the object's transform
            rotatingDirection = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

            //Move Player Toward direct
            moveDirection += transform.forward * moveSpeed * Time.deltaTime;
        }
    }


    public NetworkInputData GetInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();
        networkInputData.moveDirection = moveDirection;
        networkInputData.rotatingDirection = rotatingDirection;
        return networkInputData;
    }
}
