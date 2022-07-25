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
        public void WhenRobotCreated_PlacedInValidPosition_ShouldBeAbleToMove()
        {
            var robot = new Robot(new Domain.Tabletop(6, 6));
            robot.Place("0,0,NORTH");
            Assert.True(robot.Move());
            Assert.Equal("0,1,NORTH", robot.Report());
        }

    }
}