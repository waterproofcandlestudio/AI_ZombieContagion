using UnityEngine;

public class ArriveBehavior : Steering
{
    [SerializeField] private Transform target;
    [SerializeField] private float targetRadius = 1.5f;
    [SerializeField] private float slowRadius = 5f;
    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steering = new SteeringData();
        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;

        if (distance < targetRadius)
        {
            steeringbase.GetComponent<Rigidbody>().velocity = Vector3.zero;
            return steering;
        }

        float targetSpeed;
        if (distance > slowRadius)
            targetSpeed = steeringbase.maxAcceleration;

        else targetSpeed = steeringbase.maxAcceleration * (distance / slowRadius);

        Vector3 targetVelocity = direction;
        targetVelocity.Normalize();
        targetVelocity *= targetSpeed;
        steering.linear = targetVelocity - steeringbase.GetComponent<Rigidbody>().velocity;

        if (steering.linear.magnitude > steeringbase.maxAcceleration)
        {
            steering.linear.Normalize();
            steering.linear *= steeringbase.maxAcceleration;
        }
        steering.angular = 0;
        return steering;
    }
}