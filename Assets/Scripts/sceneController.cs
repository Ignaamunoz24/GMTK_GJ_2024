using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static string lastScene;
    public Animator transitionsAnim;

    public void LoadMenu()
    {
        // Guardar la escena actual
        lastScene = SceneManager.GetActiveScene().name;

        // Iniciar la corrutina para cargar la escena del menú con la animación de salida
        StartCoroutine(LoadMenuScene());
    }

    public void ExitMenu()
    {
        // Verificar si hay una escena anterior guardada
        if (!string.IsNullOrEmpty(lastScene))
        {
            StartCoroutine(ExitToLastScene());
        }
        else
        {
            Debug.LogWarning("No previous scene found. Cannot exit menu.");
        }
    }

    IEnumerator LoadMenuScene()
    {
        transitionsAnim.SetTrigger("end");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MenuScene");
    }

    IEnumerator ExitToLastScene()
    {
        transitionsAnim.SetTrigger("end");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(lastScene);
    }


    public void TitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
