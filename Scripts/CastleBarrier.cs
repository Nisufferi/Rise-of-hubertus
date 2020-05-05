using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleBarrier : MonoBehaviour
{
    PlayerHUD keyNumber;
    void Start()
    {
        keyNumber = FindObjectOfType<PlayerHUD>();
    }

    // Update is called once per frame
    void Update()
    {
        keyNumber = FindObjectOfType<PlayerHUD>();

        if (keyNumber.keyNumber >= 3)
        {
            Destroy(gameObject);
        }
    }
}
