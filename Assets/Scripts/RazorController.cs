using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RazorController : MonoBehaviour
{
    GameObject playerObject;
    PlayerController playerScript;
    bool hasRazorUsed = false;
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerScript = playerObject.GetComponent<PlayerController>();
    }


    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasRazorUsed == false)
        {
            hasRazorUsed = true;
            playerScript.TouchedTheRazor();
        }
    }
}
