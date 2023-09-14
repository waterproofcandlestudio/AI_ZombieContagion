// Sample code of the "CustomEvents_SantiagoMachínCavallé"
using UnityEngine;

public class EventManagerUnity : MonoBehaviour
{
    public delegate void OnStartAction();
    public static event OnStartAction myOnStart;

    public delegate void OnQPress();
    public static event OnQPress myOnQPress;

    public delegate void OnSpaceAction(float value);
    public static event OnSpaceAction myOnSpacePress;

    // Value to pass throught the FloatEvent
    [SerializeField] private float value;

    // Start is called before the first frame update
    private void Start()
    {
        myOnStart();
        Debug.Log("OnStartAction invoked");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myOnSpacePress(value);
            Debug.Log("OnSpaceAction invoked");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            myOnQPress();
            Debug.Log("OnQPress invoked");
        }
    }
}
