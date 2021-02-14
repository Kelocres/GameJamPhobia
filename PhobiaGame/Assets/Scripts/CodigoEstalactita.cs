using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoEstalactita : MonoBehaviour
{
    public AudioSource SoundEst;
    private Rigidbody rigi;
    public float retrasoCaida = 0f;
    bool activada = false;
    private float contadorTiempo;

    void Start()
    {
        SoundEst = GetComponent<AudioSource>();
        rigi = GetComponent<Rigidbody>();
        contadorTiempo = 0f;
    }

    void Update()
    {
        if(activada)
        {
            contadorTiempo += Time.deltaTime;
            if(contadorTiempo > retrasoCaida)
                rigi.useGravity = true;
        }
    }

    // Update is called once per frame
    public void ActivarCaida()
    {
        //rigi.useGravity = true;
        activada = true;
        SoundEst.Play();
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
            otro.GetComponent<RecursosJugador>().RestarVida(20f);
            //Efecto partículas
            Destroy(this.gameObject);
        }
    }
}
