using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHolderController : MonoBehaviour
{
    /// <summary>
    /// geçtiðimiz kapýnýn yanýndaki kapýnýn boxcollider'ýný kapatmamýzý saðlar.
    /// </summary>
    public void CloseGates()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i) != null)
            {
                transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
