using UnityEngine;

public class NormalGun : MonoBehaviour, IGun
{
    [SerializeField] private GameObject _shell;
    [SerializeField] private Transform _shootPoint;

    [SerializeField] private float _shootForce;
    [SerializeField] private float _cooldownShot;
    [SerializeField] private int _reloadTime;
    [SerializeField] private int _clipSize;

    private int _countAmmo;
    private float _remainingCooldown;
    private bool _readyToFire;

    public int CountAmmo => _countAmmo;
    public bool ReadyToFire => _readyToFire;

    public void Initialization()
    {
        _countAmmo = _clipSize;
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

        _countAmmo--;
        _remainingCooldown = _cooldownShot;

        GameObject _bullet = Instantiate(_shell, _shootPoint);
        Vector3 _direction = _shootPoint.position - transform.position;
        _bullet.GetComponent<Rigidbody>().AddForce(_direction * _shootForce, ForceMode.Acceleration);
    }

    public void Reload()
    {
        _readyToFire = false;
        _remainingCooldown = _reloadTime;
        _countAmmo = _clipSize;
    }
}
