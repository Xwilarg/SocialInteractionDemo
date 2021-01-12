using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private const float _speed = 10f;
    private const float _sensibilityX = 2f;
    private const float _sensibilityY = 2f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        int x = 0, y = 0;
        if (Input.GetKey(KeyCode.Z)) y = 1;
        else if (Input.GetKey(KeyCode.S)) y = -1;
        if (Input.GetKey(KeyCode.Q)) x = -1;
        else if (Input.GetKey(KeyCode.D)) x = 1;
        var axis2D = (new Vector2(transform.forward.x, transform.forward.z) * y) + (new Vector2(transform.right.x, transform.right.z) * x);
        axis2D.Normalize();
        _rb.velocity = new Vector3(axis2D.x * _speed, _rb.velocity.y, axis2D.y * _speed);

        float rotX = Input.GetAxis("Mouse X");
        float rotY = Input.GetAxis("Mouse Y");
        transform.Rotate(rotX * Vector3.up * _sensibilityY);
        Camera.main.transform.Rotate(rotY * Vector3.left * _sensibilityX);
    }
}
