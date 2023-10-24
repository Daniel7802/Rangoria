using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
   protected float damage;
   protected float speed;
    public Rigidbody2D rigidbody;
    Transform posPlayer;
    protected virtual void ActionBoomerang() { }
   
    public Boomerang(float d, float s, Rigidbody2D rb)
    {
        damage = d; speed = s; rigidbody = rb;  
    }
        
    
    
}
