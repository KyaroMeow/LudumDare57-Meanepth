using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    // Переменные для управления звуком шагов
    public float stepInterval = 0.5f; // Интервал между шагами в секундах
    private float stepTimer = 0f;
    private bool isMoving = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if(SettingsManager.instance != null){
            lookSpeed = SettingsManager.instance.Sensitivity;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Определяем, движется ли игрок
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        isMoving = (inputX != 0 || inputY != 0);

        // Мы на земле, поэтому пересчитываем направление движения на основе осей
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Нажатие Left Shift для бега
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * inputY : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * inputX : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Применяем гравитацию
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Перемещаем контроллер
        characterController.Move(moveDirection * Time.deltaTime);

        // Вращение игрока и камеры
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        // Управление звуком шагов
        if (isMoving && characterController.isGrounded)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepInterval)
            {
                SFXManager.instance.PlaySteps();
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }
}
