using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatItem : Item
{
    public StatItem(string name, string desc, PlayerInfo stats) : base(name, desc, stats) { }
    public StatItem(StatItem item) : base(item) { }

    /**
     * <remarks>
     * If item is consumable it should extend <c>ConsumableItem</c>
     * </remarks>
     */
    public override bool IsConsumable()
    {
        return false;
    }

    /**
     * <remarks>
     * A stat item that is not always useable should extend ConditionnalStatItem
     * </remarks>
     */
    public override bool IsUseable()
    {
        return true;
    }
}
