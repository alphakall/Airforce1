using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public GameObject flash;
    public float bulletSpawnTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        flash.SetActive(false);
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Fire()
        {
           Instantiate(playerBullet, spawnPoint1.position, Quaternion.identity); //spawn bullets at gameobject attached to public transform variable
           Instantiate(playerBullet, spawnPoint2.position, Quaternion.identity);
        }
        
        IEnumerator Shoot()
        {
          while (true)
          {
                     yield return new WaitForSeconds (bulletSpawnTime); // delayed loop using Co-routine and public Var
                     Fire();
                     flash.SetActive(true);
                     yield return new WaitForSeconds (0.04f);
                    flash.SetActive(false);

          }
        }
        
    }

