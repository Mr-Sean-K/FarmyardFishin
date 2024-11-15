using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] fishPrefabs;
    public GameObject[] animalPrefabs;

   //the limit on the X and Y axis in which the fish will spawn 
    public float spawnLimitXLeft = -27;
    public float spawnLimitXRight = 27;
    public float spawnLimitYDown = 7;
    public float spawnLimitYUp = 15;

    //speed and spawn rate
    public float startDelay = 1f;
    public float spawnInterval = 4f;
    public float spawnSpeed = 2f;    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFish", startDelay, spawnInterval);
        InvokeRepeating("SpawnAnimal", startDelay, spawnInterval); 

    }

    // Update is called once per frame
    void SpawnFish ()
    {
        //Generate a random fish in a random postion
        int index = Random.Range(0, fishPrefabs.Length);
        float randomY = Random.Range(spawnLimitYDown, spawnLimitYUp);


        Vector3 spawnPosLeft = new Vector3(spawnLimitXLeft, randomY, -26);
        Vector3 spawnPosRight = new Vector3(spawnLimitXRight, randomY, -26);

        GameObject fish = Instantiate(fishPrefabs[index], spawnPosLeft, fishPrefabs[index].transform.rotation);
        // Instantiate(fishPrefabs[index], spawnPosRight, fishPrefabs[index].transform.rotation);

        NPCMovement fishMovement = fish.GetComponent<NPCMovement>();
        if (fishMovement != null){
            fishMovement.speed = Random.Range(2f, 6f);
        }
    }

    void SpawnAnimal(){
        int index = Random.Range(0, animalPrefabs.Length);

        Vector3 SpawnPosLeft = new Vector3(spawnLimitXLeft, 0.7f, -26);

        GameObject animal = Instantiate(animalPrefabs[index], SpawnPosLeft, animalPrefabs[index].transform.rotation);
        NPCMovement fishMovement = animal.GetComponent<NPCMovement>();
        if (fishMovement != null){
            fishMovement.speed = Random.Range(2f, 6f);
        }
    }
}