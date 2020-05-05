using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Camera fpcamera;
    [SerializeField] float range = 10f;
    SkeletonHealth target;
    BossHealth tar;
    [SerializeField] float damage = 20f;
    
    void Start()
    {
        
    }

    private void Update()
    {
        tar = FindObjectOfType<BossHealth>();
    }


    public void PlayerHitEvent()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpcamera.transform.position, fpcamera.transform.forward, out hit, range))
        {
            if (hit.distance < 3)
            {
                
                if(hit.transform.name == "Green")
                {
                    Debug.Log(hit.transform.name);
                    Debug.Log(hit.distance);
                    tar = hit.transform.GetComponent<BossHealth>();
                    tar.damageTaken(damage);
                }
                else
                {
                    Debug.Log(hit.transform.name);
                    Debug.Log(hit.distance);
                    target = hit.transform.GetComponent<SkeletonHealth>();
                    target.damageTaken(damage);
                }
                
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }
    
}
