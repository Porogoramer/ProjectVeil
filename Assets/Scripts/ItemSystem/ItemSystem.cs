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
    private IList<IItem> consumableItems;
    
    public ItemSystem(PlayerInfo stats)
    {
        this.stats = stats;
        items = new List<IItem>();
        conditionnalItems = new List<IItem>();
        consumableItems = new List<IItem>();
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
            if (item.IsUseable(stats))
            {
                item.Use(stats);
            }
        }
    }

    public IList<IItem> GetInventory()
    {
        return items.ToList();
    }

    public void UseConsumable(int i)
    {
        if (consumableItems[i].IsUseable(stats))
        {
            consumableItems[i].Use(stats);
            RemoveItem(consumableItems.IndexOf(consumableItems[i]));
        }
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
            items.Add(item);
            if (item is ConditionalStatItem)
                conditionnalItems.Add(item);
            else if (item.IsConsumable())
                consumableItems.Add(item);
        }
        else
        {
            items[indexOfItem].PickUp();
        }

        if (!item.IsConsumable())
        {
            item.Use(stats);
        }
    }
}
