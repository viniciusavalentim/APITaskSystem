using System.ComponentModel;

namespace TaskSystem.Enums
{
    public enum TaskStats
    {
        [Description("Starting")]
        Starting = 1,
        [Description("InProgress")]
        InProgress = 2,
        [Description("Completed")]
        Completed = 3
    }
}
