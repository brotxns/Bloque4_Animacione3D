using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAim : MonoBehaviour
{
    private float aimSensitivity = 30;
    //private Vector2 aimSensitivity = new Vector2(30, 20);
    //para tener dos valores diferentes en la sensibilidad vert y horiz

    private Vector2 aimInput;

    private float xAngle;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.lockState = CursorLockMode.Confined sirve para que el cursor solo se mueva por la ventana y se limita a eso. para liberarlo en unity se le da a esc
        //Cursor.lockState = CursorLockMode.Locked sirve para ue el puntero se quede en el centro de forma invisible. Se suele poner en el menu de pausa para que al darle al esc aparezca el raton.
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, aimInput.x * aimSensitivity * Time.deltaTime, 0);

        //transform.GetChild(0).Rotate(-aimInput.y * aimSensitivity * Time.deltaTime, 0, 0);
        // esta linea sirve para acceder al primer hijo de este padre (padre el personaje e hijo la cam)

        xAngle = Mathf.Clamp(xAngle - aimInput.y * aimSensitivity * Time.deltaTime, -90, 90);
        transform.GetChild(0).localRotation = Quaternion.Euler(xAngle, 0, 0);

    }

    private void OnAim(InputValue value)
    {
        aimInput = value.Get<Vector2>();
    }

    private void OnShoot()
    {
        // ray casting es un rayo invisible que sale de donde se apunta (origen) y detecta cuando se dispara y acierta. es un bool. si choca con algo y lo detecta es true. sino es false.
        // se puede utilizar para limitar el alcance de un  arma, ignorar cristales que ven al personaje o al enemigo, detectar si se esta enfrente de la puerta
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.GetChild(0).position, transform.GetChild(0).forward, out hitInfo))
        {
            print(hitInfo.collider.name);
        }
        else
        {
            print("No hay nada");
        }
    }
}
