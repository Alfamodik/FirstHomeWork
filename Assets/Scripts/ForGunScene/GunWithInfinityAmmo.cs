using UnityEngine;

public class GunWithInfinityAmmo : MonoBehaviour, IGun
{
    [SerializeField] private GameObject _shell;
    [SerializeField] private Transform _shootPoint;

    [SerializeField] private float _shootForce;

    [SerializeField] private float _cooldownShot;

    private float _remainingCooldown;
    private bool _readyToFire;

    public int CountAmmo => -1;
    public bool ReadyToFire => _readyToFire;

    public void Initialization() { }

    private void Update()
    {
        if (_remainingCooldown <= 0)
            _readyToFire = true;
        else if (_remainingCooldown > 0)
            _remainingCooldown -= Time.deltaTime;
    }

    public void Fire()
    {
        if (_readyToFire == false)
            Debug.LogWarning("Оружие было не готово к выстрелу, но был вызван метод Fire!");

        _readyToFire = false;

        _remainingCooldown = _cooldownShot;
        GameObject _bullet = Instantiate(_shell, _shootPoint);
        Vector3 _direction = _shootPoint.position - transform.position;
        _bullet.GetComponent<Rigidbody>().AddForce(_direction * _shootForce, ForceMode.Acceleration);
    }

    public void Reload() { }
}
