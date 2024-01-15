using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    string Name { get => Name; }
    string Description { get => Description; }
    int Quantity { get => Quantity; }
    bool IsActive { get => IsActive; }
    void Use(GameObject player);

    bool IsConsumable();

    bool IsUseable();
}
