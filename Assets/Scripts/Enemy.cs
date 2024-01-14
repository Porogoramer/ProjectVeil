using UnityEngine;

public class Enemy
{
    private GameObject enemy;
    private GameObject player;
    private bool aggroed;
    private float timeSinceLastSeen;
    private Vector3 targetLocation;

    private readonly float BEHAVIOUR_RANGE = 50;
    private readonly float AGGRO_RANGE = 10;
    private readonly float AGGRO_RANGE_TIMEOUT = 3;
    private readonly float AGGRO_OBSTRUCTION_TIMEOUT = 1;
    private readonly float WANDER_DELTA = 5;
    public Enemy(GameObject player, GameObject enemy)
    {
        this.player = player;
        this.enemy = enemy;
        aggroed = false;
        timeSinceLastSeen = 0;
        targetLocation = enemy.transform.position;
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
                Debug.Log("Player spotted");
                timeSinceLastSeen = 0;
                aggroed = true;
                return;
            }
            if(aggroed && hit.collider.CompareTag("Scenery"))
            {
                Debug.Log("Aggroed - Player obstructed");
                timeSinceLastSeen += timeSinceLastCheck;
                if (timeSinceLastSeen > AGGRO_OBSTRUCTION_TIMEOUT)
                {
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
        if (enemy.transform.position.Equals(targetLocation))
        {
            Debug.Log(targetLocation);
            SelectNewTargetLocation();
        }
        return VectorTowards(targetLocation);
    }

    public Vector3 VectorTowardsPlayer()
    {
        return VectorTowards(player.transform.position);
    }

    void SelectNewTargetLocation()
    {
        targetLocation = enemy.transform.position + new Vector3(Random.Range(-WANDER_DELTA, WANDER_DELTA), 0, Random.Range(-WANDER_DELTA, WANDER_DELTA));
    }
    Vector3 VectorTowards(Vector3 pos)
    {
        return (pos - enemy.transform.position).normalized;
    }
}
