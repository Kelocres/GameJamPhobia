using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionTrigger : MonoBehaviour
{
    ManejaTriggers mt;
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
            mt.AccionTrigger(this.gameObject,accionEnter);
    }

    private void OnTriggerExit(Collider otro)
    {
        if(otro.tag == "Player" && accionExit!="")
            mt.AccionTrigger(this.gameObject,accionExit);  
    }
}
