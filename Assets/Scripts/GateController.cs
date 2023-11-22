using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum GateType { fatterType, thinnerType, tallerType, shorterType };
public class GateController : MonoBehaviour
{
    [SerializeField] int gateValue;
    [SerializeField] RawImage gateImage;
    [SerializeField] TextMeshProUGUI gateText;
    [SerializeField] Texture[] textures;
    public GateType gateType;
    GameObject PlayerObject;
    PlayerController PlayerScript;
    bool hasGateUsed = false; // kapiya 1 kereden fazla degmemesi icin 
    GateHolderController gateHolderController;
    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        PlayerScript = PlayerObject.GetComponent<PlayerController>();
        gateHolderController = transform.parent.GetComponent<GateHolderController>(); // parenttaki scripti aldik 
        AddGateValueAndSymbol();
    }


    void Update()
    {

    }
    void AddGateValueAndSymbol() // 4 farkli kapi turune gore image degisimini saglar 
    {
        gateText.text = gateValue.ToString();
        switch (gateType)
        {
            case GateType.fatterType:
                gateImage.texture = textures[0];
                break;

            case GateType.thinnerType:
                gateImage.texture = textures[1];

                break;
            case GateType.tallerType:
                gateImage.texture = textures[2];

                break;
            case GateType.shorterType:
                gateImage.texture = textures[3];
                break;

        }
    }
    private void OnTriggerEnter(Collider other) // player degdiginde Player uzerindeki scriptten PassedGate e gateType i ve gateValue yu gonderiyoruz
    {
        if (other.CompareTag("Player") && hasGateUsed == false)
        {
            hasGateUsed = true;
            PlayerScript.PassedGate(gateType, gateValue);

            if (gateHolderController != null) // singleGate de bu null donucek bu yuzden kontrol saglamaliyiz
            {
                gateHolderController.CloseGate();
            }
          
            Destroy(gameObject);
        }
    }
}
