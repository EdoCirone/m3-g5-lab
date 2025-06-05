using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooterController : AbstractShooter
{

    [SerializeField] protected float _range = 5f;

    [SerializeField] protected Transform _spawnPoint;

    Enemy[] enemies;

    private void Update()
    {
        bool shoot = Input.GetButton("Fire1"); // Controlla se il giocatore ha premuto il tasto di sparo (Fire1 è solitamente il tasto sinistro del mouse o Ctrl sinistro)

        if (CanShoot() && shoot && EnemyInRange(out Vector3 enemyDirection))
        {
            TryShoot(_spawnPoint.position, enemyDirection); 
        }
    }

    public virtual bool EnemyInRange(out Vector3 enemyDirection)
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
