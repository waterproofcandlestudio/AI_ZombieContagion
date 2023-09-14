// Miguel Rodríguez Gallego
using UnityEngine;

/// <summary>
///     Lets player infect citizens with a click, so they become zombies
/// </summary>
public class InfectCitizenLogic : MonoBehaviour
{
    new Camera camera;
    [Header("Infect properties")]
    [SerializeField] int citizensPlayerCanInfect = 1;
    [SerializeField] LayerMask citizenLayerMask;
    [SerializeField] GameObject zombiePrefab;


    void Start() => camera = Camera.main;
    void Update() => DetectObjectWithRaycast();

    /// <summary>
    ///     When clicking on a citizen, this code runs detectin if it's a citizen
    ///         and player has enough oportunities to infect a zombie
    /// </summary>
    public void DetectObjectWithRaycast()
    {
        if (citizensPlayerCanInfect == 0)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, citizenLayerMask)) // If he is a citizen => Converts him 2 zombie
            {
                ConvertToZombie(hit);
            }
        }
    }
    /// <summary>
    ///     Turns detected object into a zumbie
    /// </summary>
    void ConvertToZombie(RaycastHit hit)
    {
        Destroy(hit.transform.gameObject);
        Instantiate(zombiePrefab, hit.transform.position, hit.transform.rotation, hit.transform.parent);
        citizensPlayerCanInfect--;
    }
}
