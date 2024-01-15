using UnityEngine;

public class CrawlerEnemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float huntingSpeed = 20f;
    [SerializeField] float wanderSpeed = 15f;
    private Enemy AI;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        AI = new Enemy(player, gameObject);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (AI.IsInRange())
        {
            AI.CheckForPlayer(Time.fixedDeltaTime);
            if (AI.IsAggroed())
            {
                rb.AddForce(AI.VectorTowardsPlayer() * huntingSpeed);
            }else
                rb.AddForce(AI.VectorSearching() * wanderSpeed);
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
