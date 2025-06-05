using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] PlayerController _player;
    [SerializeField] float _enemySpeed = 2f; // Velocità dell'enemy


    void Awake()
    {
        _player = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        EnemyMovement(); // Muovo il nemico verso il giocatore
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           collision.gameObject.GetComponent<LifeController>().RemoveHp(10); // Rimuove 10 punti vita al giocatore quando l'enemy lo colpisce
        }
    }

    void EnemyMovement()
    {
        if (_player != null)
        {
            // Calcola la direzione verso il giocatore
            Vector2 direction = (_player.transform.position - transform.position).normalized;
            // Muovi l'enemy nella direzione del giocatore
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _enemySpeed * Time.deltaTime);
        }
    }
}
