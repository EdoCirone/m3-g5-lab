using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] int _damage = 10; // Danno del proiettile
    [SerializeField] float _speed = 10; // Velocità del proiettile
    [SerializeField] float _lifeTime = 5;

    public void Shoot(Vector3 origin, Vector3 direction)
    {
        transform.position = origin;

        Rigidbody2D rb = GetComponent<Rigidbody2D>(); // Ottieni il Rigidbody2D del proiettile


        Vector2 dir = direction;

        float squaredLenght = dir.sqrMagnitude;

        if (squaredLenght > 1)
        {

            dir /= Mathf.Sqrt(squaredLenght);// Normalizza la direzione
        }

        rb.velocity = dir * _speed; // Imposta la velocità del proiettile
    }



    void Start()
    {
        if (_lifeTime > 0)

        {
            Destroy(gameObject, _lifeTime); // Distrugge il proiettile dopo un certo tempo se _lifeTime è maggiore di 0
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        LifeController life = collision.gameObject.GetComponent<LifeController>(); // Ottieni il LifeController dell'enemy

        if (life != null || _lifeTime == 0)
        {
            life.AddHp(-_damage); // Rimuove 10 punti vita all'enemy quando il proiettile lo colpisce
        }

        Destroy(gameObject); // Distrugge il proiettile dopo aver colpito l'enemy
    }
}

