using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Transform _propellers;
    private float _propspeed;
    private float _propstate = Mathf.PI / 2;
    public float force = 50;
    public float throttle = 0;
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Propeller"))
                _propellers = child;
        }
    }
    private void Update()
    {
        _propellers.transform.localScale = new Vector3(Mathf.Sin(_propstate), 1, 1); //Propeller Animation
        _propspeed = throttle / 5; //Propeller Animation
        _propstate += _propspeed; //Propeller Animation
    }
    public void CreateForce(float throttle)
    {
        this.throttle = throttle;
        this.throttle = Mathf.Clamp(this.throttle, 0, 1);
        _rb.AddRelativeForce(Vector2.up * force * this.throttle);
    }
}
