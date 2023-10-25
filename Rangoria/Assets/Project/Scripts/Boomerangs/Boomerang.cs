using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField]
   protected float damage;
    [SerializeField]
    protected float speed;
    public Rigidbody2D rigidbody;
    public Rigidbody2D posPlayer;
    [SerializeField]
    private Vector2 vectorMove;
    private Vector2 vectorDirection;
    public Vector2 _aimPoint;
    [SerializeField]
    public Vector2 _startPoint;
    protected virtual void ActionBoomerang() { }
   
    public Boomerang(float d, float s)
    {
        damage = d; speed = s; 
    }
        
   protected void Movement()
    {
        vectorDirection = (_aimPoint-_startPoint).normalized;
        vectorMove += vectorDirection * speed * Time.deltaTime;
        rigidbody.MovePosition(_startPoint + vectorMove);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_aimPoint, 1);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(rigidbody.position, 1);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(_startPoint, 1);
    }

}
