using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;

    PhysicMaterial PlayerPhysicMaterial;
    
    void Awake()
    {
        PlayerPhysicMaterial = GameObject.Find("Player").GetComponent<Collider>().material;
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            particle.Play();
        }    
    }
}
