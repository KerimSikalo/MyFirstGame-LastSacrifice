using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResourceManager : MonoBehaviour
{
    public int wood;
    public int crystal;
    public int blood;

    public TMP_Text woodDisplay;
    public TMP_Text bloodDisplay;
    public TMP_Text crystalDisplay;

    public static ResourceManager instance;

    public int numberOfWorkersSacrified;
    public TMP_Text sacrificedTxt;
    public int sacrificeGoal;

    private void Awake()
    {
        instance= this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddResource(string resourceType, int ammount) 
    {
        if (resourceType == "wood") 
        {
            wood += ammount;
            woodDisplay.text = wood.ToString();
        }

        if (resourceType == "blood") 
        {
            blood += ammount;
            bloodDisplay.text = blood.ToString();
        }

        if (resourceType == "crystal") 
        { 
            crystal += ammount;
            crystalDisplay.text = crystal.ToString();
        } 
    }

    public void AddSacrificedWorker()
    {
        numberOfWorkersSacrified++;
        sacrificedTxt.text = numberOfWorkersSacrified + " / " + sacrificeGoal;

        if(numberOfWorkersSacrified >= sacrificeGoal)
        {
            print("YOU HAVE WON!!!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
