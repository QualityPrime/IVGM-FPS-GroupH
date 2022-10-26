using System;
using UnityEngine;
using UnityEngine.Events;

namespace FPS.Scripts
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class TriggerTrap : MonoBehaviour
    {
        [Tooltip("Growth Factor")] public GameObject trap;
        
        [Tooltip("Growth Factor")] public float growthFactor;

        [Tooltip("Max Growth size")] public float maxSize;
        
        Pickup m_Pickup;
        Objective m_Objective;
        private bool grow = false;

        void Awake()
        {
            m_Objective = GetComponent<Objective>();
            DebugUtility.HandleErrorIfNullGetComponent<Objective, ObjectivePickupItem>(m_Objective, this, gameObject);

            m_Pickup = GetComponent<Pickup>();
            DebugUtility.HandleErrorIfNullGetComponent<Pickup, ObjectivePickupItem>(m_Pickup, this, gameObject);
            
            // subscribe to the onPick action on the Pickup component
            m_Pickup.onPick = OnPickup;
        }

        void OnPickup(PlayerCharacterController player)
        {
            if (m_Objective.isCompleted)
                return;

            // this will trigger the objective completion
            // it works even if the player can't pickup the item (i.e. objective pickup healthpack while at full heath)
            m_Objective.CompleteObjective(string.Empty, string.Empty, "Objective complete : " + m_Objective.title);

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
