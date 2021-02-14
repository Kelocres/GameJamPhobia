using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoItem : MonoBehaviour
{
    //Valores posibles se tipoObjeto: "Comida", "Curacion", "PilaLinterna", "Seta"
    public string tipoObjeto;
    public float valorObjeto;

    private void OnTriggerEnter(Collider otro)
    {
        if(otro.tag == "Player")
        {
            otro.gameObject.GetComponent<RecursosJugador>().SumarContador(tipoObjeto,valorObjeto);
            Destroy(this.gameObject);
        }
    }
}
