using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _screenBounds;
    public float lifeSpan = 10f;
    private float _timer;
    private void Start()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _timer += Time.deltaTime;
        if (-(_rb.position.y) > _screenBounds.y)
        {
            Destroy(this.gameObject);

        }
        if(_timer>lifeSpan)
        {
            Destroy(this.gameObject);
        }
    }
}
