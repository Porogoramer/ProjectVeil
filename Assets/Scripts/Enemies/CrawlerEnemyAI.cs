using UnityEngine;

public class CrawlerEnemyAI
{
    private GameObject enemy;
    private GameObject player;
    private bool aggroed;
    private float timeSinceLastSeen;
    private float aggroCooldown;
    private Vector2 targetLocation;

    protected readonly float BEHAVIOUR_RANGE = 50;
    protected readonly float AGGRO_RANGE = 10;
    protected readonly float AGGRO_RANGE_TIMEOUT = 3;
    protected readonly float AGGRO_COOLDOWN = 1;
    protected readonly float AGGRO_OBSTRUCTION_TIMEOUT = 1;
    protected readonly float WANDER_DELTA = 3;
    public CrawlerEnemyAI(GameObject player, GameObject enemy)
    {
        this.player = player;
        this.enemy = enemy;
        aggroed = false;
        timeSinceLastSeen = 0;
        SelectNewTargetLocation();
    }

    /**
     * Should go in FixedUpdate() and get Time.fixedDeltaTime passed
     */
    public void CheckForPlayer(float timeSinceLastCheck)
    {
        int layerMask = 1 << 6;
        layerMask = ~layerMask;
        if (DistanceFromPlayer() > AGGRO_RANGE)
        {
            Debug.DrawRay(enemy.transform.position, VectorTowardsPlayer() * 20, Color.green);
            if (aggroed)
            {
                timeSinceLastSeen += timeSinceLastCheck;
                if (timeSinceLastSeen > AGGRO_RANGE_TIMEOUT)
                {
                    aggroCooldown = AGGRO_COOLDOWN;
                    aggroed = false;
                    SelectNewTargetLocation();
                    return;
                }
            }
        }
        else if(Physics.Raycast(enemy.transform.position, VectorTowardsPlayer(), out RaycastHit hit, AGGRO_RANGE, layerMask))
        {
            Debug.DrawRay(enemy.transform.position, VectorTowardsPlayer() * hit.distance, Color.red);
            if(hit.collider.CompareTag("Player"))
            {
                timeSinceLastSeen = 0;
                aggroCooldown -= timeSinceLastCheck;
                if(aggroCooldown <= 0)
                {
                    aggroed = true;
                }
                return;
            }
            if(aggroed && hit.collider.CompareTag("Scenery"))
            {
                timeSinceLastSeen += timeSinceLastCheck;
                if (timeSinceLastSeen > AGGRO_OBSTRUCTION_TIMEOUT)
                {
                    Debug.Log("Unstucking");
                    aggroCooldown = AGGRO_COOLDOWN;
                    aggroed = false;
                    SelectNewTargetLocation();
                }
            }
        }
    }

    float DistanceFromPlayer()
    {
        return Vector3.Distance(player.transform.position, enemy.transform.position);
    }

    public bool IsAggroed()
    {
        return aggroed;
    }

    public bool IsInRange()
    {
        return DistanceFromPlayer() < BEHAVIOUR_RANGE;
    }

    public Vector3 VectorSearching()
    {
        float deltaX = Mathf.Abs(targetLocation.x - enemy.transform.position.x);
        float deltaY = Mathf.Abs(targetLocation.y - enemy.transform.position.z);
        if (deltaX < 0.1 && deltaY < 0.1)
        {
            SelectNewTargetLocation();
        }
        return VectorTowards(new Vector3(targetLocation.x, enemy.transform.position.y, targetLocation.y));
    }

    // Call this at the same time as moving
    public Quaternion RotationTowardsDestination(Vector3 destination)
    {
        destination.y = 0f;
        return Quaternion.Euler(0f, Vector3.Angle(Vector3.forward, destination), 0f);
    }

    public Vector3 VectorTowardsPlayer()
    {
        return VectorTowards(player.transform.position);
    }

    public void CollidedWithScenery(GameObject go)
    {
        if(aggroed)
        {
            aggroCooldown = AGGRO_COOLDOWN;
        }
        aggroed = false;

        Vector3 vectorTowardsScenery = VectorTowards(go.transform.position) * WANDER_DELTA;
        targetLocation = new Vector2(-vectorTowardsScenery.x, -vectorTowardsScenery.z);
    }

    /**
     * Selects a new location for the Enemy to wander to.
     * (Should be called gets stuck on terrain)
     */
    public void SelectNewTargetLocation()
    {
        targetLocation = new Vector2(enemy.transform.position.x, enemy.transform.position.z) + new Vector2(Random.Range(-WANDER_DELTA, WANDER_DELTA), Random.Range(-WANDER_DELTA, WANDER_DELTA));
    }
    Vector3 VectorTowards(Vector3 pos)
    {
        return (pos - enemy.transform.position).normalized;
    }
}
