using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltitudeController : MonoBehaviour
{
    private float _pidThrottle;
    private float _currentAltitude;
    private float _verticalSpeed;
    public Motor rightMotor;
    public Motor leftMotor;
    public PID pid;
    public float integralLimit;
    public float ascendMaxSpeed;
    public float descendMaxSpeed;
    public float altitude;

    void FixedUpdate()
    {
        _verticalSpeed = gameObject.GetComponent<Rigidbody2D>().velocity.y;
        _currentAltitude = gameObject.transform.position.y;
        _pidThrottle = pid.Update(altitude, _currentAltitude, Time.fixedDeltaTime);

        if (altitude - _currentAltitude < -5) //Engage Descend Speed Limiter if altitude difference is greater than 5
        {
            _pidThrottle = DescendSpeedLimiter(_pidThrottle, _verticalSpeed, descendMaxSpeed);
        }

        //Anti Integral Windup Start
        if (_verticalSpeed < -2f) //Descending
        {
            pid.LimitIntegral(0);
        }
        pid.LimitIntegral(integralLimit); // Ascending
        //Anti Integral Windup End

        if (_verticalSpeed > ascendMaxSpeed) //Ascend Speed Limiter
        {
            _pidThrottle = 0;
        }

        rightMotor.CreateForce(_pidThrottle);
        leftMotor.CreateForce(_pidThrottle);
    }

    float DescendSpeedLimiter(float throttle, float verticalspeed, float maxspeed)
    {
        float newthrottle;
        float mass = gameObject.GetComponent<Rigidbody2D>().mass + rightMotor.gameObject.GetComponent<Rigidbody2D>().mass + leftMotor.gameObject.GetComponent<Rigidbody2D>().mass;
        float force = (rightMotor.force + leftMotor.force);
        float weight = -1f * mass * Physics2D.gravity.y;
        if (verticalspeed < -maxspeed)
        {
            newthrottle = weight / force;
            return newthrottle;
        }
        else return throttle;
    }
}
