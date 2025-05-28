using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 _dir;
    Rigidbody2D _rb;

    void Update()
    {
        _dir.x = Input.GetAxis("Horizontal");
        _dir.y = Input.GetAxis("Vertical");
        if (_dir.magnitude > 1f)
        {
            _dir.Normalize();
        }
    }

    void FixedUpdate()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.MovePosition(_rb.position + _dir * Time.fixedDeltaTime);
    }
}