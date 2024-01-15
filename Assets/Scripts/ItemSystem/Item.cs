using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    string Name { get; }
    string Description { get; }
    int Quantity { get; }
    bool IsActive { get; }
    void Use();

    void PickUp();

    void Drop();

    bool IsConsumable();

    bool IsUseable();
}

public abstract class Item : IItem
{
    private string _name;
    private string _description;
    private int _quantity;
    private bool _isActive;
    protected PlayerInfo _stats;

    public Item(string name, string description, PlayerInfo stats)
    {
        _name = name;
        _description = description;
        _quantity = 1;
        _isActive = false;
        _stats = stats;
    }

    public Item(Item item) : this(item.Name, item.Description, item._stats) {}

    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public int Quantity { get { return _quantity; } }
    public bool IsActive { get { return _isActive; } }

    public abstract bool IsConsumable();
    public abstract bool IsUseable();
    public abstract void Use();
    public void Drop()
    {
        _quantity--;
    }
    public void PickUp()
    {
        _quantity++;
    }
}