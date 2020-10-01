using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallManager : MonoBehaviour
{
    public GameObject Ball;
    public  EventSystem EventSystem;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!EventSystem.current.IsPointerOverGameObject()) //Do not spawn ball if UI Element is clicked
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10.0f;
                Instantiate(Ball, Camera.main.ScreenToWorldPoint(mousePos), Quaternion.identity);
            }
        }
    }
}
