using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    bool isSelected;

    public LayerMask resourseLayer;
    public float collectDistance;
    Resourse currentResourse;

    public float timeBetweenCollect;
    float nextCollectTime;
    public int collectAmmount;

    GameObject bloodAltar;
    public float distanceToAltar;

    public GameObject resourcePopUp;

    private AudioSource popSound;
    public GameObject deathSound;

    // Start is called before the first frame update
    void Start()
    {
        popSound = GetComponent<AudioSource>();
        bloodAltar = GameObject.FindGameObjectWithTag("Altar");
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            transform.position = mousePos;
        }
        else 
        {
            if (Vector3.Distance(transform.position, bloodAltar.transform.position)<= distanceToAltar)
            {
                Instantiate(deathSound);
                ResourceManager.instance.AddSacrificedWorker();
                Destroy(gameObject);
            }


            Collider2D col = Physics2D.OverlapCircle(transform.position, collectDistance, resourseLayer);
            if (col != null && currentResourse==null)
            {
                currentResourse=col.GetComponent<Resourse>();
            } else currentResourse = null;

            if (currentResourse != null)
                if (Time.time > nextCollectTime) 
                {
                    Instantiate(resourcePopUp, transform.position, Quaternion.identity);
                    nextCollectTime = Time.time+timeBetweenCollect;
                    currentResourse.resourseAmmount -= collectAmmount;
                    ResourceManager.instance.AddResource(currentResourse.resourseType, collectAmmount);
                }
                   
                
            


        }
    }

    private void OnMouseDown()
    {
        popSound.Play();
        isSelected = true;
    }

    private void OnMouseUp()
    {
        isSelected = false;
    }
}
