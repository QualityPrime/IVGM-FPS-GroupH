using UnityEngine;

public class BobWhisp : MonoBehaviour
{
    [Tooltip("Frequency at which the weapon will move around in the screen when the player is not in movement")]
    public float idleBobFrequency = 10f;
    [Tooltip("How fast the weapon bob is applied, the bigger value the fastest")]
    public float idleBobSharpness = 1f;

    private void Update()
    {
        Vector3 trans = Vector3.up * Mathf.Sin(Time.time * idleBobFrequency) * idleBobSharpness;
        transform.localPosition += trans;
    }
}