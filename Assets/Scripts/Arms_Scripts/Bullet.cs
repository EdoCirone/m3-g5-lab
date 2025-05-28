using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed; // Velocità del proiettile
    public float Speed { get => _speed; set => _speed = value; }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // Distrugge l'enemy quando il proiettile lo colpisce
            Destroy(gameObject); // Distrugge il proiettile dopo aver colpito l'enemy
        }
    }
}

