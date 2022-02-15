using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform gunPoint1;
    public Transform gunPoint2;
    public GameObject enemyBullet;
    public GameObject enemyFlash;
    public GameObject enemyExplosionPrefab;
    public HealthBar healthbar;
    public GameObject completelevelUI;
    public float health = 10f;
    
    float barSize = 1f;
    float damage = 0;

    public float enemyBulletSpawnTime = 0.5f;
    public float speed=1f;

// Start is called before the first frame update
    void Start()
    {
        completelevelUI.SetActive(false);
        enemyFlash.SetActive(false);
         StartCoroutine(EnemyShooting());
        
        damage = barSize / health;
    }

    
    // Update is called once per frame
    void Update()
    {
        transform. Translate(Vector2.down * speed * Time.deltaTime);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="PlayerBullet")
         {
             DamageHealthbar();
             
             Destroy(collision.gameObject);
             if(health<=0)
             {
                    Destroy(gameObject);
                GameObject enemyExplosion = Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
                Destroy (enemyExplosion, 0.4f);
                completelevelUI.SetActive(true);


             }
             
             
         }
    }

    void DamageHealthbar()
    {
    if (health>0)
        {
            health -= 1;
            barSize = barSize - damage;
            healthbar.SetSize(barSize);
        }
    }



    void EnemyFire()
    {
        Instantiate(enemyBullet, gunPoint1.position, Quaternion.identity);
        Instantiate(enemyBullet, gunPoint2.position, Quaternion.identity);
    }
    
    IEnumerator EnemyShooting()
    {while (true)
        {
             yield return new WaitForSeconds (enemyBulletSpawnTime);
             EnemyFire();
             enemyFlash.SetActive(true); 
             yield return new WaitForSeconds (0.04f);
             enemyFlash.SetActive(false);

        } 
    }

}
