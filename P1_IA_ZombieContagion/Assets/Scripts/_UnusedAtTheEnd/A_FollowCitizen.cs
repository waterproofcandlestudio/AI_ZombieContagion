using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_FollowCitizen : IAction
{
    /// <summary>
    /// Target to detect
    /// </summary>
    GameObject target;
    [SerializeField] GameObject zombie;
    [SerializeField] float speed = 10.0f;

    Rigidbody rb;
    CharacterController characterController;
    Vector3 direction;

    /// <summary>
    /// The maximun range a target can be detected
    /// </summary>
    //public float range = 5.0f;

    void Awake()
    {
        //target = GetComponentInParent<TargetDetector>().target.gameObject;
        rb = GetComponentInParent<Rigidbody>();
        //characterController = zombie.GetComponentInParent<CharacterController>();
    }

    public override void Act()
    {
        //direction = GetComponentInParent<TargetDetector>().direction.normalized;
        moveCharacter(direction);
    }

    void moveCharacter(Vector3 direction)
    {
        zombie.transform.LookAt(direction);
        //characterController.Move(direction * Time.deltaTime);
        rb.AddForce(direction * speed * Time.fixedDeltaTime);
    }
}
