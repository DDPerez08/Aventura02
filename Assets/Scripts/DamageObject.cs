using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //el debug es util para que nos muestre en consola si algo funciona o no
            // utilizandolos como banderas de estado
            //Debug.Log("Player Damaged");
            //llamo al metodo PlayerDameged dentro de PlayerRespawn
            collision.transform.GetComponent<PlayerRespawn>().PlayerDameged();
        } 
    }
}
