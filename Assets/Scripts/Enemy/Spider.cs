using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
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

        base.Update();
    }
}
