using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionTrigger : MonoBehaviour
{
    ManejaTriggers mt;
    public CodigoEstalactita[] estalactitas;
    //Envian un mensaje al maneja triggers, que le indica lo que debe hacer
    public string accionEnter = "";
    public string accionExit = "";
    void Start()
    {
        mt = FindObjectOfType<ManejaTriggers>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider otro)
    {
        if(otro.tag == "Player" && accionEnter!="")
            if(estalactitas==null)
                mt.AccionTrigger(null,accionEnter);
            else if(accionEnter=="Cae una estalactita")
                {
                    foreach(CodigoEstalactita estal in estalactitas)
                    {
                        estal.ActivarCaida();
                    }
                }
    }

    private void OnTriggerExit(Collider otro)
    {
        if(otro.tag == "Player" && accionExit!="")
            mt.AccionTrigger(null,accionExit);  
    }
}
