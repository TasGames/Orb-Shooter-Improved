using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject enemyPrefab;
    [SerializeField] protected float spawnDelay;
    [SerializeField] protected int maxEnemies;
    static public int numEnemies;
    protected float timer;

    [SerializeField] protected GameObject healthPrefab;
    [SerializeField] protected int maxHealthPack;
    static public int numHealth;

    [SerializeField] protected Transform _sphere;
    [SerializeField] protected Mesh _sphereMesh;

    void Start ()
    {
        timer = 0;
        numHealth = 0;
        numEnemies = 0;
    }
	
	void Update ()
    {
        spawnHealthPack();

        timer += Time.deltaTime;

        if (timer > spawnDelay)
            spawnEnemy();
    }

    void spawnEnemy()
    {
        if (numEnemies <= maxEnemies)
        {
            Vector3 spawnLocation = Random.onUnitSphere * 14;
            var enemy = (GameObject)Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
            enemy.GetComponent<Gravity>().setSphere(_sphere);
            numEnemies += 1;
            timer = 0;
        }
    }

    void spawnHealthPack()
    {
        if (numHealth <= maxHealthPack)
        {
            Vector3 spawnLocation = Random.onUnitSphere * 14;
            var healthPack = (GameObject)Instantiate(healthPrefab, spawnLocation, Quaternion.identity);
            numHealth += 1;
        }
    }
}
