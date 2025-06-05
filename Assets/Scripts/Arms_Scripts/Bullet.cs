using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] int _damage = 10; // Danno del proiettile
    [SerializeField] float _speed = 10; // Velocità del proiettile
    [SerializeField] float _lifeTime = 5;



    void Update()
    {
        // Se il proiettile ha una vita limitata, decrementa il tempo di vita rimanente
        if (_lifeTime > 0)
        {
            _lifeTime -= Time.deltaTime;
            if (_lifeTime <= 0)
            {
                Destroy(gameObject); // Distrugge il proiettile se il tempo di vita è scaduto
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        LifeController life = collision.gameObject.GetComponent<LifeController>(); // Ottieni il LifeController dell'enemy

        if (life != null )
        {
            life.AddHp(-_damage); // Rimuove 10 punti vita all'enemy quando il proiettile lo colpisce
        }

        Destroy(gameObject); // Distrugge il proiettile dopo aver colpito l'enemy
    }

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

        transform.rotation = Quaternion.LookRotation(Vector3.forward, dir); // Ruota il proiettile nella direzione del tiro
    }

}

