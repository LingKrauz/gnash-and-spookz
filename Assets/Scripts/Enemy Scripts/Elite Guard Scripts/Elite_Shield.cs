using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elite_Shield : MonoBehaviour
{
    public int durability;
    public GameObject shieldPeice1;
    public GameObject shieldPiece2;

    EliteGuard_Enemy eliteGuard;

    void Start()
    {
        eliteGuard = GetComponentInParent<EliteGuard_Enemy>();
    }

    
    void Update()
    {

    }

    public void TakeDamage(int _damage)
    {
        durability -= _damage;

        if (durability <= 4)
        {
            shieldPeice1.SetActive(false);
        }

        if (durability <= 2)
        {
            shieldPiece2.SetActive(false);
        }

        if (durability <= 0)
        {
            eliteGuard.shieldBreakSFX.Play();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerAttack>())
        {
            eliteGuard.shieldHitSFX.Play();
            TakeDamage(2);
        }

        if(other.tag == "Projectile")
        {
            eliteGuard.shieldHitSFX.Play();
            TakeDamage(2);
        }
    }
}
