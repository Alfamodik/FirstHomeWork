public class GunController
{
    private IGun _currentGun;
    public GunController(IGun gun)
    {
        ChangeGun(gun);
    }
    public void ChangeGun(IGun gun)
    {
        _currentGun = gun;
    }
    public void Fire()
    {
        if (_currentGun.ReadyToFire)
            _currentGun.Fire();
    }
    public void ReloadGun()
    {
        _currentGun.Reload();
    }
}
