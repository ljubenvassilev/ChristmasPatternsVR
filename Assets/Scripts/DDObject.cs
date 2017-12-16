using UnityEngine;

public class DDObject : MonoBehaviour, DragDropHandler
{
    public Material gazedAtMaterial, inactiveMaterial;
    private bool isHeld;
    private GameObject reticle;
    public GameObject scriptPrefab;
    private GameManagerScript script;

    void Start()
    {
        isHeld = false;
        reticle = GameObject.Find("GvrReticlePointer");
        script = scriptPrefab.GetComponent<GameManagerScript>();
    }

    void Update()
    {
        if (isHeld)
        {
            Ray ray = new Ray(reticle.transform.position, reticle.transform.forward);
            transform.position = ray.GetPoint(5);
        }
    }

    public void HandleGazeTriggerStart(int index)
    {
        isHeld = true;
        script.SetHeld(index);
        AudioSource audio = GetComponentInParent<AudioSource>();
		audio.Play ();
    }
    public void HandleGazeTriggerEnd()
    {
        isHeld = false;
        script.Unhold();
    }

    public void SetGazedAt(bool gazedAt)
    {
        if (inactiveMaterial != null && gazedAtMaterial != null)
        {
            GetComponent<Renderer>().material = gazedAt ? gazedAtMaterial : inactiveMaterial;
            return;
        }
        GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
    }
}