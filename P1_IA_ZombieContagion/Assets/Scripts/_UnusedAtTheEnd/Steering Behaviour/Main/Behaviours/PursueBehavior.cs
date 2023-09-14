using UnityEngine;


public class PursueBehavior : Steering
{
    [SerializeField] private float maxPrediction = 2f;
    [SerializeField] private GameObject target;
    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steering = new SteeringData();
        Vector3 direction = target.transform.position - transform.position;
        float distance = direction.magnitude;
        float speed = GetComponent<Rigidbody>().velocity.magnitude;
        float prediction;

        if (speed <= (distance / maxPrediction))
            prediction = maxPrediction;

        else
            prediction = distance / speed;

        Vector3 predictedTarget = target.transform.position + (target.GetComponent<Rigidbody>().velocity * prediction);
        steering.linear = predictedTarget - transform.position;
        steering.linear.Normalize();
        steering.linear *= steeringbase.maxAcceleration;
        steering.angular = 0;

        return steering;
    }
}