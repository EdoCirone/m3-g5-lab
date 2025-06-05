using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantShooter : AbstractShooter
{

    [SerializeField] private Transform _spawnPoint;

    private void Update()
    {
        if (CanShoot())
        {
            TryShoot(_spawnPoint.position, _spawnPoint.up);
        }
    }

}
