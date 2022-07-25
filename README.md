# ToyRobot  (requires .NET 6.0)

![workflow](https://github.com/hkaabasl/ToyRobot/actions/workflows/ci.yml/badge.svg)

**Scenario**
Create a library that can read in commands of the following form:

PLACE X, Y, DIRECTION

MOVE

LEFT

RIGHT

REPORT

**Extra commands to stop the robot simulation**

QUIT

EXIT

STOP

OFF

Example Input and Output

Example 1 Input

````

> PLACE 0,0,NORTH

> MOVE

> REPORT

Output: 0,1,NORTH

````

Example 2 Input

````

> PLACE 0,0,NORTH

> LEFT

> REPORT

Output: 0,0,WEST

````

Example 3 Input

````

> PLACE 1,2,EAST

> MOVE

> MOVE

> LEFT

> MOVE

> REPORT

Output: 3,3,NORTH

````
Example 4 Input

````
> PLACE 1,2,EAST

> MOVE

> LEFT

> MOVE

> PLACE 3,1

> MOVE

> REPORT

Output: 3,2,NORTH

````


**Setup Dev Environment**
=========================

Download and Install visuall studio 2022  from https://visualstudio.microsoft.com/vs/

**Clone this repository**

git clone https://github.com/hkaabasl/ToyRobot.git

Open the solution (in src\ToyRobotSimulator folder) in visual studio and build the solution



**Running the Robot Simulator with .net cli**

Run command prompt (CMD)

Go to the cloned toyrobot project directoy 

ex: cd c:\Projects\ToyRobot\src\ToyRobotSimulator\ToyRobotSimulator\bin\Debug\net6.0\

> ToyRobot.Simulator.exe

or 

> dotnet ToyRobot.Simulator.dll


**Running the Robot Simulator unit tests with .net cli**

Run command prompt (CMD)

Go to the cloned toyrobot project directoy 

ex: cd c:\Projects\ToyRobot\src\ToyRobotSimulator

> dotnet test ToyRobot.sln



**Check Robot Simulator Continuous integration using GitHub Actions**

Please goto https://github.com/hkaabasl/ToyRobot/actions


**screen shots**

Example of the application commands and output added in the docs folder


**NOTE**

If you need to change table top config you need to edit the appsettings.json

````
{
  "Tabletop": {
    "Rows": 6,
    "Cols": 6
  }
}
````