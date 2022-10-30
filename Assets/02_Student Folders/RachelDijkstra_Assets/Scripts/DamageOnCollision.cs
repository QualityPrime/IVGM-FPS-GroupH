using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Unity.FPS.Game;

public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] float Damage = 5f;

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage(other);
    }
    
    private void OnTriggerStay(Collider other)
    {
        TakeDamage(other);
    }

    private void TakeDamage(Collider other)
    {
        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable)
        {
            damageable.InflictDamage(Damage, false, gameObject);
        }
    }
}