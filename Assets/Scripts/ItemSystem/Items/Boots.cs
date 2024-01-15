using UnityEngine;

public class Boots : StatItem
{
    public Boots(PlayerInfo stats) : base("Boots", "Increases movement speed by 10%", stats) {}
    
    public override void Use()
    {
        _stats.SetSpeed(_stats.GetSpeed() * 1.1f);
    }
}
