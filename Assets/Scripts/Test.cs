using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    /*private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerInfo>().AddItem(new Boots());
    }*/
    private void Start()
    {
        Debug.Log(GameObject.FindGameObjectWithTag("Player"));
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().AddItem(new Adrenaline());
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().AddItem(new Adrenaline());
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().AddItem(new Adrenaline());
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().AddItem(new Adrenaline());
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().AddItem(new Adrenaline());
        Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().GetInventory().Count);
    }
}
