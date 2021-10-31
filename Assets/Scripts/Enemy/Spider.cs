using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamagable
{
    public int Health { get; set; }
    public override void Init()
    {
        base.Init();
    }
    public override void Update()
    {
        if (anum.GetCurrentAnimatorStateInfo(0).IsName("spider_idel"))
        {
            return;
        }
        //this is to check that their oure current project is still working .
        base.Update();
    }
    public void Damage() { }
}
