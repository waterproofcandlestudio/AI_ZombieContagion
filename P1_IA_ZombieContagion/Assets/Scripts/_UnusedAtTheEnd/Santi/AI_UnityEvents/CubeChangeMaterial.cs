using UnityEngine;

public class CubeChangeMaterial : MonoBehaviour
{
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        EventManagerUnity.myOnStart += ChangeMaterial;
    }

    private void OnDestroy()
    {
        EventManagerUnity.myOnStart -= ChangeMaterial;
    }

    private void ChangeMaterial()
    {
        GetComponent<MeshRenderer>().material = mat;
    }
}
