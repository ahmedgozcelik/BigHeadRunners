using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public enum GateType { fatterType, thinnerType, tallerType, shorterType};
public class GateController : MonoBehaviour
{
    GateHolderController gateHolderController;

    public int gateValue;
    public RawImage gateImage;
    public TextMeshProUGUI gateText;
    public Texture[] textures;
    public GateType gateType;
    public GameObject playerGO;
    public PlayerController playerScript;
    bool hasGateUsed;
    void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerScript = playerGO.GetComponent<PlayerController>();

        gateHolderController = transform.parent.GetComponent<GateHolderController>();

        AddGateValueAndSymbol();
    }

    void Update()
    {
        
    }

    public void AddGateValueAndSymbol()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasGateUsed == false)
        {
            hasGateUsed = true;
            playerScript.PassedGate(gateType, gateValue);

            if(gateHolderController != null)
            {
                gateHolderController.CloseGates();  
            }
            
            Destroy(gameObject);
        }
    }
}
