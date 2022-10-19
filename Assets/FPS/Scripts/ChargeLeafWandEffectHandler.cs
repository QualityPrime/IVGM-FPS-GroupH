using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ChargeLeafWandEffectHandler : MonoBehaviour
{
    [Header("Visual")]
    [Tooltip("Object that will be affected by charging scale & color changes")]
    public GameObject chargingObject;
    [Tooltip("Scale of the charged object based on charge")]
    public MinMaxVector3 scale;
    [Tooltip("Scale of the charged object based on charge")]
    public float rotateSpeed;

    [Header("Particles")]
    [Tooltip("Particles to create when charging")]
    public GameObject diskOrbitParticlePrefab;
    [Tooltip("Glow to create when charging")]
    public GameObject glowOrbParticlePrefab;
    [Tooltip("Local position offset of the charge particles (relative to this transform)")]
    public Vector3 offset;
    [Tooltip("Parent transform for the particles (Optional)")]
    public Transform parentTransform;
    [Tooltip("Orbital velocity of the charge particles based on charge")]
    public MinMaxFloat orbitY;
    [Tooltip("Radius of the charge particles based on charge")]
    public MinMaxVector3 radius;
    [Tooltip("Idle spinning speed of the frame based on charge")]
    public MinMaxFloat spinningSpeed;

    [Header("Sound")]
    [Tooltip("Audio clip for charge SFX")]
    public AudioClip chargeSound;
    [Tooltip("Sound played in loop after the change is full for this weapon")]
    public AudioClip loopChargeWeaponSFX;
    [Tooltip("Duration of the cross fade between the charge and the loop sound")]
    public float fadeLoopDuration = 0.5f;

    public GameObject particleInstance { get; set; }
    public GameObject glowInstance { get; set; }

    ParticleSystem m_DiskOrbitParticle;
    ParticleSystem m_GlowOrbParticle;
    WeaponController m_WeaponController;
    ParticleSystem.VelocityOverLifetimeModule m_VelocityOverTimeModule;

    AudioSource m_AudioSource;
    AudioSource m_AudioSourceLoop;

    float m_LastChargeTriggerTimestamp;
    float m_ChargeRatio;
    float m_EndchargeTime;

    void Awake()
    {
        m_LastChargeTriggerTimestamp = 0.0f;

        // The charge effect needs it's own AudioSources, since it will play on top of the other gun sounds
        m_AudioSource = gameObject.AddComponent<AudioSource>();
        m_AudioSource.clip = chargeSound;
        m_AudioSource.playOnAwake = false;
        m_AudioSource.outputAudioMixerGroup = AudioUtility.GetAudioGroup(AudioUtility.AudioGroups.WeaponChargeBuildup);

        // create a second audio source, to play the sound with a delay
        m_AudioSourceLoop = gameObject.AddComponent<AudioSource>();
        m_AudioSourceLoop.clip = loopChargeWeaponSFX;
        m_AudioSourceLoop.playOnAwake = false;
        m_AudioSourceLoop.loop = true;
        m_AudioSourceLoop.outputAudioMixerGroup = AudioUtility.GetAudioGroup(AudioUtility.AudioGroups.WeaponChargeLoop);
    }

    void SpawnParticleSystem()
    {
        particleInstance = Instantiate(diskOrbitParticlePrefab, parentTransform != null ? parentTransform : transform);
        particleInstance.transform.localPosition += offset;
        
        glowInstance = Instantiate(glowOrbParticlePrefab, parentTransform != null ? parentTransform : transform);
        glowInstance.transform.localPosition += offset;
        
        FindReferences();
    }

    public void FindReferences()
    {
        m_DiskOrbitParticle = particleInstance.GetComponent<ParticleSystem>();
        DebugUtility.HandleErrorIfNullGetComponent<ParticleSystem, ChargedWeaponEffectsHandler>(m_DiskOrbitParticle, this, particleInstance.gameObject);
        
        m_GlowOrbParticle = glowInstance.GetComponent<ParticleSystem>();
        DebugUtility.HandleErrorIfNullGetComponent<ParticleSystem, ChargedWeaponEffectsHandler>(m_GlowOrbParticle, this, glowInstance.gameObject);

        m_WeaponController = GetComponent<WeaponController>();
        DebugUtility.HandleErrorIfNullGetComponent<WeaponController, ChargedWeaponEffectsHandler>(m_WeaponController, this, gameObject);

        m_VelocityOverTimeModule = m_DiskOrbitParticle.velocityOverLifetime;
    }

    void Update()
    {
        if (particleInstance == null)
            SpawnParticleSystem();

        m_DiskOrbitParticle.gameObject.SetActive(m_WeaponController.isWeaponActive);

        if (m_WeaponController.isWeaponActive)
        {
            m_GlowOrbParticle.gameObject.SetActive(m_WeaponController.isWeaponActive);
        }
        else
        {
            m_GlowOrbParticle.gameObject.SetActive(m_WeaponController.isWeaponActive);
            m_GlowOrbParticle.Clear();
        }
        
        m_ChargeRatio = m_WeaponController.currentCharge;
        
        chargingObject.transform.Rotate(0, 0, rotateSpeed * m_ChargeRatio); //chargingObject.transform.eulerAngles.z
        chargingObject.transform.localScale = scale.GetValueFromRatio(m_ChargeRatio);

        m_VelocityOverTimeModule.orbitalY = orbitY.GetValueFromRatio(m_ChargeRatio);
        m_DiskOrbitParticle.transform.localScale = radius.GetValueFromRatio(m_ChargeRatio * 1.0f);
        m_GlowOrbParticle.transform.localScale = radius.GetValueFromRatio(m_ChargeRatio * 1.8f);

        // update sound's volume and pitch 
        if (m_ChargeRatio > 0)
        {
            if (!m_AudioSource.isPlaying && m_WeaponController.LastChargeTriggerTimestamp > m_LastChargeTriggerTimestamp)
            {
                m_LastChargeTriggerTimestamp = m_WeaponController.LastChargeTriggerTimestamp;
                m_EndchargeTime = Time.time + chargeSound.length;

                m_AudioSource.Play();
                m_AudioSourceLoop.Play();
            }

            float volumeRatio = Mathf.Clamp01((m_EndchargeTime - Time.time - fadeLoopDuration) / fadeLoopDuration);

            m_AudioSource.volume = volumeRatio;
            m_AudioSourceLoop.volume = 1 - volumeRatio;
        }
        else
        {
            m_AudioSource.Stop();
            m_AudioSourceLoop.Stop();
        }
    }
}
