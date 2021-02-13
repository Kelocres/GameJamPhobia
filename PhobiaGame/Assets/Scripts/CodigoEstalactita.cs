using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoEstalactita : MonoBehaviour
{

    private Rigidbody rigi;
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void ActivarCaida()
    {
        rigi.useGravity = true;
    }

    private void OnTriggerEnter(Collider otro)
    {
        if(otro.tag == "Suelo")
        {
            //Efecto partículas
            Destroy(this.gameObject);
        }
        else if(otro.tag == "Player")
        {
            otro.GetComponent<RecursosJugador>().RestarVida(10f);
            //Efecto partículas
            Destroy(this.gameObject);
        }
    }
}
