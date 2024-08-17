using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class pressSpace : MonoBehaviour
{
    public Animator transitionsAnim;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        transitionsAnim.SetTrigger("end");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("PlayableScene"); //toca cambiar el nombre depende de como se llame la escena jugable final
    }


}

