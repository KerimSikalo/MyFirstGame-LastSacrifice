using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //Za restartovanje 

public class Enemy : MonoBehaviour
{
    public float speed;

    public float minX, maxX, minY, maxY;

    Vector3 currentTarget;

    public GameObject blood;

    private Animator camAnim;


    // Start is called before the first frame update
    void Start()
    {
        camAnim = Camera.main.GetComponent<Animator>();
        currentTarget = GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {   
        if(Vector3.Distance(transform.position, currentTarget) > 0.5f) //NE ZABORAVLJATI f (za decimale)
        //current position, move towards,  Time.deltaTime - time between two frames
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime); //VAZNO da bi podrzalo sve kompjutere
        else
        {
            currentTarget = GetRandomPosition();
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        return randomPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)   //AUTOMATSKA FUNKCIJA UNITYA
    {
        if (collision.tag=="Altar")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //OVO JE ZA RESTARTOVANJE LEVELA
        }

        if (collision.tag == "Trap")
        {
            camAnim.SetTrigger("shake");
            Destroy(collision.gameObject);  //za trap da nestane
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
