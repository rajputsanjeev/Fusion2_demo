using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Fusion;

public class CharacterController : NetworkBehaviour
{

    // Update is called once per frame
    public void Move(NetworkInputData networkInputData)
    {
        //Apply the rotation to the object's transform
        transform.rotation = networkInputData.rotatingDirection;

        //Move Player Toward direct
        transform.position = new Vector3(networkInputData.moveDirection.x, 30f, networkInputData.moveDirection.z);
    }
}

[System.Serializable]
public struct NetworkInputData : INetworkInput
{
    public Quaternion rotatingDirection;
    public Vector3 moveDirection;
}

