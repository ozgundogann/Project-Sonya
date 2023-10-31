using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseCondition : MonoBehaviour
{
    [SerializeField] GameObject planePrefab;
    [SerializeField] GameObject pets;
    [SerializeField] GameObject medic;
    [SerializeField] GameObject ham;
    [SerializeField] TMP_Text text;
    [SerializeField] float animationTime = 1.5f;

    Rigidbody playerRb;
    int needPoint;
    float reloadTime = 3;
    float initialPlayerPosZ;
    float planeLength;

    void Start() 
    {
        planeLength = planePrefab.gameObject.transform.localScale.z * UnityEditor.EditorSnapSettings.move.z;
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();
        initialPlayerPosZ = playerRb.transform.position.z;
        text.gameObject.SetActive(false);
        Invoke(nameof(FindNeed), animationTime);
    }

    void FindNeed()
    {
        GetComponent<PlayerHandler>().enabled = true;
        needPoint = Random.Range(160, 640);

        if (needPoint < 320)
        {
            ham.SetActive(true);
        }
        else if (needPoint < 480)
        {
            medic.SetActive(true);
        }
        else
        {
            pets.SetActive(true);
        }

        needPoint = Mathf.FloorToInt(needPoint / planeLength);
    }

    void Update()
    {
        if (playerRb == null) { return; }
        if (playerRb.velocity.magnitude < 0.1f && planePrefab.transform.localScale.z * UnityEditor.EditorSnapSettings.move.z * 0.5f < playerRb.position.z)
        {
            ConditionChecker();
        }
    }

    void ConditionChecker()
    {       
        text.gameObject.SetActive(true);
        if (Mathf.FloorToInt(playerRb.transform.position.z / planeLength) == needPoint)
        {
            text.text = "You win! your pet is happy";
        }
        else
        {
            text.text = "You lose! your pet is sad";
        }

        playerRb = null;   
        Invoke (nameof(ReloadScene), reloadTime);
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}