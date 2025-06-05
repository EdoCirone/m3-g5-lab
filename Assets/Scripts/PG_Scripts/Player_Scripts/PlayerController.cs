using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 _dir;

    Rigidbody2D _rb;

    [SerializeField] float _speed = 5f;

    void Update()
    {
        // Prendo gli input e li normalizzo se il vettore è più lungo di 1. Lo faccio in Update per evitare problemi di input multipli.
        _dir.x = Input.GetAxis("Horizontal");
        _dir.y = Input.GetAxis("Vertical");
        if (_dir.magnitude > 1f)
        {
            _dir.Normalize();
        }
    }

    void FixedUpdate()
    {
        //Muovo il personaggio in base alla direzione calcolata in Update. E aggiungo una velocità costante.
        _rb = GetComponent<Rigidbody2D>();
        _rb.MovePosition(_rb.position + _dir * _speed * Time.fixedDeltaTime);
    }
}