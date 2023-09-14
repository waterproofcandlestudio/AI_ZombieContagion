// Miguel Rodríguez Gallego
using UnityEngine;

/// <summary>
///     Detects close targets
/// </summary>
public class TargetDetector_Citizen : MonoBehaviour
{
    /// <summary>
    ///     Target & direction to follow
    /// </summary>
    [HideInInspector] public GameObject target;
    [HideInInspector] public Vector3 direction;

    [Header("Detection parameters")]
    [SerializeField] LayerMask targetLayerMask;
    [SerializeField] int seeTargetRange = 150;
    [SerializeField] Collider[] targetsCollider;
    Transform closestTarget;

    /// <summary>
    ///     Constantly try to find if there's a zombie nearby
    /// </summary>
    void Update()
    {
        FindTarget();
    }
    /// <summary>
    ///     If there's a zombie nearby, this method instantly:
    ///         - Gets closer entity
    ///         - Adds him to targets list of zombies/threats
    /// </summary>
    public void FindTarget()
    {
        targetsCollider = Physics.OverlapSphere(transform.position, seeTargetRange, targetLayerMask);

        if (targetsCollider.Length != 0)
        {
            closestTarget = GetClosestEntity(targetsCollider);
            target = closestTarget.gameObject;
        }
        else
        {
            targetsCollider = null;   // No zombie around in sight
            target = null;
        }
    }

    /// <summary>
    ///     Gets closer entity in checking collider
    /// </summary>
    Transform GetClosestEntity(Collider[] entity)
    {
        Collider tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Collider t in entity)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin.transform;
    }
}
