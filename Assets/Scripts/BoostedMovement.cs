using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostedMovement : MonoBehaviour
{
    // Посилання на компонент Rigidbody для фізичного руху
    private Rigidbody rb;

    // Швидкість руху гравця
    public float speed = 5f;

    // Сила стрибка
    public float jumpForce = 5f;

    // Максимальна додаткова сила для заряду стрибка
    public float maxChargeJumpForce = 15f;

    // Час для максимального заряду (1-5 секунд)
    public float maxChargeTime = 5f;

    // Мінімальний розмір по осі Y при стисканні
    private float minYScale;

    // Змінна для перевірки, чи стоїть гравець на землі
    private bool isGrounded;

    // Посилання на камеру, щоб рухати гравця відповідно до її напрямку
    public Transform cameraTransform;

    // Оригінальний розмір гравця
    private Vector3 originalScale;

    // Заряд стрибка
    public float chargeTime = 0f;

    // Викликається один раз при запуску
    void Start()
    {
        // Отримуємо компонент Rigidbody у гравця
        rb = GetComponent<Rigidbody>();

        // Відключаємо крутний момент, щоб уникнути обертання
        rb.freezeRotation = true;

        // Запам'ятовуємо початковий розмір гравця
        originalScale = transform.localScale;

        minYScale = originalScale.y / 2;
    }

    void Move()
    {
        // Отримуємо ввід для руху (W/S для перед/назад, A/D для ліворуч/праворуч)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        // Створюємо вектор напрямку руху
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        
        if(movement.magnitude > 1)
        {
            movement = movement.normalized;
        }



        // Перетворюємо рух відносно напрямку камери
        movement = cameraTransform.TransformDirection(movement);

        // Встановлюємо швидкість Rigidbody в напрямку руху, без додавання сили
        Vector3 velocity = movement * speed;
        velocity.y = rb.velocity.y; // Зберігаємо вертикальну швидкість для стрибків

        // Застосовуємо обчислену швидкість до Rigidbody
        rb.velocity = velocity;

    }
    void Jump()
    {
        // Перевірка на натискання клавіші пробілу для стрибка
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Додаємо силу для стрибка
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    // Викликається кожен кадр
    void Update()
    {
        if (chargeTime == 0)
        {
            Move();
            Jump();
        }

        BoostedJump();


    }

    private void BoostedJump()
    {
        // Заряджання стрибка при утримуванні Shift
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            // Збільшуємо час заряду, але не більше максимального часу
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0f, maxChargeTime);

            // Стискання гравця по осі Y (до мінімуму 0.5 від початкового розміру)
            float scaleY = Mathf.Lerp(originalScale.y, minYScale, chargeTime / maxChargeTime);
            transform.localScale = new Vector3(originalScale.x, scaleY, originalScale.z);
        }

        // Стрибок після відпускання Shift
        if (Input.GetKeyUp(KeyCode.LeftShift) && isGrounded)
        {
            // Обчислюємо додаткову силу стрибка на основі часу заряду
            float extraJumpForce = Mathf.Lerp(0f, maxChargeJumpForce, chargeTime / maxChargeTime);

            // Додаємо основну силу стрибка + додатковий заряд
            rb.AddForce(Vector3.up * (jumpForce + extraJumpForce), ForceMode.Impulse);

            // Відновлюємо початковий розмір гравця
            transform.localScale = originalScale;

            // Скидаємо час заряду
            chargeTime = 0f;
        }
    }
	private void OnTriggerStay(Collider other)
	{
		isGrounded = true;
	}
	private void OnTriggerExit(Collider other)
	{
		isGrounded = false;
	}
}
