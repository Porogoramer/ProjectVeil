using System.Timers;

public class SpeedPotion : ConsumableItem
{
    private static readonly float SPEED_MODIFIER = 1.3f;
    private static readonly float DURATION = 3f;

    public SpeedPotion() : base("Speed Potion", "Grants " + (SPEED_MODIFIER - 1) * 100 + "% bonus speed for " + DURATION + " seconds") { }

    public override bool IsUseable(PlayerInfo stats)
    {
        if (IsActive)
        {
            return false;
        }
        return true;
    }

    public override void Use(PlayerInfo stats)
    {
        stats.SetSpeed(stats.GetSpeed() * SPEED_MODIFIER);
        IsActive = true;
        ScheduleToggleOff(stats);
    }

    private void ScheduleToggleOff(PlayerInfo stats)
    {
        Timer timer = new Timer(DURATION * 1000);
        timer.Elapsed += (sender, e) => ToggleOff(sender, e, stats, timer);
        timer.Start();
    }

    private void ToggleOff(object send, ElapsedEventArgs e, PlayerInfo stats, Timer timer)
    {
        stats.SetSpeed(stats.GetSpeed() / SPEED_MODIFIER);
        IsActive = false;
        timer.Stop();
        timer.Close();
    }
}
