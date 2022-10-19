using UnityEngine;

public class ProjectileChargeParameters : MonoBehaviour
{
    public MinMaxFloat damage;
    public MinMaxFloat size;
    public MinMaxFloat radius;
    public MinMaxFloat speed;
    public MinMaxFloat damageArea;
    public MinMaxFloat gravityDownAcceleration;
    public MinMaxFloat VFXscale;
    public GameObject meshToScale;

    ProjectileBase m_ProjectileBase;

    private void OnEnable()
    {
        m_ProjectileBase = GetComponent<ProjectileBase>();
        DebugUtility.HandleErrorIfNullGetComponent<ProjectileBase, ProjectileChargeParameters>(m_ProjectileBase, this, gameObject);

        m_ProjectileBase.onShoot += OnShoot;
    }

    void OnShoot()
    {
        // Apply the parameters based on projectile charge
        ProjectileStandard proj = GetComponent<ProjectileStandard>();
        DamageArea dmgArea = GetComponent<DamageArea>();
        if(proj)
        {
            proj.damage = damage.GetValueFromRatio(m_ProjectileBase.initialCharge);
            proj.radius = radius.GetValueFromRatio(m_ProjectileBase.initialCharge);
            proj.speed = speed.GetValueFromRatio(m_ProjectileBase.initialCharge);
            proj.gravityDownAcceleration = gravityDownAcceleration.GetValueFromRatio(m_ProjectileBase.initialCharge);
            proj.VFXscale = VFXscale.GetValueFromRatio(m_ProjectileBase.initialCharge);
            meshToScale.transform.localScale *= size.GetValueFromRatio(m_ProjectileBase.initialCharge);
            
            proj.UpdateVelocity();
        }

        if (dmgArea)
        {
            dmgArea.areaOfEffectDistance = damageArea.GetValueFromRatio(m_ProjectileBase.initialCharge);
        }
    }
}
