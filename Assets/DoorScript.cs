using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;
    
    public Material redLight;
    public Material greenLight;
    public Material whiteScreen;
    private Material[] doorLightMatRef;
    private Material[] consoleMatRef;
    private Material remoteMatRef;
    public GameObject doorLight;
    public GameObject console;
    public GameObject remoteColor;

    void Start()
    {
        doorLightMatRef = doorLight.GetComponent<Renderer>().materials;
        consoleMatRef = console.GetComponent<Renderer>().materials;
        remoteMatRef = remoteColor.GetComponent<Renderer>().material;
        
        // Debug.Log(doorLightMatRef[0]);
        // Debug.Log(doorLightMatRef[1]);
    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Remote"))
        {
            if(openTrigger)
            {
                myDoor.Play("doorOpen", 0, 0.0f);
                doorLightMatRef[1] = greenLight;
                consoleMatRef[1] = whiteScreen;
                remoteMatRef = greenLight;
                doorLight.GetComponent<Renderer>().materials = doorLightMatRef;
                console.GetComponent<Renderer>().materials = consoleMatRef;
                remoteColor.GetComponent<Renderer>().material = remoteMatRef;
                // Debug.Log(doorLightMatRef[1]);
            }
            else if (closeTrigger)
            {
                myDoor.Play("doorClose", 0, 0.0f);
                doorLightMatRef[1] = redLight
        ;
            }
        }
    }
}
