using UnityEngine;

public class CubeMoveUppwards : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManagerUnity.myOnSpacePress += MoveUppwards;
    }

    private void OnDestroy()
    {
        EventManagerUnity.myOnSpacePress -= MoveUppwards;
    }

    private void MoveUppwards(float amount)
    {
        Vector3 newpos;
        newpos.x = this.transform.position.x;
        newpos.z = this.transform.position.z;
        newpos.y = this.transform.position.y + amount;

        transform.position = newpos;
    }
}
