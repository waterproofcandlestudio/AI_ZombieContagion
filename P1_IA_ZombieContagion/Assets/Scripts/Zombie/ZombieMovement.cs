// Miguel Rodríguez Gallego
using UnityEngine;

/// <summary>
///     Zombie movement depending on if there's a citizen to infect nearby or not
///         2 tipes of movement mainly: 
///             - Chill Routine
///             - Chase
/// </summary>
public class ZombieMovement : MonoBehaviour
{
    TargetDetector_Zombie targetDetectorZombie;
    Rigidbody rb;

    /// <summary>
    ///     Target to be looking at
    /// </summary>
    [SerializeField] GameObject target;

    /// <summary>
    ///     Movement values towards Citizen - Zombie => Chase - Escape
    /// </summary>
    [Header("Movement values")]
    public float rotationSpeed = 500;
    public float movementSpeed = 500;
    public float maxSpeed = 10f;
    [SerializeField] bool randmRotateOnStart = false;

    /// <summary>
    ///     Prefab to instantiate when infecting a citizen
    /// </summary>
    [Header("Infection Info")]
    [SerializeField] GameObject zombiePrefab;

    /// <summary>
    ///     Controls what part of the routine must be played
    /// </summary>
    float chillingTimer = 0;
    /// <summary>
    ///     Routine randomly generated values
    /// </summary>
    int walkWait;
    int walkTime;
    int rotateWait;
    int rotateOrNot;
    int rotationTime;
    float rotationQuantity;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        targetDetectorZombie = GetComponent<TargetDetector_Zombie>();
    }
    void Start()
    {
        if (randmRotateOnStart)
            transform.Rotate(transform.up * Random.Range(-180, 180));
    }
    /// <summary>
    ///     Target - Action control methods
    /// </summary>
    void Update()
    {
        target = GetComponent<TargetDetector_Zombie>().target;

        if (target == null)
        {
            ChillRoutineLogic();
            return;
        }

        MoveTowardsCitizen();        
    }

    /// <summary>
    ///     Infect citizen when zombie collides with it
    /// </summary>
    void OnCollisionEnter(Collision collision)
    {
        ConvertToZombie(collision.collider.gameObject);
    }
    void ConvertToZombie(GameObject hit)
    {
        if (hit.tag == "Citizen")
        {
            Destroy(hit);
            Instantiate(zombiePrefab, hit.transform.position, hit.transform.rotation, hit.transform.parent);
            target = null;  // To eliminate it from the collider[] targets list and search for another 
        }
    }

    /// <summary>
    ///     Make zombie move directly towards citizen
    /// </summary>
    public void MoveTowardsCitizen()
    {
        Vector3 direction = (target.transform.position - gameObject.transform.position).normalized;
        direction.y = 0;
        Vector3 acceleration = direction * movementSpeed * Time.fixedDeltaTime;

        if (acceleration.magnitude > maxSpeed)
        {
            acceleration.Normalize();
            acceleration *= maxSpeed;
        }

        gameObject.transform.LookAt(direction * rotationSpeed * Time.fixedDeltaTime);
        rb.velocity = acceleration;
    }


    /// <summary>
    ///     Chill random routine when all citizens are infected
    /// </summary>
    void ChillRoutineLogic()
    {
        if (chillingTimer <= 0)
        {
            walkWait = Random.Range(1, 3);
            walkTime = walkWait + Random.Range(0, 3);
            rotateWait = walkTime + Random.Range(0, 3);
            rotateOrNot = Random.Range(1, 2);
            rotationTime = rotateWait + Random.Range(0, 3);
            rotationQuantity = Random.Range(-180, 180);

            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        chillingTimer += Time.deltaTime;
        Wander();
    }
    void Wander()
    {
        if (chillingTimer <= walkWait)
            return;

        if (chillingTimer <= walkTime)
        {
            Vector3 acceleration = transform.forward * movementSpeed * Time.fixedDeltaTime;
            acceleration.y = 0;
            rb.velocity = acceleration;
            return;
        }
        if (chillingTimer <= rotateWait)
        {
            return;
        }

        if (rotateOrNot == 1)
        {
            if (chillingTimer <= rotationTime)
            {
                transform.Rotate(transform.up * Time.deltaTime * rotationQuantity);
                return;
            }
        }
        chillingTimer = 0;
    }
}
