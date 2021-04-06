﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerA : MonoBehaviour
{
    #region Singleton Class : GameManager
    public static GameManagerA Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    Camera cam;
    public BallControl ball;
    public int moveCount;
    public int stars;
    public int move3Stars;
    public int move2Stars;
    public int move1Stars;
    public LingakaranPlayer lingkaran;
    public int inCircle;
    public UIController uiCtrl;

    //public Trajectory trajectory;
    [SerializeField] float pushForce = 4f;

    bool isDragging = false;
    Touch touch;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;
    void Start()
    {
        cam = Camera.main;
        ball.DesActiveRb();
    }
    void Update()
    {
        //Touch Controller (Smartphone)
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                OnDragStart();
            }

            if (touch.phase == TouchPhase.Moved)
            {
                OnDrag();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
                OnDragEnd();
            }
        }

        // Mouse controller
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            OnDragStart();
        }

        if (isDragging)
        {
            OnDrag();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            OnDragEnd();
        }
        PlayerStars();
    }

    void OnDragStart()
    {
        ball.DesActiveRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        //trajectory.Show();
    }
    void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;

        //Debug Only
        // Debug.DrawLine(startPoint, endPoint);

        //trajectory.UpdateDots(ball.pos, force);
    }
    void OnDragEnd()
    {
        ball.ActiveRb();
        ball.Push(force);
        //trajectory.Hide();
        moveCount += 1;
        Debug.Log("Player Move : " + moveCount);
        uiCtrl.uiMoveCount.text = "Player Move : " + moveCount.ToString();
        Debug.Log(uiCtrl.uiMoveCount.text = "Move Count : " + moveCount);
    }

    void PlayerStars()
    {
        if (moveCount <= move3Stars)
        {
            stars = 3;
            uiCtrl.uiStars.text = "Stars : " + stars.ToString();
        }
        if (moveCount == move2Stars)
        {
            stars = 2;
            uiCtrl.uiStars.text = "Stars : " + stars.ToString();
        }
        if (moveCount >= move1Stars)
        {
            stars = 1;
            uiCtrl.uiStars.text = "Stars : " + stars.ToString();
        }
    }
}