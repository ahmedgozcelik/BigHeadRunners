using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float playerSpeed = 6f;
    float xSpeed;
    float maxXValue = 4.28f;
    bool isPlayerMoving;
    public GameObject headBoxGO;
    private ScaleCalculator scaleCalculator;
    Renderer headBoxRenderer;
    private Material currentHeadMat;
    public Material warningMat;
    void Start()
    {
        isPlayerMoving = true;
        scaleCalculator = new ScaleCalculator();
        headBoxRenderer = headBoxGO.transform.GetChild(0).gameObject.GetComponent<Renderer>();
        currentHeadMat = headBoxRenderer.material;
    }

    void Update()
    {
        if (isPlayerMoving == false)
        {
            return;
        }
        float touchX = 0;
        float newXValue;

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) // dokunma sayýsý 0'dan büyükse ve dokunma hareket eden bir türden ise
        {
            xSpeed = 250;
            touchX = Input.GetTouch(0).deltaPosition.x / Screen.width; //ekrana ilk dokunduðumuz yer / ekranýn geniþliði
        }
        else if(Input.GetMouseButton(0))
        {
            xSpeed = 100f;
            touchX = Input.GetAxis("Mouse X");
        }

        newXValue = transform.position.x + xSpeed * touchX * Time.deltaTime;
        newXValue = Mathf.Clamp(newXValue, -maxXValue, maxXValue);

        Vector3 playerNewPosition = new Vector3(newXValue, transform.position.y, transform.position.z + playerSpeed * Time.deltaTime); 
        transform.position = playerNewPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine"))
        {
            isPlayerMoving = false;
        }
    }

    public void PassedGate(GateType gateType, int gateValue)
    {
        headBoxGO.transform.localScale = scaleCalculator.CalculatePlayerHeadSize(gateType, gateValue, headBoxGO.transform);
    }

    /// <summary>
    /// Player'ýn kafa rengini deðiþtir.
    /// </summary>
    /// <param name="boxMat"></param>
    public void TouchedToColorBox(Material boxMat)
    {
        headBoxRenderer.material = boxMat;
        currentHeadMat = boxMat;
    }

    public void TouchedToObstacle()
    {
        headBoxGO.transform.localScale = scaleCalculator.DecreasePlayerHeadSize(headBoxGO.transform);
        StartCoroutine(StartRedBlingEffect());
    }

    private IEnumerator StartRedBlingEffect()
    {
        headBoxGO.transform.GetChild(0).GetComponent<MeshRenderer>().material = warningMat;

        yield return new WaitForSeconds(0.3f);

        headBoxGO.transform.GetChild(0).GetComponent<MeshRenderer>().material = currentHeadMat; 
    }
}
