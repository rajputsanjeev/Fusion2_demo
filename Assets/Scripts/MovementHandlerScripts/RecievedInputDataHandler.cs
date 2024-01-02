using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class RecievedInputDataHandler : NetworkBehaviour
{
    public CharacterController rotateTowardMouse;

    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();

        if (GetInput(out NetworkInputData networkInputData))
        {
            rotateTowardMouse.Move(networkInputData);
        }
    }
}
