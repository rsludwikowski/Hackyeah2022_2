using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Enemy : MonoBehaviour
{


    public int maxHealth = 3;
    public int currentHealth;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 30;
    public float bulletTime = 30;
    public float lastfired = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

    }
    void FixedUpdate()
    {
        if (Time.time - lastfired > 3)
        {
            lastfired = Time.time;
            Debug.Log("FIREEEEEEEEE!!!\n");
            EnemyFire();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        string colTag = collision.gameObject.tag;
        switch (colTag)
        {
            case "EnemyBullet":
                Shooting shooting = collision.gameObject.GetComponent<Shooting>();
                Demage(shooting.bulletDamage);
                break;
        }

        void Demage(int demageGet)
        {
            Debug.Log("Aaaa you hit me!");
            currentHealth -= demageGet;
            Debug.Log(currentHealth);
            if (currentHealth <= 0)
            {
                Debug.Log("Aaaa you kill me!");
                Destroy(gameObject);
            }
        }
    }
    private IEnumerator DestroyBullet(GameObject bullet, float bulletlifetime) //zeby kula nie leciala w nieskonczonosc
    {
        yield return new WaitForSeconds(bulletlifetime);
        Destroy(bullet);
    }

    private void EnemyFire () {
        GameObject bullet = Instantiate(bulletPrefab,bulletSpawn.position,Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward*bulletSpeed, ForceMode.Impulse);
        StartCoroutine(DestroyBullet(bullet, bulletTime));
    }
}
