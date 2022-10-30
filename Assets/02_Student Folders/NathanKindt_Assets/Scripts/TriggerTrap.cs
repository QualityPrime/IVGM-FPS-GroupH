using UnityEngine;

namespace FPS.Scripts
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class TriggerTrap : MonoBehaviour
    {
        [Tooltip("Growth Factor")] public GameObject trap;
        
        [Tooltip("Growth Factor")] public float growthFactor;

        [Tooltip("Max Growth size")] public float maxSize;
        
        Pickup m_Pickup;
        private bool grow = false;

        void Awake()
        {
            m_Pickup = GetComponent<Pickup>();
            DebugUtility.HandleErrorIfNullGetComponent<Pickup, ObjectivePickupItem>(m_Pickup, this, gameObject);
            
            // subscribe to the onPick action on the Pickup component
            m_Pickup.onPick += OnPickup;
        }

        void OnPickup(PlayerCharacterController player)
        {
            grow = true;
        }

        private void Update()
        {
            if (grow)
            {
                transform.localScale += Vector3.one * growthFactor;
            }
            if (transform.localScale.magnitude > maxSize)
            {
                Destroy(gameObject);
                trap.SetActive(true);
            }
        }
    }
}
