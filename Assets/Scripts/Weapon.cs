using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float Range = 100f;
    [SerializeField] float Damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] AudioSource FireSound;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo AmmoSlot;
    [SerializeField] Ammotype ammoType;
    [SerializeField] float FiringRate = 0.2f;
    [SerializeField] TextMeshProUGUI ammoText;

    float nextFire = 0.0f;

    // Update is called once per frame
    void Update()
    {
        DisplayAmmmo();
        if (Input.GetMouseButtonDown(0) && nextFire < Time.time)
        {
            nextFire = Time.time + FiringRate;
            Shoot();
        } 
    
    }

    private void DisplayAmmmo()
    {
        int CurrentAmmo = AmmoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = $"{AmmoSlot.GetAmmoName(ammoType)} : {CurrentAmmo.ToString()}";
    }

    void Shoot()
    {
        if (AmmoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            PlayFireSound();
            ProcessRayCast();
            AmmoSlot.ReduceCurrentAmmo(ammoType);
        }
    }

    private void PlayFireSound()
    {
        FireSound.Play();
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play(); 
    }



    private void ProcessRayCast()
    {
        RaycastHit Hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out Hit, Range))
        {
            Debug.Log("You are hitting" + Hit.transform.name);
            CreateHitImpact(Hit);
            EnemyHealth Target = Hit.transform.GetComponent<EnemyHealth>();
            if (Target == null)
            {
                return;
            }
            Target.TakeDamage(Damage);
            
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit Hit)
    {
        if (Hit.transform.tag != "Enemy")
        {
            GameObject Impact = Instantiate(hitEffect, Hit.point, Quaternion.LookRotation(Hit.normal));
            Destroy(Impact, 0.1f);
            Debug.Log(Hit.transform.tag);
        }
        else return;
    }
}


