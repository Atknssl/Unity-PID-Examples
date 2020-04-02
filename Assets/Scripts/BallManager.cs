using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject Ball;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10.0f;
            Instantiate(Ball, Camera.main.ScreenToWorldPoint(mousePos), Quaternion.identity);
        }
    }
}
