using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    private ItemSystem itemSystem;

    private void Awake()
    {
        itemSystem = new ItemSystem(this);
    }

    private void FixedUpdate()
    {
        itemSystem.CheckForConditionalStatItems();
    }

    public IList<IItem> GetInventory()
    {
        return itemSystem.GetInventory();
    }

    public void AddItem(IItem item)
    {
        itemSystem.AddItem(item);
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
