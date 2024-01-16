public class Boots : StatItem
{
    public Boots() : base("Boots", "Increases movement speed by 10%") {}
    
    public override void Use(PlayerInfo stats)
    {
        stats.SetSpeed(stats.GetSpeed() * 1.1f);
    }
}
