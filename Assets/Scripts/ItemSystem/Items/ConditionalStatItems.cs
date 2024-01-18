using UnityEngine;

public class Adrenaline : ConditionalStatItem
{
    private readonly float SPEED_MODIFIER = 1.5f;
    public Adrenaline() : base("Adrenaline", "Get a speedboost when near enemies") { }

    public override bool IsUseable(PlayerInfo stats)
    {

        GameObject[] loadedEnemies = GameObject.FindGameObjectsWithTag("LoadedEnemy");
        if (loadedEnemies.Length > 0)
        {
            foreach (GameObject enemy in loadedEnemies)
            {
                if (Vector3.Distance(GameObject.Find("Kyle").transform.position, enemy.transform.position) < 5)
                {
                    if (!IsActive)
                    {
                        Debug.LogWarning("Useable");
                        IsActive = true;
                        return true;
                    }
                    return false;
                }
            }
        }
        
        if (IsActive)
        {
            ToggleOff(stats);
        }
        IsActive = false;
        return false;
    }

    public override void Use(PlayerInfo stats)
    {
        Debug.LogWarning("Using");
        Debug.LogError(Quantity * 0.1f + 1);
        stats.SetSpeed(stats.GetSpeed() * (SPEED_MODIFIER * (Quantity * 0.1f + 1)));
    }

    private void ToggleOff(PlayerInfo stats)
    {
        Debug.LogWarning("TogglingOff");
        stats.SetSpeed(stats.GetSpeed() / (SPEED_MODIFIER * (Quantity * 0.1f + 1)));
    }
}
