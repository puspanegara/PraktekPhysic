using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    #region
    //First Script Area
    /*
    #region
    //Public Area
    public float power = 10f;
    public float maxDrag = 1f;
    public Rigidbody2D rb;
    public LineRenderer lr;
    #endregion

    Vector3 dragStartPos;
    Vector3 draggingPos;
    Vector3 dragRealeasePos;
    Vector3 force;
    Touch touch;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                DragStart();
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                DragRelease();
            }
        }
    }

    void DragStart()
    {
        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0f;
        
        lr.positionCount = 1;
        lr.SetPosition(0, dragStartPos);
        
    }

    void Dragging()
    {
        draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        draggingPos.z = 0f;
        
        lr.positionCount = 2;
        lr.SetPosition(1, draggingPos);
        
    }

    void DragRelease()
    {
        lr.positionCount = 0;
        dragRealeasePos = Camera.main.ScreenToWorldPoint(touch.position);
        dragRealeasePos.z = 0f;

        force = dragStartPos - dragRealeasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

        rb.AddForce(clampedForce, ForceMode2D.Impulse);
    }
    */
    #endregion
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;

    public UIController uiCtrl;
    
    [HideInInspector] public Vector3 pos
    {
        get { return transform.position; }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void ActiveRb()
    {
        rb.isKinematic = false;
    }

    public void DesActiveRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        uiCtrl.LoseLose();
        Debug.Log("Pembatas");
    }
}
