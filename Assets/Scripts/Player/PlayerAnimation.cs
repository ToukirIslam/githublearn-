using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anum;
    private Animator sword_anam;
    void Start()
    {
        anum = GetComponent<Animator>();
        sword_anam = transform.GetChild(1).GetComponent<Animator>();
    }
    public void Move(float move)
    {
        anum.SetFloat("Move", Mathf.Abs(move)); //unable has exit time . bcz if it is on player will finish animation than change state
        //make transation duration 0 cz we dont need to faded our animation . no need to smooth it 
    }
    public void Jump(bool jump)
    {
        anum.SetBool("Jump", jump);
    }
    public void Attack()
    {
        anum.SetTrigger("Attack");
        sword_anam.SetTrigger("SwordAnimation");
    }
}
