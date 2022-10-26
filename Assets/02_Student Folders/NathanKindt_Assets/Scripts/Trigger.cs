using UnityEngine;
using UnityEngine.Events;

namespace FPS.Scripts
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Trigger : MonoBehaviour
    {
        [Tooltip("Clip to play on impact")] public GameObject aThing;
        Pickup m_Pickup;

        void Awake()
        {
            m_Pickup = GetComponent<Pickup>();
            DebugUtility.HandleErrorIfNullGetComponent<Pickup, ObjectivePickupItem>(m_Pickup, this, gameObject);
            // subscribe to the onPick action on the Pickup component
            m_Pickup.onPick += OnPickup;
        }

        void OnPickup(PlayerCharacterController player)
        {
            aThing.transform.localPosition += Vector3.up * 3f;
        }
    }
}
