using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoquitoScript : MonoBehaviour
{
    public GameObject[] colors;
    public int currentLightIndex =-1; //A QUE POSICION INTENTO ACCEDER PARA QUE SE VAYA MOVIENDO CON EL ++ Y ARRANQUE EN 0
    public int ciclocumplido = 0; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateNextLight()
    {
        currentLightIndex++; //
        if (currentLightIndex >= colors.Length)  //CHEQUEA EL INDICE CON LA CANT DE ELEMENTOS
        {
            currentLightIndex = 0; //SI SE PASA QUE VUELVA A 0 
            ciclocumplido++; //ciclo cumplido se le suma uno xq ya termino entones hay q agregar uno a la lista
            Checkrepetitions(); 

        }

        DeactivateAllLights(); //DESACTIVO LAS LUCES
        colors[currentLightIndex].SetActive(true); //ACTIVE ES UNA PROP DEL GAME OBJ (BOOL). MEDIANTE SETACTIVE LO ACTIVA SI ESTA EN TRUE
    }

    public void ActivatePreviousLight()
    {
        currentLightIndex--;
        if (currentLightIndex < 0)
        {
            currentLightIndex = colors.Length - 1;
        }
        DeactivateAllLights();
        colors[currentLightIndex].SetActive(true);
    }

    void DeactivateAllLights()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i].SetActive(false);
        }

       
    }

    public void ActivateRepeating(float t)
    {
        InvokeRepeating(nameof(ActivateNextLight),0,t);
    }

    void Checkrepetitions()
    {
        if (ciclocumplido >= 3)
        {
            Destroy(gameObject); 
        }
    }
}
