using UnityEngine;

namespace FPS.Scripts
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(Animator))]
    public class DoorTrigger : MonoBehaviour
    {
        private Animation m_Animation;
        private Collider m_Collider;
        private bool m_HasPlayedFeedback = false;
        public Rigidbody pickupRigidbody { get; private set; }

        void Awake()
        {
            m_Animation = GetComponent<Animation>();
            DebugUtility.HandleErrorIfNullGetComponent<Animator, DoorTrigger>(m_Animation, this, gameObject);

            pickupRigidbody = GetComponent<Rigidbody>();
            DebugUtility.HandleErrorIfNullGetComponent<Rigidbody, TriggerKey>(pickupRigidbody, this, gameObject);
            m_Collider = GetComponent<Collider>();
            DebugUtility.HandleErrorIfNullGetComponent<Collider, TriggerKey>(m_Collider, this, gameObject);

            // ensure the physics setup is a kinematic rigidbody trigger
            pickupRigidbody.isKinematic = true;
            m_Collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            PlayerCharacterController pickingPlayer = other.GetComponent<PlayerCharacterController>();

            if (!m_HasPlayedFeedback && pickingPlayer != null)
            {
                m_HasPlayedFeedback = true;
                m_Animation.wrapMode = WrapMode.Once;
                m_Animation.Play();
            }
        }
        
    }
}