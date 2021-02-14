using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionTrigger : MonoBehaviour
{
    ManejaTriggers mt;
    public CodigoEstalactita[] estalactitas;

    //Envian un mensaje al maneja triggers, que le indica lo que debe hacer
    //Mensajes posibles:
    //      "El monstruo empieza a perseguir"
    //      "Cae una estalactita"
    //      "Sumar fuente de luz"   (para accionEnter)
    //      "Restar fuente de luz"  (para accionExit)

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
        {
            Debug.Log("Entra jugador; "+accionEnter);
            if(estalactitas.Length==0)
                mt.AccionTrigger(null,accionEnter);
            else if(accionEnter=="Cae una estalactita")
                {
                    foreach(CodigoEstalactita estal in estalactitas)
                    {
                        estal.ActivarCaida();
                    }
                }
        }
    }

    private void OnTriggerExit(Collider otro)
    {
        if(otro.tag == "Player" && accionExit!="")
        {
            Debug.Log("Sale jugador; "+accionExit);
            mt.AccionTrigger(null,accionExit);  
        }
    }
}
