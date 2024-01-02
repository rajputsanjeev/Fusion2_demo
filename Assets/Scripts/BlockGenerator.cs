using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class BlockGenerator : NetworkBehaviour
{
    [SerializeField] private BlockBehaviour blockBehaviour;

    [SerializeField] private float _minSpawnDelay = 5.0f;
    [SerializeField] private float _maxSpawnDelay = 10.0f;

    // The TickTimer controls the time lapse between spawns.
    [Networked] private TickTimer _spawnDelay { get; set; }

    public override void Spawned()
    {
        Debug.Log("Spawned");
        SetSpawnDelay();
    }

    public override void FixedUpdateNetwork()
    {
        Debug.Log("RemainingTime "+_spawnDelay.RemainingTime(Runner));
        base.FixedUpdateNetwork();
        if (Object.HasStateAuthority)
        {
            GenerateBlock();
        }
    }
    private void SetSpawnDelay()
    {
        // Chose a random amount of time until the next spawn.
        var time = Random.Range(_minSpawnDelay, _maxSpawnDelay);
        _spawnDelay = TickTimer.CreateFromSeconds(Runner, time);
    }

    private void GenerateBlock()
    {
        if (_spawnDelay.Expired(Runner))
        {
            Runner.Spawn(blockBehaviour, Vector3.zero, Quaternion.identity);

            SetSpawnDelay();
        }
           
    }
}
