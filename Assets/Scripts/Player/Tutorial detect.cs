using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorialdetect : MonoBehaviour
{
    public List<GameObject> panelTutos = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tuto"))
        {
            string nombreObjeto = collision.gameObject.name;

            switch (nombreObjeto)
            {
                case "tuto1":
                    panelTutos[0].SetActive(true);
                    break;
                case "tuto2":
                    panelTutos[1].SetActive(true);
                    break;
                case "tuto3":
                    panelTutos[2].SetActive(true);
                    break;
                case "tuto4":
                    panelTutos[3].SetActive(true);
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("tuto"))
        {
            string nombreObjeto = collision.gameObject.name;

            switch (nombreObjeto)
            {
                case "tuto1":
                    panelTutos[0].SetActive(false);
                    break;
                case "tuto2":
                    panelTutos[1].SetActive(false);
                    break;
                case "tuto3":
                    panelTutos[2].SetActive(false);
                    break;
                case "tuto4":
                    panelTutos[3].SetActive(false);
                    break;
            }
        }
    }
}
