using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private const float _speed = 10f;
    private const float _sensibilityX = 2f;
    private const float _sensibilityY = 2f;

    private const float _shootForce = 50f;

    private const float _timerBetweenShootRef = .5f;
    private float _timerBetweenShoot = 0f;

    private float _baseHealthUISize;

    [SerializeField]
    private RectTransform _healthUI;

    [SerializeField]
    private Text _ammoText;

    [SerializeField]
    private GameObject _bulletPrefab, _gunEnd;

    private int _nbAmmo;
    private const int _refNbAmmo = 15;

    private bool _isReloading = false;
    private const float _gunReloadTime = 3f;

    private void Start()
    {
        _nbAmmo = _refNbAmmo;
        _ammoText.text = _nbAmmo + " / ∞";
        _rb = GetComponent<Rigidbody>();
        _baseHealthUISize = _healthUI.sizeDelta.x;
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

    private void Update()
    {
        _timerBetweenShoot -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && _timerBetweenShoot <= 0f && !_isReloading)
        {
            var bullet = Instantiate(_bulletPrefab, _gunEnd.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _shootForce, ForceMode.Impulse);
            Destroy(bullet, 5f);
            _timerBetweenShoot = _timerBetweenShootRef;
            _nbAmmo--;
            if (_nbAmmo == 0)
            {
                _ammoText.text = "Reloading...";
                _isReloading = true;
                StartCoroutine(Reload());
            }
            else
                _ammoText.text = _nbAmmo + " / ∞";
        }
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(_gunReloadTime);
        _isReloading = false;
        _nbAmmo = _refNbAmmo;
        _ammoText.text = _nbAmmo + " / ∞";
    }
}
