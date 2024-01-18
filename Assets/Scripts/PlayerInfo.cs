using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Progress;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private int health = 5;
    public GameObject deathScreen;
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

    public void UseConsumable(int i)
    {
        itemSystem.UseConsumable(i);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            damage();
            Invoke("heal", 30f);
        }
    }

    private void heal()
    {
        if (health != 5)
            health++;
    }

    private void damage()
    {
        if (health == 1)
        {
            Time.timeScale = 0;
            deathScreen.SetActive(true);
        }
        else
            health--;
    }
}
