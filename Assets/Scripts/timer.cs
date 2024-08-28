using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    public float time = 0;

    public TextMeshProUGUI text;

    public TopDownMovement topDownMovement;

    public GameObject panelWin;

    private void Start()
    {
        panelWin.SetActive(false);
    }

    void Update()
    {
        time -= Time.deltaTime;

        text.text = "" + time.ToString("f1");

        if(time <= 0)
        {
            text.text = "0";
            CheckVidas();
        }
    }

    void CheckVidas()
    {
        // Verificar si hay vidas activas
        bool vidaRestante = false;
        foreach (var vida in topDownMovement.vidas)
        {
            if (vida.activeSelf)
            {
                vidaRestante = true;
                break;
            }
        }

        if (vidaRestante)
        {
            panelWin.SetActive(true);

            GameObject player = GameObject.Find("Player");
            TopDownMovement scriptToRemove = player.GetComponent<TopDownMovement>();

            GameObject controlador = GameObject.Find("ControladorPS");
            spawnerPirana scripts = controlador.GetComponent<spawnerPirana>();

            if (scriptToRemove != null)
            {
                scriptToRemove.enabled = false;
                Destroy(scripts);
            }
        }
    }
}
