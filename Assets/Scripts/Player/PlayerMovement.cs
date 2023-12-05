using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    [SerializeField] private float _movementSpeed;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 movementVector = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

        if (movementVector != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(movementVector);

        transform.position += _movementSpeed * Time.deltaTime * movementVector;
    }
}
