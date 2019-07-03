using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    static public int score = 0;
    [SerializeField] protected bool isBullet;

    void OnCollisionEnter(Collision collision)
    {
        if (isBullet == true)
        {
            if (collision.gameObject.tag == "EnemyTag")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                score += 100;
                Spawner.numEnemies += -1;
            }
            else if (collision.gameObject.tag == "Player")
            {
                Destroy(gameObject);
                PlayerController.health += -10;
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player" && PlayerController.health < 90)
            {
                Destroy(gameObject);
                PlayerController.health += 10;
                Spawner.numHealth += -1;
            }
            else
            {
                Destroy(gameObject);
                Spawner.numHealth += -1;
            }
        }

    }
}
