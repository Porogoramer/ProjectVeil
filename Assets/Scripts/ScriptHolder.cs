using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptHolder : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void respawn()
    {
        Time.timeScale = 1;
        deathScreen.SetActive(false);
    }
}
