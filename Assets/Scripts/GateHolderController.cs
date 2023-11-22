using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHolderController : MonoBehaviour
{
   
    void Start()
    {

    }

   
    void Update()
    {

    }
    public void CloseGate()
    {
        for (int i = 0; i < transform.childCount; i++)
        // kapilari tutan bos objenin icine koyucaz player bir kapiya
        // carptiginda carptigi yok olucak bu fonksyionda childleri tek tek gezicek yok olmayanin collideri kapaticak 2 kapiya birden giremeyelim diye
        {
            if (transform.GetChild(i) != null)
            {
                transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
