using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceController : MonoBehaviour
{
    private float _pidThrottle;
    public Motor rightMotor;
    public Motor leftMotor;
    public PID pid;
    public float Throttle;
    public float angle;
    void Update()
    {
        Throttle = Mathf.Clamp(Throttle, 0, 1);
        _pidThrottle = pid.Update((angle * Mathf.PI) / 180, gameObject.transform.rotation.z*2, Time.deltaTime);
        rightMotor.CreateForce(Throttle + _pidThrottle);
        leftMotor.CreateForce(Throttle - _pidThrottle);
    }
}
