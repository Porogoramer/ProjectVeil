using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private float speed = 20f;

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
