using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHolderController : MonoBehaviour
{
    /// <summary>
    /// ge�ti�imiz kap�n�n yan�ndaki kap�n�n boxcollider'�n� kapatmam�z� sa�lar.
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
