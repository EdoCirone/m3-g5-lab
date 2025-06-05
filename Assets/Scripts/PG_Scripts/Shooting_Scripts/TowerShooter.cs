using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooter : PlayerShooterController
{



    private void Update()
    {


        if (CanShoot() && EnemyInRange(out Vector3 enemyDirection)) //Sparo solo se ci sono nemici in range
        {
            TryShoot(_spawnPoint.position, enemyDirection);// Prova a sparare nella direzione del nemico
        }
    }

    public override bool EnemyInRange(out Vector3 enemyDirection)
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            if (Vector3.Distance(_spawnPoint.position, enemy.transform.position) <= _range)
            {
               
                transform.rotation = Quaternion.LookRotation(Vector3.forward, enemy.transform.position - _spawnPoint.position);
                enemyDirection = (enemy.transform.position - _spawnPoint.position).normalized;
                return true;
            }
        }

        enemyDirection = Vector3.zero;
        return false;
    }
}



