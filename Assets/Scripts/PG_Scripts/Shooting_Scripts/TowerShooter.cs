using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooter : AbstractShooter
{

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _range = 5f;
    Enemy[] enemies;

    private void Update()
    {


        if (CanShoot() && EnemyInRange(out Vector3 enemyDirection)) //Sparo solo se ci sono nemici in range
        {
            TryShoot(_spawnPoint.position, enemyDirection);// Prova a sparare nella direzione del nemico
        }
    }

    public bool EnemyInRange(out Vector3 enemyDirection)
    {

        enemies = FindObjectsOfType<Enemy>();// Trova tutti gli oggetti di tipo Enemy nella scena

        foreach (Enemy enemy in enemies)
        {
            if (Vector3.Distance(_spawnPoint.position, enemy.transform.position) <= _range)// Controlla se il nemico è entro il range
            {
                enemyDirection = (enemy.transform.position - _spawnPoint.position).normalized;// Calcola la direzione verso il nemico e la restituisce al metodo TryShoot
                return true;
            }
        }

        enemyDirection = Vector3.zero; // Se non ci sono nemici in range, restituisci un vettore nullo
        return false;

    }

}
