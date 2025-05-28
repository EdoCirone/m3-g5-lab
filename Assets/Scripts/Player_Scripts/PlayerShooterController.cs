using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooterController : MonoBehaviour
{

    [SerializeField] float _fireRate; // Tempo tra i colpi
    [SerializeField] float _fireRange; // Distanza massima del colpo

    [SerializeField] GameObject bulletPrefab; // Prefab del proiettile

    private GameObject FindNearestEnemy()
    {
        // Trova il nemico più vicino

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {

                float distance = Vector2.Distance(transform.position, enemy.transform.position);

                if (distance <= _fireRange) // Controlla se il nemico è entro il raggio di fuoco
                {
                    nearestEnemy = 
                    return enemy; // Restituisce il primo nemico trovato entro il raggio
                }

            }

            return null; // Se non ci sono nemici, restituisce null
        }

    }

    private void Shoot()
    {
        GameObject nearestEnemy = FindNearestEnemy();

        if (nearestEnemy != null)
        {
        
            Instanziate bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= _nextFireTime)
        {
            Shoot();
            _nextFireTime = Time.time + _fireRate;
        }

    }
}
