using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GiraffeMovement : MonoBehaviour
{

    public float speed = 5f;
    Rigidbody rb;
    public GameObject Bullet;
    public Transform bulletSpawnPoint;
    public float bulletEnergy = 1f;
    public ParticleSystem particles;
    public Vector3 offsetSpawn = new Vector3( 0f, 0f, 0f );
    public float offFloat = 1f;
    public int stats = 0;
    public int points = 0;

    public float fireRate = 800f;
    float tempFireRate = 0;
    [SerializeField] int HP;

    bool shot;

    // Start is called before the first frame update
    void Awake()
    {
        shot = false;
        rb = gameObject.GetComponent<Rigidbody>();
        Assert.IsNotNull(rb, "The following object is not fully set up: " + name);
        HP = 100;
    }


    void FireBullet()
    {
        GameObject bullet = Instantiate(Bullet, bulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletEnergy, ForceMode.Impulse);
        particles.Play();
        
    }


    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
           
                if (tempFireRate <= 0f)
                {
                    Debug.Log("FIRE!");
                    FireBullet();
                    shot = true;
                    tempFireRate = (float)(1 / (fireRate/60));
                    Debug.Log(tempFireRate);
                }
                tempFireRate -= Time.deltaTime;

            
        }
        else
        {
            tempFireRate = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {


       



        Vector3 MoveVec = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")).normalized;

        MoveVec *= speed * Time.deltaTime;


        rb.MovePosition(rb.position + MoveVec);

    }

    private void OnCollisionEnter(Collision collision)
    {
        string colTag = collision.gameObject.tag;
        switch (colTag)
        {
            case "Can":
                stats++; //za zebranie puszki bonus do statow
                points++; //zebrany punkt
                break;
        }
    }
}
