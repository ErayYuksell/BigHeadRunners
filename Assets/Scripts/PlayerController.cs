using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 playerNewPositions;
    [SerializeField] int playerSpeed = 5;
    float xSpeed;
    float maxXValue = 4.28f;
    bool isPlayerMoving = false;
    [SerializeField] GameObject headBoxObject;
    ScaleCalculator scaleCalculator; // normal bir class seklinde 
    Renderer headBoxRenderer;
    Material currentHeadMat;
    [SerializeField] Material warningMat;
    Animator playerAnim;
    void Start()
    {
        scaleCalculator = new ScaleCalculator(); // ??????
        headBoxRenderer = headBoxObject.transform.GetChild(0).gameObject.GetComponent<Renderer>();
        currentHeadMat = headBoxRenderer.material; // ilk bastaki turuncu materiali tutuyor
        playerAnim = GetComponent<Animator>();
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
            StartIdleAnim();
        }
    }
    public void PassedGate(GateType gateType, int gateValue) // bu fonksiyon gate e degdigim anda diger script tarafindan calistirilir o taraftan gateTypi tasir ve scaleCalculator i calistirir
    {
        headBoxObject.transform.localScale = scaleCalculator.CalculatePlayerHeadSize(gateType, gateValue, headBoxObject.transform);
        Debug.Log("Kapidan Gecildi");
    }
    public void TouchedToColorBox(Material boxMat)
    {
        headBoxRenderer.material = boxMat;
        currentHeadMat = boxMat;
    }
    public void TouchedTheRazor()
    {
        headBoxObject.transform.localScale = scaleCalculator.DecreasePlayerHeadSize(headBoxObject.transform);
        StartCoroutine(StartRedBlinkEffect());
    }
    IEnumerator StartRedBlinkEffect() // engellere deyince kafamiz 0.3 saniyeligine kirmizi yanip simdiki rengine geri donecek 
    {
        headBoxObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = warningMat;

        yield return new WaitForSeconds(0.5f);

        headBoxObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = currentHeadMat;

    }
    public void GameStart() // ekrana tikladiginda hareket baslasin diye kosma animasyonunuda burda baslattim 
    {
        isPlayerMoving = true;
        StartRunAnim();
    }
    void StartRunAnim()
    {
        playerAnim.SetBool("isIdleOn", false);
        playerAnim.SetBool("IsRunningOn",true);
    }
    void StartIdleAnim()
    {
        playerAnim.SetBool("isIdleOn", true);
        playerAnim.SetBool("IsRunningOn", false);
    }
}
