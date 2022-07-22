
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float EnemyHitpoints = 100f;
    [SerializeField] GameObject BloodEffect;
    [SerializeField] Canvas Health;
    [SerializeField] Slider slider;
    AudioSource audioSource;

    bool isdead = false;

    private void Start()
    {
        Health.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    public bool Isdead()
    {
        return isdead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        EnemyHitpoints -= damage;

        if (EnemyHitpoints <= 0)
        {
            Die();
        }

        //Effect of blood
        BloodVFX();
        StartCoroutine(HealthCanvas());

    }

    IEnumerator HealthCanvas()
    {
        Health.enabled = true;
        slider.value = EnemyHitpoints;
        yield return new WaitForSeconds(2);
        Health.enabled = false;
    }

    private void Die()
    { 
        if (isdead) return;
        isdead = true;
        GetComponent<Animator>().SetTrigger("Die");
        audioSource.Stop();
        Health.enabled = false;
    }

    private void BloodVFX()
    {
        GameObject Impact = Instantiate(BloodEffect, transform.position, Quaternion.LookRotation(transform.forward));
        Destroy(Impact, 1);
    }
}
