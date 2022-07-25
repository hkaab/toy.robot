using System.ComponentModel.DataAnnotations;

namespace ToyRobot.Domain
{
    public enum Command
    {
        [Display(Name="Place")]
        Place,
        [Display(Name = "Move")]
        Move,
        [Display(Name = "Left")]
        Left,
        [Display(Name = "Right")]
        Right,
        [Display(Name = "Report")]
        Report
    }
}
