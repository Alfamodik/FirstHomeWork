using UnityEngine;

public class MultiShotGun : MonoBehaviour, IGun
{
    public const int NumberOfBulletsPerShot = 3;

    [SerializeField] private GameObject _shell;

    [SerializeField] private Transform _leftShootPoint;
    [SerializeField] private Transform _middleShootPoint;
    [SerializeField] private Transform _rightShootPoint;

    [SerializeField] private Vector2 _bulletOffSet;

    [SerializeField] private float _shootForce;

    [SerializeField] private float _cooldownShot;
    [SerializeField] private int _reloadTime;
    [SerializeField, Range(3, 99)] private int _clipSize;
    
    private int _countAmmo;

    private float _remainingCooldown;

    private bool _readyToFire;

    public int CountAmmo => _countAmmo;
    public bool ReadyToFire => _readyToFire;

    public void Initialization()
    {
        _countAmmo = _clipSize;
    }

    private void OnValidate()
    {
        if (_clipSize % NumberOfBulletsPerShot != 0)
        {
            _clipSize += NumberOfBulletsPerShot - (_clipSize % NumberOfBulletsPerShot);
        }
    }

    private void Update()
    {
        if (_remainingCooldown <= 0 && _countAmmo > 0)
            _readyToFire = true;
        else if (_remainingCooldown > 0)
            _remainingCooldown -= Time.deltaTime;
    }

    public void Fire()
    {
        if (_readyToFire == false)
            Debug.LogWarning("Оружие было не готово к выстрелу, но был вызван метод Fire!");

        _readyToFire = false;

        _countAmmo -= NumberOfBulletsPerShot;
        _remainingCooldown = _cooldownShot;

        Vector3 _leftDirection = _leftShootPoint.position - transform.position;
        Vector3 _middleDirection = _middleShootPoint.position - transform.position;
        Vector3 _rightDirection = _rightShootPoint.position - transform.position;

        GameObject _bullet = Instantiate(_shell, _leftShootPoint);
        _bullet.GetComponent<Rigidbody>().AddForce(_leftDirection * _shootForce, ForceMode.Acceleration);

        _bullet = Instantiate(_shell, _middleShootPoint);
        _bullet.GetComponent<Rigidbody>().AddForce(_middleDirection * _shootForce, ForceMode.Acceleration);

        _bullet = Instantiate(_shell, _rightShootPoint);
        _bullet.GetComponent<Rigidbody>().AddForce(_rightDirection * _shootForce, ForceMode.Acceleration);
    }

    public void Reload()
    {
        _readyToFire = false;
        _remainingCooldown = _reloadTime;
        _countAmmo = _clipSize;
    }
}
