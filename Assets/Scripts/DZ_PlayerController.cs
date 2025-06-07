using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DZ_PlayerController : MonoBehaviour
{
	// ������ ��������� ��� ������������ ��������
	public float walkSpeed = 5.5f;
	public float runSpeed = 12f;
	public float rotationSpeed = 10f;
	public float jumpForce = 8.5f;

	// ������ �����
	public float currentSpeed;
	private float currentRotY;

	// ����������
	private Animator animator;
	private GroundChecker groundChecker;
	private Rigidbody rb;

	void Start()
	{
		// ����������� ����������
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		groundChecker = GetComponentInChildren<GroundChecker>();
	}

	private void HandleInput()
	{
		// ������� �������
		if (Input.GetButtonDown("Jump") && groundChecker.isGrounded)
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // ������ ������� ��� �������
			animator.SetTrigger("Jump"); // ���������� ������ ������� �������
		}
	}

	private void HandleMovement()
	{
		// ��������� ����� ����������� ��� ����
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		// ��������� ������
		currentRotY += horizontal * rotationSpeed * Time.deltaTime;
		transform.rotation = Quaternion.Euler(0, currentRotY, 0);

		// ���������� �������� (�� ��� ������)
		//currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

		if (Input.GetKey(KeyCode.LeftShift))
		{
			currentSpeed = runSpeed;
		}
		else
		{
			currentSpeed = walkSpeed;
		}

		// ���� ���� ����, �������� ������� ����
		if (Mathf.Abs(horizontal) + Mathf.Abs(vertical) == 0)
		{
			currentSpeed = 0;
		}

		// ��� ������-����� � ����������� ��������� �������� ���������
		Vector3 direction = transform.forward * vertical * currentSpeed;
		direction.y = rb.velocity.y; // ���������� ����������� ��������

		rb.velocity = direction; // ������������ ���� ��������
	}

	private void HandleAnimation()
	{
		// ��������� ����� ������� "�� ����"
		animator.SetBool("IsGround", groundChecker.isGrounded);

		// ��������� �������� ��� �������
		animator.SetFloat("Speed", currentSpeed);
	}

	void Update()
	{
		// ������� ����� �� �������
		HandleInput();
		HandleAnimation();
	}

	void FixedUpdate()
	{
		// ������� ��������� ����
		HandleMovement();
	}
}
