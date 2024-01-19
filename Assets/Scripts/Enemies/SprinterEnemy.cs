using UnityEngine;

public class SprinterEnemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float huntingSpeed = 30f;
    [SerializeField] float wanderSpeed = 15f;
    private SprinterEnemyAI AI;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        AI = new SprinterEnemyAI(player, gameObject);
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (AI.IsInRange())
        {
            Vector3 moveDirection;
            gameObject.tag = "LoadedEnemy";
            AI.CheckForPlayer(Time.fixedDeltaTime);
            if (AI.IsAggroed())
            {
                moveDirection = AI.VectorTowardsPlayer();
                transform.rotation = AI.RotationTowardsDestination(moveDirection);   
                if(AI.IsCharged(Time.fixedDeltaTime))
                {
                    rb.AddForce(moveDirection * huntingSpeed);
                }
            }
            else
            {
                moveDirection = AI.VectorSearching();
                transform.rotation = AI.RotationTowardsDestination(moveDirection);
                rb.AddForce(moveDirection * wanderSpeed);
            }
        }
        else
        {
            gameObject.tag = "UnloadedEnemy";
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Scenery"))
        {
            AI.CollidedWithScenery(collision.gameObject);
        }
    }
}
