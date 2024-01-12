using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform target;
    public Vector3 offSet; // Kamera ile hedef aras�nda korunmas� gereken mesafe
    void Start()
    {
        
    }

    void LateUpdate() // LateUpdate -> Update gibi �al���r fakat update'e g�re biraz gecikmeli �al���r. Amac�m�z playercontroller i�erisindeki update �al��t�ktan sonra lateupdate �al��mas�. Bu sayede daha ak�c� oyun elde edece�iz.
    {
        if(target != null)
        {
            transform.position = target.position + offSet;
        }
    }
}
