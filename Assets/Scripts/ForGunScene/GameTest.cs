using UnityEngine;

public class GameTest : MonoBehaviour
{
    private GunController _gunController;

    private IGun[] _guns = new IGun[3];

    private void Awake()
    {
        Debug.Log("Q - сменить оружие на рандомное; R - перезарядить выбранное оружие (необходимо подождать); ЛКМ - выстрелить");

        _guns[0] = FindObjectOfType<NormalGun>();
        _guns[1] = FindObjectOfType<MultiShotGun>();
        _guns[2] = FindObjectOfType<GunWithInfinityAmmo>();

        foreach (IGun gun in _guns)
            gun.Initialization();

        _gunController = new GunController(_guns[0]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            _gunController.ReloadGun();

        if (Input.GetMouseButtonDown(0))
            _gunController.Fire();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            int _randomIndex = Random.Range(0, _guns.Length);
            _gunController.ChangeGun(_guns[_randomIndex]);
            Debug.Log($"Выбрано оружие {_guns[_randomIndex].GetType()}");
        }
    }
}
