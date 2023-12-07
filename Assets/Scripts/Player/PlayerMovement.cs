using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _movementSpeed;

    private float _horizontal;
    private float _vertical;

    private void Update()
    {
        GetMovementInputs();
    }

    private void FixedUpdate()
    {
        SetMovement();
    }

    private void SetMovement()
    {
        Vector3 _vector3 = new(_horizontal, 0, _vertical);
        Vector3 movementVector = _movementSpeed * Time.fixedDeltaTime * _vector3;
        
        _rb.velocity = movementVector;
        if (movementVector != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(movementVector);
    }

    private void GetMovementInputs()
    {
        _horizontal = _joystick.Horizontal;
        _vertical = _joystick.Vertical;
    }
    
    /*private void Movement()
    {  
        Vector3 movementVector = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

        if (movementVector != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(movementVector);

        //transform.position += _movementSpeed * Time.deltaTime * movementVector;*/
}
