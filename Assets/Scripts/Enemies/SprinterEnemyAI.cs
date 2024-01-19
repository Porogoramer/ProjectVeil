using UnityEngine;

public class SprinterEnemyAI : CrawlerEnemyAI
{
    private float chargeTime;
    private bool isCharged;
    protected new readonly float AGGRO_RANGE = 15;
    protected new readonly float AGGRO_RANGE_TIMEOUT = 3;
    protected new readonly float AGGRO_COOLDOWN = 1;
    protected new readonly float AGGRO_OBSTRUCTION_TIMEOUT = 1;
    protected new readonly float WANDER_DELTA = 5;
    protected readonly float CHARGE_WINDUP = 2;
    public SprinterEnemyAI(GameObject player, GameObject enemy) : base(player, enemy) 
    {
        isCharged = false;
        chargeTime = 0;
    }

    public bool IsCharged(float timeSinceLastFrame)
    {
        chargeTime += timeSinceLastFrame;
        if(chargeTime > CHARGE_WINDUP || (isCharged && IsAggroed()) ) 
        {
            chargeTime = 0;
            isCharged = true;
            return isCharged;
        }
        isCharged = false;
        return isCharged;
    }
}
