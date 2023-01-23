using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float sensitivity = 1.5f;
    float yRotationLimit1 = 60;
    float yRotationLimit2 = -30;

    Vector3 rotation = Vector3.zero; //ustalenie punktu zero

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }

    void Update()
    {
        ChangingMouseMode();
    }
    public void ChangingMouseMode()
    {
        if (PauseMenu.isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            rotation.x += Input.GetAxis("Mouse X") * sensitivity; //Pobranie warto�ci z Unity o X Myszki i przemno�enie razy czu�o�� 
            rotation.y += Input.GetAxis("Mouse Y") * sensitivity;
            rotation.y = Mathf.Clamp(rotation.y, yRotationLimit2, yRotationLimit1); //limit Yka �eby nie robi� salt

            var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up); //obliczanie ile mo�na na boki z limtem g�ry
            var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left); //obliczanie ile mo�na do g�ry z limitem bok�w

            transform.localRotation = xQuat * yQuat; //lokalizacja kursora to �rodek obu
        }
    }
}
