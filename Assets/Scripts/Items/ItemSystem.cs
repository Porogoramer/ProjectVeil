using System.Collections.Generic;
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
    private GameObject player;
    private IList<IItem> items;
    private IList<IItem> conditionnalItems;
    
    public ItemSystem(GameObject player)
    {
        this.player = player;
        items = new List<IItem>();
    }

    /**
     * <summary>
     * Loops through all conditional stat items apply 
     * </summary>
     */
    public void CheckForConditionalStatItems()
    {
        foreach (ConditionalStatItem item in conditionnalItems)
        {
            if (item.IsUseable())
            {
                item.Use(player);
            }
        }
    }

    public void UseConsumable(int i)
    {
        if (items[i].IsConsumable() && items[i].IsUseable())
            items[i].Use(player);
    }

    public IItem RemoveItem(int i)
    {
        IItem removed = items[i];
        items.RemoveAt(i);
        if (conditionnalItems.Contains(removed))
        {
            conditionnalItems.Remove(removed);
        }
        return removed;
    }

    public void AddItem(IItem item)
    {
        items.Add(item);
        if (item is ConditionalStatItem)
        {
            conditionnalItems.Add(item);
        }
        if (!item.IsConsumable() && item.IsUseable())
        {
            item.Use(player);
        }
    }
}
