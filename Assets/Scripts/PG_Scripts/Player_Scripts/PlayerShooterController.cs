using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooterController : AbstractShooter
{
    [SerializeField] private Transform _spawnPoint;

    private void Update()
    {
        bool shoot = Input.GetButton("Fire1"); // Controlla se il giocatore ha premuto il tasto di sparo (Fire1 è solitamente il tasto sinistro del mouse o Ctrl sinistro)

        if (CanShoot() && shoot )
        {
            TryShoot(_spawnPoint.position, _spawnPoint.up);
        }
    }
}
