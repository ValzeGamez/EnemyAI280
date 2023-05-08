using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput input = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody rb = null;
    public float moveSpeed = 10f;

    public GameObject bullet;
    public Transform bulletDirection;

    private bool canShoot = true;

    private void Awake()
    {
        input = new PlayerInput();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPreformed;
        input.Player.Movement.canceled += OnMovementCancelled;
     
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPreformed;
        input.Player.Movement.canceled -= OnMovementCancelled;

    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
    }

    private void OnMovementPreformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
       
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }

    private void Start()
    {
        input.Player.Shoot.performed += _ => PlayerShoot();
    }

    private void PlayerShoot()
    {
        if (!canShoot)
        {
            return;
        }

        Vector2 mousePos = input.Player.MousePosition.ReadValue<Vector2>();
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        GameObject b = Instantiate(bullet, bulletDirection.position, bulletDirection.rotation);
        b.SetActive(true);
        StartCoroutine(CanShoot());
    }

    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(.5f);
        canShoot = true;
    }

    // allows the bullet to shoot in the direction of the mouse position
    private void Update()
    {
        Vector2 mouseScreenPos = input.Player.MousePosition.ReadValue<Vector2>();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Vector3 targetDir = mouseWorldPos - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

}
