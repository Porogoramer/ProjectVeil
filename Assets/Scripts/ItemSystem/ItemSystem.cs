using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/**
 * <summary>
 * Class <c>ItemSystem</c> holds a List of <c>Item</c> acting as the <c>player</c>'s inventory
 * It applies stat items when they are acquired.
 * Applies conditionnal stat items when conditions are met.
 * Handles the consumption of consumables.
 * </summary>
 */
public class ItemSystem
{
    private PlayerInfo stats;
    private IList<IItem> items;
    private IList<IItem> conditionnalItems;
    
    public ItemSystem(PlayerInfo stats)
    {
        this.stats = stats;
        items = new List<IItem>();
    }

    /**
     * <summary>
     * Loops through all conditional stat items applying those
     * which are useable
     * </summary>
     */
    public void CheckForConditionalStatItems()
    {
        foreach (ConditionalStatItem item in conditionnalItems)
        {
            if (item.IsUseable())
            {
                item.Use();
            }
        }
    }

    public IList<IItem> GetInventory()
    {
        return items.ToList();
    }

    public void UseConsumable(int i)
    {
        if (items[i].IsConsumable() && items[i].IsUseable())
            items[i].Use();
    }

    public IItem RemoveItem(int i)
    {
        IItem removed = items[i];
        if (items[i].Quantity > 1)
        {
            removed.Drop();
        }
        else
        {
            items.RemoveAt(i);
            if (conditionnalItems.Contains(removed))
            {
                conditionnalItems.Remove(removed);
            }
        }
        return removed;
    }

    public void AddItem(IItem item)
    {
        int indexOfItem = items.IndexOf(item);
        if (indexOfItem == -1)
        {
            items[indexOfItem].PickUp();
        }
        else
        {
            items.Add(item);
        }
        if (item is ConditionalStatItem)
        {
            conditionnalItems.Add(item);
        }
        if (!item.IsConsumable() && item.IsUseable())
        {
            item.Use();
        }
    }
}
