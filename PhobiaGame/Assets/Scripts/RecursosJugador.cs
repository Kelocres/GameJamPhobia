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

    //Variables para la ansiedad (si la implementamos)
    private float ansiedad_max = 100f;
    public float ansiedad_actual;
    private int intervalo_ansiedad = 3;

    //Variables para la linterna
    private float pilaLinterna_max = 20f;
    public float pilaLinterna_actual;
    private int intervalo_pilaLinterna = 3;
    ControlLinterna linterna;
    public BarraCanvas barraLinterna;

    //Contador de tiempo
    private float contadorTiempo;
    private int contadorSegundos;
    

    // Start is called before the first frame update
    void Start()
    {
        vida_actual = vida_max;
        hambre_actual = hambre_max;
        ansiedad_actual = ansiedad_max;
        pilaLinterna_actual = pilaLinterna_max;

        contadorTiempo = 0f;
        contadorSegundos = 0;

        linterna = GetComponentInChildren<ControlLinterna>();
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

    public void SumarContador(string tipoValor, float valor)
    {
        Debug.Log("Has conseguido "+valor +" puntos de "+tipoValor);
        if(tipoValor == "Curacion")
        {
            vida_actual += valor;
            if(vida_actual > vida_max)  vida_actual = vida_max;
            barraVida.SetValor(vida_actual);
        }
        else if(tipoValor == "Comida")
        {
            hambre_actual += valor;
            if(hambre_actual > hambre_max)  hambre_actual = hambre_max;
            barraHambre.SetValor(hambre_actual);
        }
        else if(tipoValor == "PilaLinterna")
        {
            pilaLinterna_actual += valor;
            if(pilaLinterna_actual > pilaLinterna_max) pilaLinterna_actual = pilaLinterna_max;
            barraLinterna.SetValor(pilaLinterna_actual);
        }
    }
}
