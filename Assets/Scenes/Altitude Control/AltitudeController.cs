using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltitudeController : MonoBehaviour
{
    private bool _acclim = false;
    private float _pidThrottle;
    private float _currentAltitude;
    private float _verticalSpeed;

    public Motor rightMotor;
    public Motor leftMotor;
    public PID pid;
    public float maxacceleration;
    public float maxspeed;
    public float altitude;

    void Update()
    {
        _verticalSpeed = gameObject.GetComponent<Rigidbody2D>().velocity.y;
        _currentAltitude = gameObject.transform.position.y;
        _pidThrottle = pid.Update(altitude, _currentAltitude, Time.deltaTime);
        if (_verticalSpeed > 0.5)
        {
            pid.SetIntegral(0);
        }
        if(_verticalSpeed < -0.5)
        {
            pid.SetIntegral(0);
        }
        if (altitude - _currentAltitude > 1f || _acclim) //Enable Acceleration Limiter
        {
            _pidThrottle = AccelerationLimiter(_pidThrottle, maxacceleration);
            _acclim = true;
        }
        if (altitude - _currentAltitude < 0.5f && altitude - _currentAltitude >= 0) //Disable Acceleration Limiter
        {
            _acclim = false;
        }
        if (_verticalSpeed > maxspeed) //Speed Limiter
        {
            _pidThrottle = 0;
        }
        rightMotor.CreateForce(_pidThrottle);
        leftMotor.CreateForce(_pidThrottle);
    }

    float AccelerationLimiter(float throttle,float maxacc)
    {
        float newthrottle;
        float mass = gameObject.GetComponent<Rigidbody2D>().mass + rightMotor.gameObject.GetComponent<Rigidbody2D>().mass + leftMotor.gameObject.GetComponent<Rigidbody2D>().mass;
        float force = (rightMotor.force + leftMotor.force);
        float acc = (force * throttle - (9.81f)) / mass;
        if (acc > maxacc) 
        {
            newthrottle = (maxacc * mass + 9.81f) / force;
            return newthrottle;
        }
        else return throttle;
    }
}
