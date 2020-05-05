using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    BossAttack bossAttack;
    private bool trigger = false;
    void Start()
    {
        bossAttack = FindObjectOfType<BossAttack>();
        trigger = bossAttack.engaged;
    }

    // Update is called once per frame
    void Update()
    {
        trigger = bossAttack.engaged;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            bossAttack.engaged = true;
        }
    }
}
