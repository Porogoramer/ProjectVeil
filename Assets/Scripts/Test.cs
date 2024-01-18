using UnityEngine;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
    private void Start()
    {
        // Example items, SpeedPotion is used by hitting 'F'.
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().AddItem(new SpeedPotion());
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().AddItem(new SpeedPotion());
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().AddItem(new SpeedPotion());
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().AddItem(new Boots());
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().AddItem(new Adrenaline());
        IList<IItem> items = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().GetInventory();
        foreach(IItem item in items)
        {
            Debug.Log(item.Name);
        }
    }
}
