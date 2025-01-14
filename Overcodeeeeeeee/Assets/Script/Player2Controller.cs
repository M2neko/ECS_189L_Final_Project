﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    [SerializeField] private GameObject Playground;
    [SerializeField] private float Speed;
    [SerializeField] private GameObject player2_1;
    [SerializeField] private GameObject player2_2;
    [SerializeField] private GameObject player1_1;
    [SerializeField] private GameObject player1_2;
    [SerializeField] private GameObject TakeDamage;
    [SerializeField] private bool IsStart = true;
    private float xrange;
    private float leftrange;
    private float rightrange;
    private GameObject player1;
    private Vector3 Change;
    private Rigidbody2D PlayerRigidbody;
    private Animator PlayerAnimator;
    private bool IsDown = false;
    private bool IsShield = false;
    private bool IsMotivate = false;
    private bool IsDead = false;

    private void Start()
    {
        xrange = Playground.GetComponent<BoxCollider2D>().size.x * 15;
        leftrange = Playground.transform.position.x - xrange + 0.1f;
        rightrange = Playground.transform.position.x + xrange - 0.1f;
        if (player1_1.activeInHierarchy)
        {
            player1 = player1_1;
        }
        else
        {
            player1 = player1_2;
        }
        PlayerAnimator = this.GetComponent<Animator>();
        PlayerRigidbody = this.GetComponent<Rigidbody2D>();
        StartCoroutine(StartAnimator());
    }

    private void Update()
    {
        if (Input.GetButtonDown("Player2Skill2") && !IsHold())
        {
            if (player2_1.activeInHierarchy)
            {
                this.GetComponent<ShootLaptop>().Shoot();
            }

            if (player2_2.activeInHierarchy)
            {
                this.GetComponent<ShootCanvas>().Shoot();
            }
        }
        if (Input.GetButtonDown("Player2Skill1") && !IsHold())
        {
            if (player2_1.activeInHierarchy)
            {
                this.GetComponent<PerformSword>().Perform();
            }

            if (player2_2.activeInHierarchy)
            {
                this.GetComponent<ControlWave>().Control();
            }
        }
        if (Input.GetButton("Player2Shield") && ((!IsHold()) || IsShield))
        {
            PlayerAnimator.SetBool("Shield", true);
            IsShield = true;
        }
        else
        {
            PlayerAnimator.SetBool("Shield", false);
            IsShield = false;
        }
        var targetposition = this.gameObject.transform.position;
        if (this.gameObject.transform.position.x >= player1.transform.position.x)
        {
            if ((!IsHold()) || IsShield)
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            if ((!IsHold()) || IsShield)
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetButtonDown("Player2Jump") && this.gameObject.transform.position.y <= -3.32f && !IsHold()) 
        {
            PlayerRigidbody.AddForce(Vector2.up * 3000);
        }
        if (Input.GetButton("Player2Down") && ((!IsHold()) || IsDown))
        {
            PlayerAnimator.SetBool("Down", true);
            IsDown = true;
        }
        else
        {
            PlayerAnimator.SetBool("Down", false);
            IsDown = false;
        }

        Change.x = Input.GetAxisRaw("Player2Horizontal");

        if (IsMotivate && !IsHold())
        {
            IsMotivate = false;
        }

        if (!IsHold())
            PlayerAnimator.SetFloat("Speed", Mathf.Abs(Change.x * Speed));

        Move();

        if (this.gameObject.transform.position.x <= leftrange)
        {
            targetposition = new Vector3(leftrange, targetposition.y, targetposition.z);
        }
        if (this.gameObject.transform.position.x >= rightrange)
        {
            targetposition = new Vector3(rightrange, targetposition.y, targetposition.z);
        }
        if (this.gameObject.transform.position.y < -5.0f)
        {
            targetposition = new Vector3(targetposition.x, -3.665f, targetposition.z);
        }
        this.gameObject.transform.position = targetposition;

        if (TakeDamage.GetComponent<Damage>().IsPlayer2Dead())
        {
            PlayerAnimator.SetBool("Dead", true);
            EndGame.IsEnd = true;
            IsDead = true;
        }

        if (EndGame.IsEnd || EndGame.IsExpired)
        {
            PlayerAnimator.SetFloat("Speed", 0.0f);
        }
    }

    public GameObject OtherPlayer()
    {
        return player1;
    }

    private void Move()
    {
        if (IsHold())
            return;

        PlayerRigidbody.MovePosition(transform.position + Change * Speed * Time.deltaTime);
    }

    private bool IsHold()
    {
        return this.IsDown || ShootCanvas.IsBullet || PerformSword.IsSword || this.IsStart
            || this.IsShield || ControlWave.IsWave || EndGame.IsEnd
            || EndGame.IsExpired;
    }

    public bool IsPlayerShield() => IsShield;

    public bool IsPlayerDead() => IsDead;

    private IEnumerator StartAnimator()
    {
        this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        yield return new WaitForSeconds(3.0f);
        this.GetComponent<Animator>().SetBool("Start", false);
        this.IsStart = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("2 is attacked Collision");

        var IsDefense = player1.GetComponent<PlayerController>().IsPlayerShield();

        if (other.collider.CompareTag("Player1"))
        {
            if (PerformSword.IsSword && !IsMotivate)
            {
                TakeDamage.GetComponent<Damage>().TakeDamageSword(IsDefense);
                IsMotivate = true;
            }
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        var IsDefense = player1.GetComponent<PlayerController>().IsPlayerShield();

        if (other.collider.CompareTag("Player1"))
        {
            if (PerformSword.IsSword && !IsMotivate)
            {
                TakeDamage.GetComponent<Damage>().TakeDamageSword(IsDefense);
                IsMotivate = true;
            }
        }
    }
}