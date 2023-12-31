using UnityEngine;

/// <summary>
/// Checks if "target" is visible (raycasting) from transform.
/// It relies on ability to cast rays, so opaque objects
/// should have colliders.
/// </summary>
public class ConditionCanSeeZombie : ICondition
{
    public GameObject target;

    /// <summary>
    /// The maximun range a sound can be seen by "character"
    /// </summary>
    public float range = 15.0f;

    /// <summary>
    /// The field-of-view angle
    /// </summary>
    public float fov = 90.0f;

    /// <summary>
    /// The layer mask of entities visible
    /// </summary>
    public LayerMask zombieLayerMask;

    public override bool Test()
    {
        //target = GetComponentInParent<TargetDetector>().target.gameObject;

        if (target.transform == null) return false;

        return (transform.position - target.transform.position).magnitude <= range;


        //FindTarget();

        //if (target.transform != null || target.transform == null)
        //    return (transform.position - target.transform.position).magnitude <= range;

        //return false;
    }


    //public override bool Test()
    //{
    //    if (target == null) return false;

    //    // First, check target is in range
    //    Vector3 vectorToTarget = target.transform.position - transform.position;
    //    if (vectorToTarget.magnitude > range) return false;

    //    // Second, check target inside field of view
    //    if (Mathf.Abs(Vector3.Angle(transform.forward, vectorToTarget)) < fov * 0.5f)
    //    {
    //        // Last, check target directly visible through ray casting from character
    //        Ray ray = new Ray(transform.position, vectorToTarget);
    //        RaycastHit hitInfo;

    //        if (Physics.Raycast(ray, out hitInfo, range, layerMask))
    //        {
    //            // Ray casted against an object, return true if it is the object we are trying to see
    //            return (hitInfo.collider == target.GetComponent<Collider>());
    //        }
    //    }
    //    return false;
    //}
}
