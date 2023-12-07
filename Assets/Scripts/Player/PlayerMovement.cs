using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Animator _animator;

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
        {
            transform.rotation = Quaternion.LookRotation(movementVector);
            _animator.SetBool("isWalking", true);
        }

        if (!TryGetComponent(out PlayerInteraction player)) return;

        if (player.HoldingItem != null)
        {
                _animator.SetBool("isWalking", false);
                _animator.SetBool("isCarryingEgg", true);
        }

        if (player.HoldingItem == null)
        {
            _animator.SetBool("isWalking", true);
            _animator.SetBool("isCarryingEgg", false);
        }

        if (movementVector == Vector3.zero)
        {
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isCarryingEgg", false);
        }          
    }

    private void GetMovementInputs()
    {
        _horizontal = _joystick.Horizontal;
        _vertical = _joystick.Vertical;
    }
}
