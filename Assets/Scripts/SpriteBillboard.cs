using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.y, 0);
    }
}
