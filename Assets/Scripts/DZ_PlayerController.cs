using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DZ_PlayerController : MonoBehaviour
{
	// Публічні параметри для налаштування швидкості
	public float walkSpeed = 5.5f;
	public float runSpeed = 12f;
	public float rotationSpeed = 10f;
	public float jumpForce = 8.5f;

	// Поточні стани
	public float currentSpeed;
	private float currentRotY;

	// Компоненти
	private Animator animator;
	private GroundChecker groundChecker;
	private Rigidbody rb;

	void Start()
	{
		// Ініціалізація компонентів
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		groundChecker = GetComponentInChildren<GroundChecker>();
	}

	private void HandleInput()
	{
		// Обробка стрибка
		if (Input.GetButtonDown("Jump") && groundChecker.isGrounded)
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Додати імпульс для стрибка
			animator.SetTrigger("Jump"); // Встановити тригер анімації стрибка
		}
	}

	private void HandleMovement()
	{
		// Отримання вводу користувача для руху
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		// Обертання гравця
		currentRotY += horizontal * rotationSpeed * Time.deltaTime;
		transform.rotation = Quaternion.Euler(0, currentRotY, 0);

		// Визначення швидкості (біг або ходьба)
		//currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

		if (Input.GetKey(KeyCode.LeftShift))
		{
			currentSpeed = runSpeed;
		}
		else
		{
			currentSpeed = walkSpeed;
		}

		// Якщо немає руху, швидкість дорівнює нулю
		if (Mathf.Abs(horizontal) + Mathf.Abs(vertical) == 0)
		{
			currentSpeed = 0;
		}

		// Рух вперед-назад з урахуванням поточного напрямку обертання
		Vector3 direction = transform.forward * vertical * currentSpeed;
		direction.y = rb.velocity.y; // Збереження вертикальної швидкості

		rb.velocity = direction; // Застосування нової швидкості
	}

	private void HandleAnimation()
	{
		// Оновлення стану анімації "на землі"
		animator.SetBool("IsGround", groundChecker.isGrounded);

		// Оновлення швидкості для анімації
		animator.SetFloat("Speed", currentSpeed);
	}

	void Update()
	{
		// Обробка вводу та анімацій
		HandleInput();
		HandleAnimation();
	}

	void FixedUpdate()
	{
		// Обробка фізичного руху
		HandleMovement();
	}
}
