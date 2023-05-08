using System;
using UnityEngine;

public class PlayerKontrol : MonoBehaviour
{
    private CharacterController _characterController;
    private PlatformManager _platformManager;
    public Animator Anim;
    private Vector3 _direction;
    public float forwardSpeed;

    private int _desiredLane = 0; // left: -1, middle: 0, right: 1
    [SerializeField] private float _jumpForce, _gravity = -20, _laneDistance = 7f; // distance between lanes

    public void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _platformManager = GameObject.Find("PlatformManager").GetComponent<PlatformManager>();
    }

    private void Update()
    {

        forwardSpeed += Time.deltaTime;
        _direction.z = forwardSpeed;

        _direction.y += _gravity * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        
        //Calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (_desiredLane == -1)
            targetPosition += Vector3.left * _laneDistance;
        else if (_desiredLane == 1)
            targetPosition += Vector3.right * _laneDistance;
        
        //simply version of bellow => transform.position = targetPosition;
        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 20 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.magnitude)
                _characterController.Move(moveDir);
            else
                _characterController.Move(diff);
        }

        
        

        // gather the inputs on which lane we should be
        MoveWithInput();

       
    }

    public void FixedUpdate()
    {
        // Character moves by to the given direction

        _characterController.Move(_direction * Time.fixedDeltaTime);
    }

    private void MoveWithInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _desiredLane--;
            if (_desiredLane == -2)
                _desiredLane = -1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _desiredLane++;
            if (_desiredLane == 2)
                _desiredLane = 1;
        }
    }

    private void Jump()
    {
        _direction.y = _jumpForce;
        Anim.SetTrigger("jump");
    }


    private void OnTriggerEnter(Collider trig)
    {
        if (trig.CompareTag("NewPlatformTrigger"))
        {
            _platformManager.SpawnPlatform();
            Destroy(trig.transform.parent.gameObject, 3f);
            
        }
    }

    
}