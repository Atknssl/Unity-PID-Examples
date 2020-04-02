using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float force = 50;
    public float throttle = 0;
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }
    public void CreateForce(float throttle)
    {
        this.throttle = throttle;
        if (this.throttle < 0) this.throttle = 0;
        if (this.throttle > 1) this.throttle = 1;
        _rb.AddRelativeForce(Vector2.up * force * this.throttle);
    }
}
