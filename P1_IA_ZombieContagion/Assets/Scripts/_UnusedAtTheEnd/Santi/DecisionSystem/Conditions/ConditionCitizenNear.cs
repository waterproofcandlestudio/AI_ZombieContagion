using System;
using UnityEngine;

/// <summary>
/// Checks if this transform is within "range" distance from "target"
/// </summary>
public class ConditionCitizenNear : ICondition
{
    /// <summary>
    /// Target to detect
    /// </summary>
    public GameObject target;

    /// <summary>
    /// The maximun range a target can be detected
    /// </summary>
    public float range = 5.0f;

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
    //    if (target.transform == null) return false;

    //    return (transform.position - target.transform.position).magnitude <= range;
    //}
}
