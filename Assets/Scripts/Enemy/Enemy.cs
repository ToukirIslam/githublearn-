using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anum;
    protected SpriteRenderer sprite;

    public virtual void Init()
    {
        anum = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Start() 
    {
        Init();
    }
    //public abstract void Update(); initialized like this . there is no implimentation code
    public virtual void Update()
    {
        if (anum.GetCurrentAnimatorStateInfo(0).IsName("moss_idel"))
        { 
            return;
        }
        Movement();
    }
    public virtual void Movement() // virtual because we can overwrite this method
    {
        if (currentTarget == pointA.position)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
            if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anum.SetTrigger("Idel");
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anum.SetTrigger("Idel");
        }
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}
 