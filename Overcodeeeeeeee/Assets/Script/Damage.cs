﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private GameObject LeftHealth;
    [SerializeField] private GameObject RightHealth;

    [SerializeField] private float GateDamage = 5.0f;
    [SerializeField] private float RushDamage = 15.0f;

    [SerializeField] private float ThunderDamage = 23.0f;
    [SerializeField] private float PunchDamage = 10.0f;

    [SerializeField] private float LaptopDamage = 10.0f;
    [SerializeField] private float SwordDamage = 14.0f;

    [SerializeField] private float CanvasDamage = 7.0f;
    [SerializeField] private float WaveDamage = 17.0f;

    [SerializeField] private float ShieldMutiplier = 0.1f;

    public void TakeDamageGate(bool IsShield)
    {
        var Damage = IsShield ? ShieldMutiplier * GateDamage : GateDamage;
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
        LeftHealth.GetComponent<LeftHealthBar>().TakeDamage(Damage);
    }

    public void TakeDamageSword(bool IsShield)
    {
        var Damage = IsShield ? ShieldMutiplier * SwordDamage : SwordDamage;
        Damage *= Random.Range(1, 3);
        LeftHealth.GetComponent<LeftHealthBar>().TakeDamage(Damage);
    }

    public void TakeDamageCanvas(bool IsShield)
    {
        var Damage = IsShield ? ShieldMutiplier * CanvasDamage : CanvasDamage;
        LeftHealth.GetComponent<LeftHealthBar>().TakeDamage(Damage);
    }

    public void TakeDamageWave(bool IsShield)
    {
        var Damage = IsShield ? ShieldMutiplier * WaveDamage : WaveDamage;
        Damage += Random.Range(-5.0f, 5.0f);
        LeftHealth.GetComponent<LeftHealthBar>().TakeDamage(Damage);
    }

    public void TakeDamageContact(bool IsShield)
    {
        var Damage = IsShield ? ShieldMutiplier * WaveDamage : WaveDamage;
        Damage += Random.Range(-5.0f, 5.0f);
        LeftHealth.GetComponent<LeftHealthBar>().TakeDamage(Time.deltaTime * Damage);
    }

    public int ChooseWinner()
    {
        var left = LeftHealth.GetComponent<LeftHealthBar>().GetHp();
        var right = RightHealth.GetComponent<RightHealthBar>().GetHp();

        var dead1 = LeftHealth.GetComponent<LeftHealthBar>().IsDead();
        var dead2 = RightHealth.GetComponent<RightHealthBar>().IsDead();

        //Debug.Log(left);
        //Debug.Log(right);

        if (System.Math.Abs(left - right) < Mathf.Epsilon)
        {
            return 5;
        }
        if (left > right)
        {
            if (dead2)
                return 1;
            else
                return 2;
        }
        if (right > left)
        {
            if (dead1)
                return 3;
            else
                return 4;
        }
        return 6;
    }

    public bool IsPlayer1Dead() => LeftHealth.GetComponent<LeftHealthBar>().IsDead();

    public bool IsPlayer2Dead() => RightHealth.GetComponent<RightHealthBar>().IsDead();
}
