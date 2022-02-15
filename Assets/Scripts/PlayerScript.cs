using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10f;
    public float borderCalibration = 0.8f;
    public GameObject explosion;
    public PlayerHealthBarScript playerHealthbar;
    public GameObject GameOver;

    
    public float health = 20f;
    float barFillAmount = 1f;
    float damage = 0; 

    float minX;
    float maxX;
    float minY;
    float maxY;



    // Start is called before the first frame update
    void Start()
    {
        GameOver.SetActive(false);
        FindBoundaries();
        damage = barFillAmount / health;

    }

       void FindBoundaries()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + borderCalibration; //converting viewport v3 value to min x and max x position for aspect ratio
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - borderCalibration;

        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + borderCalibration; 
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - borderCalibration;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;    // frame independent by using delta time
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        float newXpos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);        //getter + clamp
        float newYpos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

        
        transform.position = new Vector2(newXpos, newYpos);           //setter
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="EnemyBullet")
        {
            DamagePlayerHealthbar();
            Destroy(collision.gameObject);
             
             if(health<=0)
            {
                Destroy(gameObject);
                GameObject blast = Instantiate(explosion,transform.position,Quaternion.identity);
                Destroy(blast,2f);
                GameOver.SetActive(true);
            }
        }

    }

    void DamagePlayerHealthbar()
    {

        if (health>0)
        {
            health -= 1;
            barFillAmount = barFillAmount - damage;
            playerHealthbar.SetAmount(barFillAmount);
        }


    }
}  
