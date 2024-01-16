using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConditionalStatItem : StatItem
{
    public ConditionalStatItem(string name, string description) : base(name, description) {}
    public ConditionalStatItem(ConditionalStatItem other) : base(other) { }
    /**
     * <remarks>
     * Should set the active prop to true
     * and apply any stat changes
     * </remarks>
     */
    public override abstract void Use(PlayerInfo stats);

    /**
     * <remarks>
     * IsUseable should return false if item is currently active
     * It should also deactivate the item if the conditions are no longer met
     * </remarks>
     */
    public new abstract bool IsUseable(PlayerInfo stats);

    /**
     * <remarks>
     * This class handles StatItems which are different 
     * from stat increasing consumables
     * </remarks>
     */
    public override bool IsConsumable()
    {
        return false;
    }
}
