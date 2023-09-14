using UnityEngine;

public class CohesionBehavior : Steering
{
    private Transform[] targets; 
    [SerializeField] private float viewAngle = 60f; 
    private void Start()
    { 
        SteeringBehaviorBase[] agents = FindObjectsOfType<SteeringBehaviorBase>(); 
        targets = new Transform[agents.Length - 1]; 
        int count = 0; 
        foreach (SteeringBehaviorBase agent in agents) 
        { 
            if (agent.gameObject != gameObject) 
            { 
                targets[count] = agent.transform;
                count++; 
            }
        } 
    }

    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    { 
        SteeringData steering = new SteeringData(); 
        Vector3 centerOfMass = Vector3.zero; 
        int count = 0; 

        foreach (Transform target in targets) 
        { 
            Vector3 targetDir = target.position - transform.position; 
            if (Vector3.Angle(targetDir, transform.forward) < viewAngle) 
            { 
                centerOfMass += target.position; count++; 
            } 
        } 
        if (count > 0)
        {
            centerOfMass = centerOfMass / count;
            steering.linear = centerOfMass - transform.position;
            steering.linear.Normalize(); 
            steering.linear *= steeringbase.maxAcceleration; 
        }
        return steering; 
    }
}