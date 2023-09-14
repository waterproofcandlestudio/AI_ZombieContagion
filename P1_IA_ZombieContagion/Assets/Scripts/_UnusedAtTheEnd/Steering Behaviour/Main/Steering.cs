using UnityEngine;

public abstract class Steering : MonoBehaviour
{ 
    [SerializeField] private float weight = 1f; 
    public abstract SteeringData GetSteering(SteeringBehaviorBase steeringbase); 

    // Weight methods
    public float GetWeight() => weight;
    public void Play() => SetWeight(1);
    public void Stop() => SetWeight(0);
    public void SetWeight(float newWeight) => weight = newWeight;
}