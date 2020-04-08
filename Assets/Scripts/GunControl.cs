using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject shootingPosition;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, shootingPosition.transform.position, shootingPosition.transform.rotation);
        }
    }
}
