using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float force = 0;
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _rb.AddRelativeForce(Vector2.up*force);
    }
}
