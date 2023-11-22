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

    void Start()
    {
        AddGateValueAndSymbol();
    }


    void Update()
    {

    }
    void AddGateValueAndSymbol()
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
}
