using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PhotonListener<T1> : MonoBehaviour
{
    public static new PhotonListener<T1> Instance;

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    protected virtual void OnEnable()
    {
    }

    protected virtual void OnDisable()
    {
    }

    public abstract void OnPhotonEventExecuted(T1 data);

}
