using UnityEngine;

public class SteeringBehaviorBase : MonoBehaviour
{
    private Rigidbody rb;
    private Steering[] steerings;
    public float maxAcceleration = 10f;
    public float maxAngularAcceleration = 3f;
    public float drag = 1f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); steerings = GetComponents<Steering>();
        rb.drag = drag;
    }

    void FixedUpdate()
    {
        Vector3 accelaration = Vector3.zero;
        float rotation = 0f;
        foreach (Steering behavior in steerings)
        {
            SteeringData steering = behavior.GetSteering(this);
            accelaration += steering.linear * behavior.GetWeight();
            rotation += steering.angular * behavior.GetWeight();
        }
        if (accelaration.magnitude > maxAcceleration)
        {
            accelaration.Normalize();
            accelaration *= maxAcceleration;
        }
        rb.AddForce(accelaration);
    }
}