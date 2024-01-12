using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private GameObject playerGO;
    private PlayerController playerController;
    private bool hasObstacleUsed;

    private void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerController = playerGO.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasObstacleUsed == false)
        {
            hasObstacleUsed = true;
            playerController.TouchedToObstacle();
        }
    }
}
