using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;

    public UIController uiCtrl;
    public GameManager gm;
    public float addForce;
    public Animator animator;
    public int moveCount;

    [HideInInspector] public Vector3 pos
    {
        get { return transform.position; }
    }
    Camera cam;
    public float pushForce = 4f;
    bool isDragging = false;
    public bool marbleMove;
    Touch touch;
    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    float distance;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        cam = Camera.main;
        moveCount = 0;
    }
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();

        #region Touch Controller
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
                animator.SetBool("move", true);
            }
        }
        #endregion

        #region Mouse Controller
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
            animator.SetBool("move", true);
        }
        #endregion
    }

    void OnDragStart()
    {
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        //trajectory.Show();
    }
    void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        rb.velocity = direction * distance * pushForce;
        //Debug Only
        // Debug.DrawLine(startPoint, endPoint);
        //trajectory.UpdateDots(ball.pos, force);

    }
    public void OnDragEnd()
    {
        moveCount++;
        //trajectory.Hide();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mantul")
        {
            rb.velocity = new Vector2(pushForce * 1.5f, rb.velocity.y);
        }
    }
}
