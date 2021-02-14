using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMutacionJugador : MonoBehaviour
{
    private int setasComidas;
    private bool[] mutaciones = new bool[4];

    public void ConsumirSeta()
    {
        setasComidas++;

        if(setasComidas == mutaciones.Length)
        {
            Debug.Log("Transformación completada");
        }
        else
        {
            //La selección de transformación es aleatorio, pero se garantiza que se
            //escoge una transformación que aún esté pendiente
            int aleatorio = Random.Range(0,mutaciones.Length);
            while(mutaciones[aleatorio])
            {
                aleatorio++;
                if(aleatorio >= mutaciones.Length)  aleatorio = 0;
            }
            mutaciones[aleatorio] = true;
            switch(aleatorio){
                default:
                    TransformarCabeza();
                    break;
                case 1:
                    TransformarBrazos();
                    break;
                case 2:
                    TransformarPiernas();
                    break;
                case 3:
                    TransformarTorso();
                    break;
            }
            
        }
    }

    private void TransformarCabeza()
    {
        Debug.Log("Transformar cabeza");
    }

    private void TransformarBrazos()
    {
        Debug.Log("Transformar brazos");
    }

    private void TransformarPiernas()
    {
        Debug.Log("Transformar piernas");
    }

    private void TransformarTorso()
    {
        Debug.Log("Transformar torso");
    }
}
