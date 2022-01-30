using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update

    public void EndDieAnimation()
    {
        animator.SetBool("IsDead", false);
    }

    public void EndAttackAnimation()
    {
        GetComponentInParent<EnemyCombat>().isAttacking = false;
    }

    public void setAttackTrigger(){
        Debug.Log("ENTRO EN EL SETATTACK");
        animator.SetTrigger("Attack");
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
