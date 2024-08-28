using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.TouchPhase;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent OnMoveInput;
    
    private Rigidbody2D RigidbodyCompo;
    private FloatingJoystick Joystick;

    private Animator _animator;
    
    public PlayerAction _controls;
    private Vector2 moveInput;
    [SerializeField] private float moveSpeed;
    [SerializeField] public Vector3 moveDirection;
    private GameObject visual;
    
    public bool isMoving;

    private void Awake()
    {
        RigidbodyCompo = GetComponent<Rigidbody2D>();
        Joystick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();
        visual = transform.Find("Visual").gameObject;
        _animator = visual.transform.GetComponentInChildren<Animator>();
    }

    #region KeyboardInput
        //_controls = new PlayerAction();

        // Enable the PlayerControls input actions
        //_controls.Enable();

        // Subscribe to the move action performed and canceled events
        //_controls.PlayerMap.Move.performed += OnMovePerformed;
        //_controls.PlayerMap.Move.canceled += OnMoveCanceled;
    //}

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        //OnMoveInput.Invoke();
        //moveInput = context.ReadValue<Vector2>();
        //moveDirection = new Vector3(moveInput.x, moveInput.y, 0f);
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        //moveInput = Vector2.zero;
        //moveDirection = new Vector3(moveInput.x, moveInput.y, 0f);
    }

        #endregion
    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) OnMoveInput.Invoke();
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                OnMoveInput.Invoke();
            }
        }
        
        if (Input.touchCount > 0 || moveDirection.magnitude > 0)
            isMoving = true;
        else
            isMoving = false;
    }

    private void FixedUpdate()
    {
        moveDirection = Joystick.Direction;
        RigidbodyCompo.velocity = moveDirection * moveSpeed;
        _animator.SetFloat("speed", moveDirection.magnitude);
        if (moveDirection.x > 0) visual.transform.localScale = new Vector3(-2,2,2);
        else visual.transform.localScale = new Vector3(2,2,2);
    }

    private void OnEnable()
    {
        // Enable the PlayerControls input actions when this script is enabled
        //_controls.Enable();
    }

    private void OnDisable()
    {
        // Disable the PlayerControls input actions when this script is disabled
        //_controls.Disable();
    }

}
