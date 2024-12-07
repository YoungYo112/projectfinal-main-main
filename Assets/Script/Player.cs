using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : Character, Ishootable
{
    
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform BulletSpawnPoint { get; set; }
    [field: SerializeField] public float BulletSpawnTime { get; set; }
    [field: SerializeField] public float BulletTimer { get; set; }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && BulletSpawnTime >= BulletTimer)
        {
            GameObject obj = Instantiate(Bullet, BulletSpawnPoint.position, Quaternion.identity);
            Bullet bullet = obj.GetComponent<Bullet>();
            bullet.Init(10, this);
            BulletSpawnTime = 0;
        }
    }

    void Start()
    {
        Init(10);
        BulletTimer = 1.0f;
        BulletSpawnTime = 0.0f;

    }

    public void Update()
    {
        Shoot();
    }

    private void FixedUpdate()
    {
        BulletSpawnTime += Time.fixedDeltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinSound.Play();
            Destroy(other.gameObject);

            coin++;
            coinUI.text = "Coin :" + coin;
            targetScore--;
            if (targetScore == 0)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
