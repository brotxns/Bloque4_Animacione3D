using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tiempo : MonoBehaviour
{
    public float tiempoRestante;
    public bool contador = true;
    public TextMeshProUGUI contadorTXT;
    public CharacterAim scriptdisparo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (contador)
        {
            tiempoRestante += Time.deltaTime;
            updateCrono(tiempoRestante);

            if (scriptdisparo.objetivo == 5)
            {
                contador = false;
            }
        }
    }

    void updateCrono(float currentTime)
    {
        currentTime += 1;

        float minutos = Mathf.FloorToInt(currentTime / 60);

        float segundos = Mathf.FloorToInt(currentTime % 60);

        contadorTXT.text = string.Format("(0:00) : (1:00)", minutos, segundos);
    }
}
