using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConditionalStatItem : IItem
{
    public abstract void Use(GameObject player);

    /**
     * <remarks>
     * IsUseable should return false if item is currently active
     * It should also deactivate the item if the conditions are no longer met
     * </remarks>
     */
    public abstract bool IsUseable();

    /**
     * <remarks>
     * This class handles StatItems which are different 
     * from stat increasing consumables
     * </remarks>
     */
    public bool IsConsumable()
    {
        return false;
    }
}
