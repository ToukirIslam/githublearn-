using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy , IDamagable
{
    public int Health { get; set; }
    //use for initialization
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    public void Damage() { }
}
