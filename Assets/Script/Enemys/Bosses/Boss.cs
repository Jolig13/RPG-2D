    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator bossAnim;

    private void Start() 
    {
        bossAnim = GetComponent<Animator>();    
    }
    private void FixedUpdate() 
    {
        LookAtPlayer();   
    }
    public void LookAtPlayer()
    {
        if(Mathf.Abs(transform.position.x) > Mathf.Abs(transform.position.y)) 
        {
            bossAnim.SetFloat("Horizontal",Mathf.Sign(transform.position.x));
            bossAnim.SetFloat("Vertical",0);
        }
        else
        {
            bossAnim.SetFloat("Horizontal",0);
            bossAnim.SetFloat("Vertical",Mathf.Sign(transform.position.y));
        }
    }
}
