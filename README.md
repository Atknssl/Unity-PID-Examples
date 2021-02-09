# Unity-PID-Examples

There is a WebGL build of this project [here](https://atknssl.com/pidexamples)

There are some basic examples that may help you to understand PID logic.
Currently there are 2 examples:

## Balance Rod
![BalanceRod](https://user-images.githubusercontent.com/40236955/106948157-68454180-673c-11eb-8f9e-be0c2f881709.jpg)
In this example, there are two motors connected to a rod which can rotate around its center. PID controller on rod controls the system. Motors balance the rod at a desired angle, which can be changed from controller.

This is actually PD controller by default, as there is no difference between motor power or loading, therefore I is not needed.

One can spawn weight balls to change loading, which would change the angle. After the ball leaves rod, rod will balance itself to desired angle. Balls have a default lifespan of 10s which can be changed from editor. 

As there is no I factor at default settings, the rod won't be able to balance itself exactly to the desired angle while balls are applying load. In order to change this, one must change the I factor from the controller to a positive value. With I factor addition, rod can also balance itself if motor powers are different.

## Altitude Control
![AltitudeControl](https://user-images.githubusercontent.com/40236955/106948144-65e2e780-673c-11eb-90ed-a48efb64d418.jpg)
Demonstration video: [Youtube](https://youtu.be/p721Ur-T_SY)

In this example, there are two motors connected to a rod which is free to move on y axis. PID controller on rod controls the system. Motors try to hold desired altitude, which can be changed from controller.

Rod kept overshooting because of high velocity, so a speed limiter is implemented while rod ascends and descends. Maximum ascend and descend speed can be changed from editor.

To prevent [integral windup](https://en.wikipedia.org/wiki/Integral_windup) while changing altitude, maximum value of integral is limited.

Altitude lines will show until altitude of 100 meters, this can be changed from editor.

Current PID gains are choosen for altitude changes greater than 10m. For lower altitude changes, response will be slower. For example, with current gains, altitude change from 0 to 50m is quick and responsive, whereas altitude change from 0 to 5m is slow. To get better performance at small altitude changes, PID gains should be changed.

# Other Settings

## Motors
Maximum force motor can create can be changed from motor script on each motor. Default value is 30N.
## Balls
Mass of balls can be changed from Ball prefab. Default value is 1kg.
