using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton Class : GameManager
    public static GameManager Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    Camera cam;
    //Touch touch;
    public BallControl ball;
    public Trajectory trajectory;
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
        /*
         * Mouse controller
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
        */
    }

    void OnDragStart()
    {
        ball.DesActiveRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        trajectory.Show();
    }
    void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;

        //Debug Only
        Debug.DrawLine(startPoint, endPoint);

        trajectory.UpdateDots(ball.pos, force);
    }
    void OnDragEnd()
    {
        ball.ActiveRb();

        ball.Push(force);
        trajectory.Hide();
    }
}
