using UnityEngine;


public class FaceBehavior : Steering
{
    [SerializeField] private Transform target;

    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steering = new SteeringData();
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        steering.angular = Mathf.LerpAngle(transform.rotation.eulerAngles.y, angle, steeringbase.maxAngularAcceleration * Time.deltaTime);
        steering.linear = Vector3.zero;

        return steering;
    }
}