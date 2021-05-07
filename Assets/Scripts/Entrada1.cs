using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Entrada1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Entrada 1");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            //Playe  gameObject.GetComponent<Transform>().position = new Vector3(2.736f, -0.011f, 0.0f);
           // PlayerMove.ReferenceEquals.gameObject.GetComponent<Transform>().position = new Vector3(2.736f, -0.011f, 0.0f);
        }
    }
}
