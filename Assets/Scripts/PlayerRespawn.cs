using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//se necesita para manejar las esenas
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{

    private float checkPointPositionX, checkPointPositionY;
    //referencia para poder llamar a la animación
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("checkPointPositionX")!=0)
        {
            transform.position=(new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"),
                PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }

    //recivo las coodenadas como argumento, para poder guardarlas
    public void ReachedCheckPoint(float x, float y)
    {
        //guardo los valores en el PlayerPrefs
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    //metodos que llamaremos desde nuestros enemigos
    public void PlayerDameged()
    {
        //activo la animación
        animator.Play("Hit");
        //cargamos nuevamente la esena en la que estamos.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
