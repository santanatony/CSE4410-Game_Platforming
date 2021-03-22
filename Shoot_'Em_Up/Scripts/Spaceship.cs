using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    int delay = 0;
    GameObject a;
    public GameObject bullet, explosion;
    Rigidbody2D rb;
    public float speed;
    int health = 3;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("a").gameObject;
    }

    void Start()
    {
        PlayerPrefs.SetInt("Health", health);

    }

    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));

        if(Input.GetKey(KeyCode.Space) && delay > 10)
            Shoot();

        delay++;
            
    }

    public void Damage()
    {
        health--;
        PlayerPrefs.SetInt("Health", health);
        StartCoroutine(Blink());
        if(health == 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        IEnumerator Blink()
        {
            GetComponent<SpriteRenderer>().color = new Color(1,0,0);
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(1,1,1);

        }   
    }

    void Shoot(){
        delay = 0;
        Instantiate(bullet, a.transform.position, Quaternion.identity);
    }

    public void AddHealth()
    {
        health++;
        PlayerPrefs.SetInt("Health", health);
    }
}
