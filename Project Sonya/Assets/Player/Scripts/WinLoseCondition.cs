using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseCondition : MonoBehaviour
{
    [SerializeField] Rigidbody playerRb;
    [SerializeField] GameObject[] needsObjects;
    [SerializeField] GameObject planePrefab;
    [SerializeField] float baloonAnimationTime = 1.5f;
    [SerializeField] Animator animator;

    int needPoint;    
    float planeLength; //Length is 160;

    [SerializeField] GameObject Pets;
    [SerializeField] GameObject Medic;
    [SerializeField] GameObject Ham;

    void Start() 
    {
        planeLength = planePrefab.gameObject.transform.localScale.z * 10;
        Invoke(nameof(FindNeed), baloonAnimationTime);
    }

    void FindNeed()
    {
        needPoint = Random.Range(160, 640);

        if (needPoint < 320)
        {
            Ham.SetActive(true);
        }
        else if (needPoint < 480)
        {
            Medic.SetActive(true);
        }
        else
        {
            Pets.SetActive(true);
        }

        needPoint = (int)((float)needPoint / planeLength);
    }

    void Update()
    {
        if (playerRb == null) { return; }
        if(playerRb.velocity.magnitude < 0.1f && playerRb.transform.position.z > 40)
        {
            
            if((int)(playerRb.transform.position.z / planeLength) == needPoint)
            {
                animator.SetTrigger("jump");
            }
            else
            {
                animator.SetTrigger("fall");
            }

            playerRb = null;
        }
    }

}