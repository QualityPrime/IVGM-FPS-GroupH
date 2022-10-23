using UnityEditor;
using UnityEngine;

public class BobWisp : MonoBehaviour
{
    [Tooltip("Frequency at which the weapon will move around in the screen when the player is not in movement")]
    public float bobFrequency = 1f;
    [Tooltip("How fast the weapon bob is applied, the bigger value the fastest")]
    public float bobAmplitude = 1f;
    [Tooltip("FlickerLight")]
    public GameObject flickerLight;
    [Tooltip("LightFlicker")]
    public float flickerFrequency = 1f;
    [Tooltip("LightFlicker")]
    public float flickerAmplitude = 1f;

    private Behaviour halo;
    private float rootY;

    private void Awake()
    {
        // halo = (Behaviour)flickerLight.GetComponent("Halo");
        // halo = new SerializedObject(flickerLight.GetComponent<Halo>());
        rootY = transform.localPosition.y;
    }

    private void Update()
    {
        var pos = transform.localPosition;
        var bob = Mathf.Sin(Time.time * bobFrequency) * bobAmplitude;
        transform.localPosition = new Vector3(pos.x, rootY + bob, pos.z);
        // halo.enabled = false;
        // print(getC));
    }
}