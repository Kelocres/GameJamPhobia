using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejaTriggers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AccionTrigger(CodigoEstalactita estalactita, string mensaje)
    {
        //En caso de que sea un trigger que indique que el monstruo va a perseguir al jugador
        if(mensaje == "El monstruo empieza a perseguir")
        {
            FindObjectOfType<ControlMonstruo>().EmpezarPersecucion();
        }

        if(mensaje == "Cae una estalactita" && estalactita!=null)
        {
            estalactita.ActivarCaida();
        }
    }
}
