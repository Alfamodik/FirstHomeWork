public interface IGun
{
    public int CountAmmo { get; }
    public bool ReadyToFire { get; }
    public void Initialization();
    public void Fire();
    public void Reload();
}
