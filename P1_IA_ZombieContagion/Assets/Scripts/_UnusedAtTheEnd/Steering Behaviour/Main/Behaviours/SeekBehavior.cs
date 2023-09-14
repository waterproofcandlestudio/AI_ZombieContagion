using UnityEngine;


public class SeekBehavior : Steering
{
    [SerializeField] private GameObject target;
    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steering = new SteeringData();

        steering.linear = target.transform.position - transform.position;
        steering.linear.Normalize();
        steering.linear *= steeringbase.maxAcceleration;
        steering.angular = 0;

        return steering;
    }
}