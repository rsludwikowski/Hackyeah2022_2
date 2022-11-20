using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Boss : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    public Transform bulletSpawn3;
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
            EnemyFire1();
            EnemyFire2();
            EnemyFire3();
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

    private void EnemyFire1() //srodek
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn1.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn1.forward * bulletSpeed, ForceMode.Impulse);
        StartCoroutine(DestroyBullet(bullet, bulletTime));
    }
    private void EnemyFire2() //lewo
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn2.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce((bulletSpawn2.forward) * bulletSpeed, ForceMode.Impulse);
        StartCoroutine(DestroyBullet(bullet, bulletTime));
    }
    private void EnemyFire3() //prawo
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn3.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce((bulletSpawn3.forward) * bulletSpeed, ForceMode.Impulse);
        StartCoroutine(DestroyBullet(bullet, bulletTime));
    }
}
