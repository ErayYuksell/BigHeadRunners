using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBoxController : MonoBehaviour
{
    [SerializeField] Material boxMat;
    GameObject playerObject;
    PlayerController playerScript;
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
        if (other.CompareTag("Player"))
        {
            playerScript.TouchedToColorBox(boxMat);
            Destroy(gameObject);
        }
    }
}
