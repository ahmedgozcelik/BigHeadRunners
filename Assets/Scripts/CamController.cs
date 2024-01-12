using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform target;
    public Vector3 offSet; // Kamera ile hedef arasýnda korunmasý gereken mesafe
    void Start()
    {
        
    }

    void LateUpdate() // LateUpdate -> Update gibi çalýþýr fakat update'e göre biraz gecikmeli çalýþýr. Amacýmýz playercontroller içerisindeki update çalýþtýktan sonra lateupdate çalýþmasý. Bu sayede daha akýcý oyun elde edeceðiz.
    {
        if(target != null)
        {
            transform.position = target.position + offSet;
        }
    }
}
