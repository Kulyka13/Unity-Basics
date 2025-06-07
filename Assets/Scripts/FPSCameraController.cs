using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraController : MonoBehaviour
{
    // Чутливість миші для повороту камери
    public float mouseSensitivity = 100f;

    // Посилання на об'єкт гравця (щоб рухати його тілом)
    public Transform playerBody;

    // Поточний кут обертання по осі X (щоб обмежити вертикальний рух)
    private float xRotation = 0f;

    // Викликається один раз при запуску
    void Start()
    {
        // Заблокувати курсор у центрі екрану і приховати його
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Викликається кожен кадр
    void Update()
    {
        // Отримуємо ввід миші
       
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        // Обмежуємо вертикальний кут обертання (щоб уникнути перевертання)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        // Повертаємо камеру по вертикалі (вгору/вниз)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);



        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        // Повертаємо тіло гравця по горизонталі (ліворуч/праворуч)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
