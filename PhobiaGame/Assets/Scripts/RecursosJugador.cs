using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecursosJugador : MonoBehaviour
{
    //Variables para la vida
    private float vida_max = 100f;
    public float vida_actual;
    public BarraCanvas barraVida;

    //Variables para el hambre
    private float hambre_max = 100f;
    public float hambre_actual;
    private int intervalo_hambre = 3;
    public BarraCanvas barraHambre;

    //Variables para la ansiedad 
    private float ansiedad_max = 100f;
    public float ansiedad_actual;
    private int intervalo_ansiedad = 1;
    private int cuentaLuces;

    //Variables para la linterna
    private float pilaLinterna_max = 20f;
    public float pilaLinterna_actual;
    private int intervalo_pilaLinterna = 3;
    ControlLinterna linterna;
    public BarraCanvas barraLinterna;

    //Contador de tiempo
    private float contadorTiempo;
    private int contadorSegundos;

    ControlMutacionJugador controlMutacion;
    

    // Start is called before the first frame update
    void Start()
    {
        vida_actual = vida_max;
        hambre_actual = hambre_max;
        ansiedad_actual = ansiedad_max;
        pilaLinterna_actual = pilaLinterna_max;

        contadorTiempo = 0f;
        contadorSegundos = 0;
        cuentaLuces = 0;

        linterna = GetComponentInChildren<ControlLinterna>();
        controlMutacion = GetComponent<ControlMutacionJugador>();
        barraVida.Inicializar(vida_max, vida_actual);
        barraHambre.Inicializar(hambre_max, hambre_actual);
        barraLinterna.Inicializar(pilaLinterna_max, pilaLinterna_actual);

    }

    // Update is called once per frame
    void Update()
    {
        contadorTiempo += Time.deltaTime;
        if(contadorTiempo > 1f) contarSegundos();
        
        //Activar y desactivar Linterna
        if(Input.GetButtonDown("Fire1") && pilaLinterna_actual > 0f)
            linterna.interruptor();
    }

    void contarSegundos()
    {
        contadorSegundos++;
        contadorTiempo = 0f;
        //Debug.Log(contadorSegundos);

        if(contadorSegundos % intervalo_hambre == 0)  DescontarHambre(2f);

        if(linterna.encendida && contadorSegundos % intervalo_pilaLinterna == 0) DescontarLinterna(2f);

        if(contadorSegundos % intervalo_ansiedad == 0)    ContarAnsiedad();
    }

    void DescontarHambre(float intro)
    {
        hambre_actual -= intro;
        barraHambre.SetValor(hambre_actual);
        if(hambre_actual <= 0f)
            Debug.Log("Has muerto de hambre");
    }

    void DescontarLinterna(float intro)
    {
        pilaLinterna_actual -= intro;
        barraLinterna.SetValor(pilaLinterna_actual);
        if(pilaLinterna_actual <= 0f) linterna.Apagar();
    }

    void ContarAnsiedad()
    {
        if(!linterna.encendida && cuentaLuces<=0)
        {
            ansiedad_actual -= 3f;
            Debug.Log("Ansiedad: "+ ansiedad_actual);
            if(ansiedad_actual <= 0f)
                Debug.Log("Has muerto de ansiedad");
        }
        else if(cuentaLuces > 0)
        {
            ansiedad_actual += 3f;
            if(ansiedad_actual > ansiedad_max)  ansiedad_actual = ansiedad_max;
            Debug.Log("Ansiedad: "+ ansiedad_actual);
        }
    }

    public void SumarContador(string tipoValor, float valor)
    {
        Debug.Log("Has conseguido "+valor +" puntos de "+tipoValor);
        if(tipoValor == "Curacion")
        {
            vida_actual += valor;
            if(vida_actual > vida_max)  vida_actual = vida_max;
            barraVida.SetValor(vida_actual);
        }
        else if(tipoValor == "Comida" || tipoValor == "Seta")
        {
            hambre_actual += valor;
            if(hambre_actual > hambre_max)  hambre_actual = hambre_max;
            barraHambre.SetValor(hambre_actual);
            //Si es una seta, además de alimentar desencadena una transformación
            controlMutacion.ConsumirSeta();
        }
        else if(tipoValor == "PilaLinterna")
        {
            pilaLinterna_actual += valor;
            if(pilaLinterna_actual > pilaLinterna_max) pilaLinterna_actual = pilaLinterna_max;
            barraLinterna.SetValor(pilaLinterna_actual);
        }
    }

    public void RestarVida(float valor)
    {
        vida_actual -= valor;
        if(vida_actual < 0)     vida_actual = 0f;
        barraVida.SetValor(vida_actual);

        if(vida_actual == 0)
        {
            //Muerte y game over
        }
    }

    private void OnTriggerEnter(Collider otro)
    {
        if(otro.tag=="Fuego") 
        {  
            Debug.Log("Has encontrado una fuente de luz");
            cuentaLuces++;
        }
    }

    private void OnTriggerExit(Collider otro)
    {
        if(otro.tag=="Fuego")   cuentaLuces --;
    }
}
