using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            particle.Play();
        }    
    }
}
