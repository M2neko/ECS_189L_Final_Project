﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject BG1;
    public GameObject BG2;

    public Text Timer;
    public Text TimerUp;

    public GameObject HP1_1;
    public GameObject HP2_1;
    public GameObject HP1_2;
    public GameObject HP2_2;

    public GameObject HPBar_1;
    public GameObject HPBar_2;

    public GameObject Character1_1;
    public GameObject Character1_2;
    public GameObject Character2_1;
    public GameObject Character2_2;

    public GameObject Win_1;
    public GameObject Win_2;
    public GameObject Win_3;
    public GameObject Win_4;

    public GameObject Button;

    private bool isStart = false;

    private float GameTimer = 0;

    private int ShowTimer = 100;

    void Start()
    {

        StartCoroutine(DoStart());

        if (GameManager.Ins.Background == 1)
        {
            BG1.SetActive(true);
            BG2.SetActive(false);
        }
        if (GameManager.Ins.Background == 2)
        {
            BG1.SetActive(false);
            BG2.SetActive(true);
        }

        if (GameManager.Ins.Character1Select == 1)
        {
            HP1_1.SetActive(true);
            Character1_1.SetActive(true);
        }

        if (GameManager.Ins.Character1Select == 2)
        {
            HP1_2.SetActive(true);
            Character1_2.SetActive(true);
        }

        if (GameManager.Ins.Character2Select == 1)
        {
            HP2_1.SetActive(true);
            Character2_1.SetActive(true);
        }

        if (GameManager.Ins.Character2Select == 2)
        {
            HP2_2.SetActive(true);
            Character2_2.SetActive(true);
        }

        HPBar_1.SetActive(true);
        HPBar_2.SetActive(true);

        Win_1.SetActive(false);
        Win_2.SetActive(false);
        Win_3.SetActive(false);
        Win_4.SetActive(false);

        Button.SetActive(false);
        EndGame.IsEnd = false;
        EndGame.IsExpired = false;
        EndGame.IsFinish = false;
    }


    private IEnumerator DoStart()
    {
        yield return new WaitForSeconds(1);
        Timer.text = "2";
        yield return new WaitForSeconds(1);
        Timer.text = "1";
        yield return new WaitForSeconds(1);
        Timer.text = "GO";
        yield return new WaitForSeconds(1);
        Timer.gameObject.SetActive(false);
        isStart = true;
    }

    void Update()
    {
        if (isStart && !EndGame.IsEnd)
        {
            GameTimer += Time.deltaTime;
            if (GameTimer >= 1)
            {
                GameTimer = 0;
                ShowTimer -= 1;
                TimerUp.text = ShowTimer.ToString();
            }
            if (ShowTimer <= 0)
            {
                isStart = false;
                EndGame.IsExpired = true;
            }
        }
    }
}
