using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 playerNewPositions;
    [SerializeField] int playerSpeed = 5;
    float xSpeed;
    float maxXValue = 4.28f;
    bool isPlayerMoving = true;
    void Start()
    {

    }


    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (isPlayerMoving == false)
        {
            return;
        }
        float touchX = 0;
        float newXValue;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) // telefonda ekran dokunusuna gore hareket 
        {
            xSpeed = 250f; // saga sola gidis hizi 
            touchX = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0)) // editorde mouse sol tik basilir tutarak oynatmak icin 
        {
            xSpeed = 350f;
            touchX = Input.GetAxis("Mouse X");
        }
        newXValue = transform.position.x + xSpeed * touchX * Time.deltaTime;
        newXValue = Mathf.Clamp(newXValue, -maxXValue, maxXValue); // platformun disina cikmamasi icin 
        playerNewPositions = new Vector3(newXValue, transform.position.y, transform.position.z + playerSpeed * Time.deltaTime);
        transform.position = playerNewPositions;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine"))
        {
            isPlayerMoving = false;
        }
    }
}
