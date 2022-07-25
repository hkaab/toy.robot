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
        public void WhenRobotCreated_AndPlacedInValidPosition_ShouldBeAbleToMove()
        {
            var robot = new Robot(new Domain.Tabletop(6, 6));
            robot.Place("0,0,NORTH");
            Assert.True(robot.Move());
            Assert.Equal("0,1,NORTH", robot.Report());
        }

        [Fact]
        public void WhenRobotCreated_AndPlacedInValidPosition_ShouldBeAbleToLeft()
        {
            var robot = new Robot(new Domain.Tabletop(6, 6));
            robot.Place("0,0,NORTH");
            Assert.True(robot.Left());
            Assert.Equal("0,0,WEST", robot.Report());
        }
        [Fact]
        public void WhenRobotCreated_AndPlacedInValidPosition_ShouldBeAbleToMoveMoveLeftMove()
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
        public void WhenRobotCreated_PlacedInValidPosition_ShouldBeAbleToMoveLeftMovePlaceMove()
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

    }
}