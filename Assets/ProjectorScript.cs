using UnityEngine;

public class ProjectorScript : MonoBehaviour
{
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;
    public GameObject projector;
    private Material[] consoleMatRef;
    private Material remoteMatRef;
    public Material blueScreen;
    public GameObject console;
    public Material whiteScreen;
    public GameObject remoteColor;

    void Start()
    {
        consoleMatRef = console.GetComponent<Renderer>().materials;
        remoteMatRef = remoteColor.GetComponent<Renderer>().material;
    }

    /// <summary> Method <c> OnTriggerEnter</c> activates the particle system</summary>
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Remote"))
        {
            if(openTrigger)
            {
                projector.SetActive(true);
                consoleMatRef[1] = whiteScreen;
                remoteMatRef = blueScreen;
                console.GetComponent<Renderer>().materials = consoleMatRef;
                remoteColor.GetComponent<Renderer>().material = remoteMatRef;
            }
            else if (closeTrigger)
            {
                projector.SetActive(false);

            }
        }
    }
}
