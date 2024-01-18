using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    string Name { get; }
    string Description { get; }
    int Quantity { get; }
    bool IsActive { get; set; }
    void Use(PlayerInfo stats);

    void PickUp();

    void Drop();

    bool IsConsumable();

    bool IsUseable(PlayerInfo stats);
}

public abstract class Item : IItem
{
    private string _name;
    private string _description;
    private int _quantity;
    private bool _isActive;

    public Item(string name, string description)
    {
        _name = name;
        _description = description;
        _quantity = 1;
        _isActive = false;
    }

    public Item(Item item) : this(item.Name, item.Description) {}

    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public int Quantity { get { return _quantity; } }
    public bool IsActive { get { return _isActive; } set { _isActive = value; } }

    public abstract bool IsConsumable();
    public abstract bool IsUseable(PlayerInfo stats);
    public abstract void Use(PlayerInfo stats);
    public void Drop()
    {
        _quantity--;
    }
    public void PickUp()
    {
        _quantity++;
    }

    public override bool Equals(object obj)
    {
        if(obj is Item)
        {
            return ((Item)obj)._name.Equals(_name) && ((Item)obj)._description.Equals(_description);
        }
        return false;
    }
}