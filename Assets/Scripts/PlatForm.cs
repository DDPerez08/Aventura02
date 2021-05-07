using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatForm : MonoBehaviour
{
    //referencia a nuestra platadorma2D
    private PlatformEffector2D effector;
    //se utilizara para que al bajar de la plataforma demore un tiempo.
    public float starWaiTime;
    //se utiliza para controlar el timepo que baja de la plataforma.
    private float waitedTime;
    
    void Start()
    {
        //se coloca effector y ahora se detecta dentro del objeto.
        effector = GetComponent<PlatformEffector2D>();
        Debug.Log(waitedTime + "<--- Start");
    }

   
    void Update()
    {
        //este if es para resetear el tiempo de espera para poder bajar de la plataforma.
        //tecla flecha acia abajo.
        //nota. ver como aplicarlo para el salto, para que no sean seguidos.
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKeyUp("s"))
        {
            waitedTime = starWaiTime;
            Debug.Log(waitedTime + "<--- reset");
        }

        // 
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            if (waitedTime <= 0f)
            {
                effector.rotationalOffset = 180f;
                waitedTime = starWaiTime;
                Debug.Log(waitedTime + "Rotación");
            }
            else
            {
                //Time.deltaTime
                waitedTime = waitedTime -0.4f;
                Debug.Log(waitedTime + "<-- else");
            }

            //if (waitedTime >= 0)
            //{
            //    waitedTime = waitedTime - Time.deltaTime;
            //    Debug.Log(waitedTime + "<-- Mayor");
            //}
            //else
            //{
            //    effector.rotationalOffset = 180f;
            //    waitedTime = starWaiTime;
            //    Debug.Log(waitedTime + "Rotación");
            //}
        }
        

        if (Input.GetKey("z"))
        {
            effector.rotationalOffset = 0f;
            Debug.Log(waitedTime + "<-- z");
        }
    }
}
