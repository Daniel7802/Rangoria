using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    Vector3 pointA;
    [SerializeField]
    Vector3 pointB;
    [SerializeField]
    Vector3 vectorLineal;
    [SerializeField]
    Vector3 moveVector;
    [SerializeField]
    float moveSpeed = 2f;
    [SerializeField]
    bool movement;
    [SerializeField]
    float time;
    [SerializeField]
    int directions;
    [SerializeField]
    bool onAir;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VectorAB();
       
         
    }
    private void FixedUpdate()
    {
        if (movement)
        {
            BoomerangMove(moveVector);
            ChangeDirection();
            moveVector = (pointB - pointA).normalized;
            if (directions == 2)
            {
                movement = false;
                directions = 0;
                onAir = false;  
            }
        }
    }

    void VectorAB()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!onAir)
            {
                pointB = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pointA = transform.position;
                pointB.z = 0f; // zero z
                pointA.z = 0f; // zero z
                moveVector = (pointB - pointA).normalized;               // 
                movement = true;
                onAir = true;
            }            
        }
    }

    void BoomerangMove(Vector3 vector3)
    {
        time = Time.deltaTime;
        vectorLineal += vector3 * moveSpeed * time;
        rb.MovePosition(vectorLineal);
      
    }

    void ChangeDirection()
    {
        if (pointA.x < pointB.x)
        {
            if (vectorLineal.x >= pointB.x)
            {
                var a = pointA;
                pointA = pointB;
                pointB = a;
                directions++;

            }
        }
        else
        {
            if (vectorLineal.x <= pointB.x)
            {
                var a = pointA;
                pointA = pointB;
                pointB = a;
                directions++;
            }
        }
    }

   
    
    
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(pointB, 1);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(pointA, 1);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(vectorLineal, 1);
    }
}
