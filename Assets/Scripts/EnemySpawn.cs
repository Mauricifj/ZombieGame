using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField] int timeToNextZombie;
    private float now;

    void Update()
    {
        now += Time.deltaTime;

        timeToNextZombie = Random.Range(1, 20);

        if (now > timeToNextZombie)
        {
            Instantiate(zombie, transform.position, transform.rotation);
            now = Time.deltaTime;
        }
    }
}
