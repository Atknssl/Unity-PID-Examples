using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followedObject;
    void Update()
    {
        if(followedObject.position.y>0)
        {
            gameObject.transform.position = new Vector3(0, followedObject.position.y, -10);
        }
    }
}
