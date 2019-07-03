using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    protected Rigidbody enemyRb;
    [SerializeField] protected float fDistance;

    void Start ()
    {
        enemyRb = GetComponent<Rigidbody>();
        GetComponent<AudioSource>().clip = shoot;
    }
	
	void Update ()
    {
        timer += Time.deltaTime;

        if (timer > bulletDelay)
            canFire = true;

        TrackPlayer();
	}

    void TrackPlayer()
    {
        var target = GameObject.Find("Ship_1").transform.position;
        var lookPos = target - transform.right;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotateSpeed);
        enemyRb.velocity = moveSpeed * transform.forward;

        float distance = Vector3.Distance(target, transform.position);
        if (distance < fDistance && canFire)
            Fire();

    }
}
