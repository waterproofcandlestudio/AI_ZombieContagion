using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Escape : IAction
{
    /// <summary>
    /// Target to detect
    /// </summary>
    [SerializeField] GameObject target;
    [SerializeField] GameObject citizen;
    [SerializeField] float speed = 10.0f;

    CharacterController characterController;
    Rigidbody rb;
    Vector3 direction;

    /// <summary>
    /// The maximun range a target can be detected
    /// </summary>
    //public float range = 5.0f;


    void Awake()
    {
        //target = GetComponentInParent<TargetDetector>().target.gameObject;
        rb = GetComponentInParent<Rigidbody>();
        //characterController = citizen.GetComponentInParent<CharacterController>();
        //citizen = characterController.gameObject;
    }

    public override void Act()
    {
        if (target != null)
        {
            //direction = GetComponentInParent<TargetDetector>().direction;
            direction = (target.transform.position - citizen.transform.position);
        }
        MoveCharacter(direction);
    }

    void MoveCharacter(Vector3 direction)
    { 
        citizen.transform.LookAt(direction);
        //characterController.Move(direction * speed * Time.deltaTime);
        rb.AddForce(direction * speed * Time.fixedDeltaTime);
    }
}
