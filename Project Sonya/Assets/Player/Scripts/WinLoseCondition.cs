using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseCondition : MonoBehaviour
{
    [SerializeField] Rigidbody playerRb;
    int distance = 0;

    void Update()
    {
        if(playerRb.velocity.magnitude == 0)
        {
            if(playerRb.transform.position.z > 320 && playerRb.transform.position.z < 480)
            {
                Debug.Log("I win!!!");
            }
            else
            {
                Debug.Log("I lose :((((");
            }
        }
    }
}
