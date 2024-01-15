using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        new Boots(other.gameObject.GetComponent<PlayerInfo>());
    }
}
