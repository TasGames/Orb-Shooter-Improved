using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected float bulletDelay;
    [SerializeField] protected float bulletDespawn;
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] protected GameObject bulletPrefab;
    protected float timer = 0;
    protected bool canFire = true;

    [SerializeField] protected Transform _sphere;

    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float rotateSpeed;

    [SerializeField] protected AudioClip shoot;

    protected void Fire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position + 1 * transform.forward, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        Destroy(bullet, bulletDespawn);
        canFire = false;
        timer = 0;

        bullet.GetComponent<Gravity>().setSphere(_sphere);

        GetComponent<AudioSource>().Play();

    }
}
