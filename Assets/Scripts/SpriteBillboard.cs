using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, player.transform.rotation.eulerAngles.y, 0);
    }
}
