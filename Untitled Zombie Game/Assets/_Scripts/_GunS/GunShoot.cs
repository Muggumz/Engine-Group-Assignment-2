using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunShoot : MonoBehaviour
{
    [SerializeField]
    private InformationValues informationValues;

    PlayerAction inputAction;

    public bool Switch = false;

    public GameObject projectile;
    public Transform projectilePos;

    public int damageNumber;

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }

private void Awake()
    {
        inputAction = new PlayerAction();

        inputAction.PlayerShoot.Shoot.performed += cntxt => Shoot(Switch);
    }

private void Shoot(bool state)
    {
        //Rigidbody bulletRb = Instantiate(projectile, projectilePos.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        Rigidbody bulletRb = ObjectPooler.instance.SpawnFromPool("Bullet", projectilePos.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        //bulletRb.AddForce(transform.up * 1f, ForceMode.Impulse);
        if (!state)
        {
            damageNumber = informationValues.damage._SmallDamage;
        }
        else damageNumber = informationValues.damage._BigDamage;
    }
}
