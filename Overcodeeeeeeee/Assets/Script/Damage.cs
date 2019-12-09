﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float GateDamage = 0.0f;
    [SerializeField] private float NovaDamage = 0.0f;
    [SerializeField] private float RushDamage = 15.0f;

    [SerializeField] private float ThunderDamage = 23.0f;
    [SerializeField] private float PunchDamage = 10.0f;

    [SerializeField] private float LaptopDamage = 0.0f;
    [SerializeField] private float SwordDamage = 0.0f;

    [SerializeField] private float CanvasDamage = 0.0f;
    [SerializeField] private float WaveDamage = 0.0f;

    [SerializeField] private float ShieldMutiplier = 0.1f;

    private GameObject LeftHealth;
    private GameObject RightHealth;

    void Start()
    {
        LeftHealth = GameObject.FindGameObjectWithTag("LeftHB");
        RightHealth = GameObject.FindGameObjectWithTag("RightHB");
    }

    public void TakeDamageGate(bool IsShield)
    {
        var Damage = IsShield ? ShieldMutiplier * GateDamage : GateDamage;
        RightHealth.GetComponent<RightHealthBar>().TakeDamage(Damage);
    }

    public void TakeDamageNova(bool IsShield)
    {
        var Damage = IsShield ? ShieldMutiplier * NovaDamage : NovaDamage;
        RightHealth.GetComponent<RightHealthBar>().TakeDamage(Damage);
    }

    public void TakeDamageRush(bool IsShield)
    {
        var Damage = IsShield ? ShieldMutiplier * RushDamage : RushDamage;
        RightHealth.GetComponent<RightHealthBar>().TakeDamage(Damage);
    }
    public void TakeDamageThunder(bool IsShield)
    {
        var Damage = IsShield ? ShieldMutiplier * ThunderDamage : ThunderDamage;
        RightHealth.GetComponent<RightHealthBar>().TakeDamage(Damage);
    }

    public void TakeDamagePunch(bool IsShield)
    {
        var Damage = IsShield ? ShieldMutiplier * PunchDamage : PunchDamage;
        RightHealth.GetComponent<RightHealthBar>().TakeDamage(Damage);
    }

    public void TakeDamageLaptop(bool IsShield)
    {
        var Damage = IsShield ? ShieldMutiplier * LaptopDamage : LaptopDamage;
        LeftHealth.GetComponent<RightHealthBar>().TakeDamage(Damage);
    }

    public void TakeDamageSword(bool IsShield)
    {
        var Damage = IsShield ? ShieldMutiplier * SwordDamage : SwordDamage;
        LeftHealth.GetComponent<RightHealthBar>().TakeDamage(Damage);
    }

    public void TakeDamageCanvas(bool IsShield)
    {
        var Damage = IsShield ? ShieldMutiplier * CanvasDamage : CanvasDamage;
        LeftHealth.GetComponent<RightHealthBar>().TakeDamage(Damage);
    }

    public void TakeDamageWave(bool IsShield)
    {
        var Damage = IsShield ? ShieldMutiplier * WaveDamage : WaveDamage;
        LeftHealth.GetComponent<RightHealthBar>().TakeDamage(Damage);
    }
}
