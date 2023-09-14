using UnityEngine;

public class CubeDeactivateGO : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManagerUnity.myOnQPress += Deactivate;
    }

    private void OnDestroy()
    {
        EventManagerUnity.myOnQPress -= Deactivate;
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
