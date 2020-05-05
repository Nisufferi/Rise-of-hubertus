using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Animation>()["SwordHit"].wrapMode = WrapMode.Once;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButton("Fire1")) {
            //GetComponent<Animator>().ResetTrigger("SwordHit");
            Attack();
        }
    }

    void Attack()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            GetComponent<Animator>().SetTrigger("SwordHit");
            //GetComponent<Animator>().SetTrigger("Idle");
        }
    }    
}
