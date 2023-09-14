using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_InfectHuman : IAction
{
    GameObject target;
    [SerializeField] GameObject zombiePrefab;

    void Awake()
    {
        //target = GetComponentInParent<ConditionTargetNear>().gameObject;
    }
    public override void Act()
    {
        target = GetComponentInParent<ConditionCitizenNear>().target.gameObject;

        //objectToDestroy = 
        if (target == null) return;

        ConvertToZombie(target);
    }

    void ConvertToZombie(GameObject hit)
    {
        Destroy(hit.transform.gameObject);
        Instantiate(zombiePrefab, hit.transform.position, hit.transform.rotation, hit.transform.parent);
        target = null;
    }
}


//public class A_InfectHuman : IAction
//{
//    public GameObject objectToDestroy;
//    [SerializeField] GameObject zombiePrefab;

//    public override void Act()
//    {
//        if (objectToDestroy == null) return;

//        ConvertToZombie(objectToDestroy);
//    }

//    void ConvertToZombie(GameObject hit)
//    {
//        Destroy(hit.transform.gameObject);
//        Instantiate(zombiePrefab, hit.transform.position, hit.transform.rotation, hit.transform.parent);
//    }
//}