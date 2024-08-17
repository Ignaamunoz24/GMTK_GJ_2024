using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneStartAnimation : MonoBehaviour
{
    public Animator transitionsAnim;

    void Start()
    {
        // Ejecutar la animaci�n al iniciar la escena
        if (transitionsAnim != null)
        {
            transitionsAnim.SetTrigger("start");
        }
    }
}

