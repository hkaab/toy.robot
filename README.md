# ToyRobot  (requires .NET 6.0)

![workflow](https://github.com/hkaab/toy.robot/actions/workflows/ci.yml/badge.svg)

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

**Solution Requirements**
=========================

* The library allows for a simulation of a toy robot moving on a 6 x 6 square tabletop.

* There are no obstructions on the table surface.

* The robot is free to roam around the surface of the table, but must be prevented from falling to destruction. Any movement that would result in this must be prevented, however further valid movement commands must still be allowed.

* PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.

* (0,0) can be considered as the SOUTH WEST corner and (5,5) as the NORTH EAST corner.

* The first valid command to the robot is a PLACE command. After that, any sequence of commands may be issued, in any order, including another PLACE command. The library should discard all commands in the sequence until a valid PLACE command has been executed.

* The PLACE command should be discarded if it places the robot outside of the table surface.

* Once the robot is on the table, subsequent PLACE commands could leave out the direction and only provide the coordinates. When this happens, the robot moves to the new coordinates without changing the direction.

* MOVE will move the toy robot one unit forward in the direction it is currently facing.

* LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.

* REPORT will announce the X,Y and orientation of the robot.

* A robot that is not on the table can choose to ignore the MOVE, LEFT, RIGHT and REPORT commands.


**Example Input and Output**

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

ex: cd c:\Projects\toy.robot\src\ToyRobotSimulator\ToyRobotSimulator\bin\Debug\net6.0\

````

> ToyRobot.Simulator.exe

````

or 

````

> dotnet ToyRobot.Simulator.dll

````


**Running the Robot Simulator unit tests with .net cli**

Run command prompt (CMD)

Go to the cloned toyrobot project directoy 

ex: cd c:\Projects\toy.robot\src\ToyRobotSimulator

````

> dotnet test ToyRobot.sln

````


**Continuous integration using GitHub Actions**
===============================================

Please goto https://github.com/hkaab/toy.robot/actions



**WIKI**
========


**Screen shots**

Example of the application commands and output added in the docs folder


**NOTE for Table top**

![](https://github.com/hkaab/toy.robot/blob/main/docs/TableTop.png?raw=true)

If you need to change table top config you need to edit the appsettings.json

````
{
  "Tabletop": {
    "Rows": 6,
    "Cols": 6
  }
}
````
