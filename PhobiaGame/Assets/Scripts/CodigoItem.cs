using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoItem : MonoBehaviour
{

    public AudioSource Item;
    //Valores posibles se tipoObjeto: "Comida", "Curacion", "PilaLinterna", "Seta"
    public string tipoObjeto;
    public float valorObjeto;

    void Start()
    {
        
        Item = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider otro)
    {
        if(otro.tag == "Player")
        {
            Item.Play();
            otro.gameObject.GetComponent<RecursosJugador>().SumarContador(tipoObjeto,valorObjeto);
            Destroy(this.gameObject);
        }
    }
}
