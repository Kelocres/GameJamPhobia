using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejaTriggers : MonoBehaviour
{
    ControlMonstruo cMostruo;
    RecursosJugador rJugador;
    // Start is called before the first frame update
    void Start()
    {
        cMostruo = FindObjectOfType<ControlMonstruo>();
        rJugador = FindObjectOfType<RecursosJugador>();
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
            cMostruo.EmpezarPersecucion();
        }

        else if(mensaje == "Sumar fuente de luz")
        {
            Debug.Log(mensaje);
            rJugador.SumarLuces();
        }
        else if(mensaje == "Restar fuente de luz")
        {
            Debug.Log(mensaje);
            rJugador.RestarLuces();
        }
        
    }
}
