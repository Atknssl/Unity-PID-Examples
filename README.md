# Unity-PID-Examples

Currently there are 2 examples:

## Balance Rod
![BalanceRod](https://atknssl.com/img/BalanceRod.jpg)
In this example, there are two motors connected to a rod which can rotate around its center. PID controller on rod controls the system. Motors balance the rod at a desired angle, which can be changed from controller.

This is actually PD controller by default, as there is no difference between motor power or loading, therefore I is not needed.

One can spawn weight balls to change loading, which would change the angle. After the ball leaves rod, rod will balance itself to desired angle. Balls have a default lifespan of 10s which can be changed from editor. 

As there is no I factor at default settings, the rod won't try to balance itself to desired angle while balls are applying load. In order to change this, one must change the I factor from the controller to a positive value. With I factor addition, rod can also balance itself if motor powers are different.

## Altitude Control (Incomplete)
![AltitudeControl](https://atknssl.com/img/AltitudeControl.jpg)
In this example, there are two motors connected to a rod which is free to move on y axis. PID controller on rod controls the system. Motors try to hold desired altitude, which can be changed from controller.

Rod kept overshooting the desired altitude while increasing its altitude , as the motors can't produce negative thrust, therefore a speed limiter is implemented while rod ascents. Also there is an acceleration limiter implemented while rod ascents. Maximum values for speed and acceleration can be changed from controller. This feature might be removed later, if overshooting problem can be solved.

Also I factor was causing problems while changing altitude, so integral is disabled while rod is in transition. When the rod is stationary, Integral is enabled again. This feature might also be removed later, if better solution can be found.

# Other Settings

## Motors
Maximum force motor can create can be changed from motor script on each motor. Default value is 50N.
## Balls
Masses of balls can be changed from Ball prefab. Default value is 10kg.