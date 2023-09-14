using UnityEngine;

public class AlignmentBehavior : Steering
{
    private Transform[] targets;
    [SerializeField] private float alignDistance = 8f;
    private void Start()
    {
        SteeringBehaviorBase[] agents = FindObjectsOfType<SteeringBehaviorBase>();
        targets = new Transform[agents.Length - 1];
        int count = 0;
        foreach (SteeringBehaviorBase agent in agents)
        {
            if (agent.gameObject != gameObject)
            {
                targets[count] = agent.transform; count++;
            }
        }
    }

    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steering = new SteeringData();
        steering.linear = Vector3.zero;
        int count = 0;
        foreach (Transform target in targets)
        {
            Vector3 targetDir = target.position - transform.position;
            if (targetDir.magnitude < alignDistance)
            {
                steering.linear += target.GetComponent<Rigidbody>().velocity; count++;
            }
        }
        if (count > 0)
        {
            steering.linear = steering.linear / count;
            if (steering.linear.magnitude > steeringbase.maxAcceleration)
            {
                steering.linear = steering.linear.normalized * steeringbase.maxAcceleration;
            }
        }
        return steering;
    }
}