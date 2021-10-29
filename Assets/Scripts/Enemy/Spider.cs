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
        //this is to check that their oure current project is still working .
        debug.log("hellow this is the github ");
        base.Update();
    }
}
