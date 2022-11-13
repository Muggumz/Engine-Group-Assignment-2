using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Throwing : MonoBehaviour
{
    [Header("Reference")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    //public KeyCode throwkey = KeyCode.Mouse1;
    public float throwForce;
    public float throwUpwardForce;

    public PlayerAction inputAction;

    bool readyToThrow;

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
    }

    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        if(readyToThrow && totalThrows > 0)
        {
            inputAction.Throw.Throws.performed += cntxt => Throws();
        }
    }

    private void Throws()
    {
        readyToThrow = false;
        inputAction.Throw.Disable();
        // instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // rigidbody component
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        // implement throwCooldown

        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        inputAction.Throw.Enable();
        readyToThrow = true;
    }
}
