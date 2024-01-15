using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConsumableItem : Item
{
    public ConsumableItem(string name, string description, PlayerInfo stats) : base(name, description, stats) { }
    public ConsumableItem(ConsumableItem other) : base(other) { }
    /**
     * <remarks>
     * Is necessarily a consumable
     * </remarks>
     */
    public override bool IsConsumable()
    {
        return true;
    }
}
