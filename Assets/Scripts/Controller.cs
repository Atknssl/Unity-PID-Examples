using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Motor rightMotor;
    public Motor leftMotor;
    public PID pid;
    public float baseForce = 20;
    private float pidForce;
    void Update()
    {
        pidForce = pid.Update(0, gameObject.transform.rotation.z, Time.deltaTime)*100;
        rightMotor.force = baseForce+pidForce;
        leftMotor.force = baseForce-pidForce;
    }
}
