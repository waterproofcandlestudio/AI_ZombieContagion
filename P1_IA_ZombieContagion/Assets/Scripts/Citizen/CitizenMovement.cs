// Miguel Rodríguez Gallego
using UnityEngine;

/// <summary>
///     Citizen movement depending on if there's a threat or not nearby
///         2 tipes of movement mainly: 
///             - Chill Routine
///             - Escape
/// </summary>
public class CitizenMovement : MonoBehaviour
{
    TargetDetector_Citizen targetDetector;
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
    public float movementSpeed = 200;
    public float maxSpeed = 10f;
    [SerializeField] bool randmRotateOnStart = false;


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

    void Start()
    {
        if (randmRotateOnStart)
            transform.Rotate(transform.up * Random.Range(-180, 180));
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        targetDetector = GetComponent<TargetDetector_Citizen>();
    }
    /// <summary>
    ///     Target - Action control methods
    /// </summary>
    void Update()
    {
        target = GetComponent<TargetDetector_Citizen>().target;

        if (target == null)
        {
            ChillRoutineLogic();
            return;
        }

        MoveOnOppositeDirectionToZombie();
    }

    /// <summary>
    ///     Escape from closer zombie moving on the oposite direction
    /// </summary>
    public void MoveOnOppositeDirectionToZombie()
    {
        chillingTimer = 0;

        Vector3 direction = (gameObject.transform.position - target.transform.position).normalized;
        direction.y = 0;
        Vector3 acceleration = direction * movementSpeed * Time.fixedDeltaTime;

        if (acceleration.magnitude > maxSpeed)
        {
            acceleration.Normalize();
            acceleration *= maxSpeed;
        }

        gameObject.transform.LookAt(direction);
        rb.velocity = acceleration;
    }

    /// <summary>
    ///     Chill when no zombie is around
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
