using System.ComponentModel.DataAnnotations;

namespace ToyRobot.Domain
{
    public enum Direction
    {
        [Display(Name = "NORTH")]
        NORTH,
        [Display(Name = "SOUTH")]
        SOUTH,
        [Display(Name = "EAST")]
        EAST,
        [Display(Name = "WEST")]
        WEST
    }
}