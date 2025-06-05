using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractShooter : MonoBehaviour
{


    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _shotInterval = 0.5f; // Intervallo tra i colpi

    private float _lastShotTimer = 0f; // Tempo trascorso dall'ultimo colpo

    public bool CanShoot()
    {
        return Time.time - _lastShotTimer >= _shotInterval;
    }

    public void TryShoot(Vector3 position, Vector3 direction)
    {
        if (!CanShoot()) return;

        Shoot(position, direction);

    }

    public void Shoot(Vector3 position, Vector3 direction)
    {
        _lastShotTimer = Time.time; // Aggiorna il timer dell'ultimo colpo
        Bullet b = Instantiate(_bulletPrefab);
        b.Shoot(position, direction);
    }


}
