using ToyRobot.Builder;

namespace ToyRobot.UnitTests
{
    public class RobotTests
    {
        [Fact]
        public void WhenRobotCreated_AndNotPlaced_ShouldNotMoveLeftRightReport()
        {
            var robot = new Robot(new Domain.Tabletop(6, 6));

            Assert.NotNull(robot);
            Assert.False(robot.Move());
            Assert.False(robot.Left());
            Assert.False(robot.Right());
            Assert.Equal("Place me on table top", robot.Report());
        }

        [Fact]
        public void WhenRobotCreated_AndPlacedValidPosition_ShouldBeAbleToMove()
        {
            var robot = new Robot(new Domain.Tabletop(6, 6));
            robot.Place("0,0,NORTH");
            Assert.True(robot.Move());
            Assert.Equal("0,1,NORTH", robot.Report());
        }

        [Fact]
        public void WhenRobotCreated_AndPlacedValidPosition_ShouldBeAbleToLeft()
        {
            var robot = new Robot(new Domain.Tabletop(6, 6));
            robot.Place("0,0,NORTH");
            Assert.True(robot.Left());
            Assert.Equal("0,0,WEST", robot.Report());
        }
        [Fact]
        public void WhenRobotCreated_AndPlacedValidPosition_ShouldBeAbleToMoveMoveLeftMove()
        {
            var robot = new Robot(new Domain.Tabletop(6, 6));
            robot.Place("1,2,EAST");
            Assert.True(robot.Move());
            Assert.True(robot.Move());
            Assert.True(robot.Left());
            Assert.True(robot.Move());
            Assert.Equal("3,3,NORTH", robot.Report());
        }

        [Fact]
        public void WhenRobotCreated_AndPlacedValidPosition_ShouldBeAbleToMoveLeftMovePlaceMove()
        {
            var robot = new Robot(new Domain.Tabletop(6, 6));
            robot.Place("1,2,EAST");
            Assert.True(robot.Move());
            Assert.True(robot.Left());
            Assert.True(robot.Move());
            Assert.True(robot.Place("3,1"));
            Assert.True(robot.Move());
            Assert.Equal("3,2,NORTH", robot.Report());
        }
        [Fact]
        public void WhenRobotCreated_AndPlacedWithoutDirection_ShouldThrowError()
        {
            var robot = new Robot(new Domain.Tabletop(6, 6));
            Assert.Throws<Exception>(() => robot.Place("1,2"));
        }
        [Fact]
        public void WhenRobotCreated_AndPlacedWithDirectionSubsequentPlace_CanOnlyProvideCoordinates()
        {
            var robot = new Robot(new Domain.Tabletop(6, 6));
            robot.Place("1,2,EAST");
            Assert.True(robot.Place("3,1"));
        }

        [Fact]
        public void WhenRobotCreated_AndPlacedWithDirectionWhenLeft_ShouldRotateAntiClockWise()
        {
            var robot = new Robot(new Domain.Tabletop(6, 6));
            robot.Place("0,0,EAST");
            Assert.True(robot.Left());
            Assert.Equal("0,0,NORTH", robot.Report());
            Assert.True(robot.Left());
            Assert.Equal("0,0,WEST", robot.Report());
            Assert.True(robot.Left());
            Assert.Equal("0,0,SOUTH", robot.Report());
            Assert.True(robot.Left());
            Assert.Equal("0,0,EAST", robot.Report());
        }
        [Fact]
        public void WhenRobotCreated_AndPlacedWithDirectionWhenRight_ShouldRotateClockWise()
        {
            var robot = new Robot(new Domain.Tabletop(6, 6));
            robot.Place("0,0,EAST");
            Assert.True(robot.Right());
            Assert.Equal("0,0,SOUTH", robot.Report());
            Assert.True(robot.Right());
            Assert.Equal("0,0,WEST", robot.Report());
            Assert.True(robot.Right());
            Assert.Equal("0,0,NORTH", robot.Report());
            Assert.True(robot.Right());
            Assert.Equal("0,0,EAST", robot.Report());
        }
        [Fact]
        public void WhenRobotCreated_AndPlacedWithWrongParam_ShouldThrowError()
        {
            var robot = new Robot(new Domain.Tabletop(6, 6));

            var exception = Assert.Throws<ArgumentException>(() => robot.Place("10,2"));
            Assert.Equal("Position is out of table", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => robot.Place("1,2"));
            Assert.Equal("Direction is not specified", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => robot.Place("1,2,Somewhere"));
            Assert.Equal("Direction is not valid", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => robot.Place("p1,p2,North"));
            Assert.Equal("Position is not valid", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => robot.Place("1 2 North"));
            Assert.Equal("Place params are not valid", exception.Message);
        }


    }
}