using UnityEngine;

public class FollowPathBehavior : Steering
{
    [SerializeField] private PathLine path; 
    [SerializeField] private float pathOffset = 0.71f; 
    private float currentParam = 0; 
    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    { 
        SteeringData steering = new SteeringData(); 
        Vector3 targetPosition; 
        if (path.nodes.Length == 1) 
            targetPosition = path.nodes[0]; 
        else 
        { 
            currentParam = path.GetParam(transform.position); 
            float targetParam = currentParam + pathOffset; 
            targetPosition = path.GetPosition(targetParam); 
            steering.linear = targetPosition - transform.position; 
            steering.linear.Normalize(); 
            steering.linear *= steeringbase.maxAcceleration; 
        } 
        return steering; 
    }
}