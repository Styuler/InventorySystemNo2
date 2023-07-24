using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShootAction : Activity
{
    [SerializeField] private GameObject projectilePrefab;
    private Rigidbody2D rb;
    private int projectileCount;

    private void Awake()
    {
        projectileCount = 0;
    }

    public override void Act(StateController controller)
    {
        if (projectileCount < 1)
        {
            ProjectileShoot();
        }
    }

    public void ProjectileShoot()
    {
        for (projectileCount = 0; projectileCount < 10; projectileCount++)
        {
            GameObject obj = Instantiate(projectilePrefab);
        }
    }
}
