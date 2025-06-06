using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] float minDis = 3f;
    [SerializeField] float minPlayerDis = 8f;

    [SerializeField] int enemyNumbers = 10;
    [SerializeField] int enemySpawnRange = 10;

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] List<GameObject> enemyList = new List<GameObject>();

    void Start()
    {

        SpawnEnemies();// Spawno gli enemy all'inizio del gioco

    }

    void Update()
    {
        enemyList.RemoveAll(enemy => enemy == null); // Rimuove gli enemy null dalla lista

        if (enemyList.Count <= 0) // Se non ci sono pi� enemy nella lista, spawn nuovi enemy
        {
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()

    {
        int maxTry = 0; // Contatore per il numero di tentativi di spawn

        int i = 0;// Contatore per il numero di enemy spawnati

        while (i < enemyNumbers && maxTry < 100)
        {
            // Genera una posizione casuale per lo spawn degli enemy
            Vector2 spawnPosition = new Vector2(
                Random.Range(-enemySpawnRange, enemySpawnRange),
                Random.Range(-enemySpawnRange, enemySpawnRange)
            );
            // Controlla se la posizione � accettabile per lo spawn
            if (AcceptablePosition(spawnPosition))
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                enemyList.Add(enemy);
                i++;
            }
            // Incrementa il contatore dei tentativi
            maxTry++;

            if (maxTry == 100)
            {
                // Se sono stati fatti 100 tentativi senza successo, esce dal ciclo
                Debug.Log("C'abbiamo provato! ");
            }
        }
    }

   

    bool AcceptablePosition(Vector2 spawnPosition) // Controlla se la posizione di spawn � accettabile
    {
        foreach (GameObject precedentEnemy in enemyList)
        {
            float distance = Vector2.Distance(spawnPosition, precedentEnemy.transform.position);// Calcola la distanza tra la posizione di spawn e la posizione degli enemy gi� presenti
            float playerDistance = Vector2.Distance(spawnPosition, FindAnyObjectByType<PlayerController>().transform.position); // Calcola la distanza tra la posizione di spawn e la posizione del giocatore

            if (distance < minDis || playerDistance < minPlayerDis)//Confronta le distanze
            {
                return false;
            }
        }
        return true;
    }
}
