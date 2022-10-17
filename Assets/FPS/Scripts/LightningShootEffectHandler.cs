using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LightningShootEffectHandler : MonoBehaviour
{
    [Header("Particles")]
    [Tooltip("Glow to create when charging")]
    public GameObject glowOrbParticlePrefab;
    [Tooltip("Parent transform for the particles (Optional)")]
    public Transform parentTransform;
    
    public GameObject lightningInstance { get; set; }
    
    WeaponController m_WeaponController;
    
    public void Start()
    {
        m_WeaponController = GetComponent<WeaponController>();
        DebugUtility.HandleErrorIfNullGetComponent<WeaponController, ChargedWeaponEffectsHandler>(m_WeaponController, this, gameObject);
    }

    void Update()
    {
        if (m_WeaponController.isShooting && lightningInstance == null)
        {
            lightningInstance = Instantiate(glowOrbParticlePrefab, parentTransform);
        }
        if (!m_WeaponController.isShooting)
        {
            Destroy(lightningInstance);
        }
    }
}
