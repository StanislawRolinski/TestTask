using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] float spawnSpeed = 4;
    private float timeSinceLastSpawn = 0;

    float xMin;
    float xMax;
    [SerializeField] float pudding = 2f;
    float yMin;
    float yMax;
   



    void Start()
    {

        SetUpBoundries();
        SpawnBall();
    }

    private void Update()
    {
        if(timeSinceLastSpawn >= spawnSpeed)
        {
            int chance = UnityEngine.Random.Range(0, 100);
            spawnSpeed = SceneController.sceneController.TimeBeetweenSpanw;
            timeSinceLastSpawn = 0;
            if (chance <= 9)
            {
                SpawnMine();
            }
            else
            {
                SpawnBall();
            }
            
        }
        timeSinceLastSpawn += Time.deltaTime;
    }
    private void SpawnBall()
    {
        GameObject obj = BallPooler.current.GetPooledBall();
        if (obj != null)
        {
            obj.transform.position = SetRandomLocation();
            obj.transform.rotation = Quaternion.identity;
            obj.SetActive(true);
        }
    }
    
    private void SpawnMine()
    {
        GameObject obj = BallPooler.current.GetPooledMine();
        if (obj != null)
        {
            obj.transform.position = SetRandomLocation();
            obj.transform.rotation = Quaternion.identity;
            obj.SetActive(true);
        }
    }

    private void SetUpBoundries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + pudding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - pudding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + pudding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - pudding;
    }

    public Vector3 SetRandomLocation()
    {
        Vector3 randomLocation = new Vector3(UnityEngine.Random.Range(xMin, xMax), UnityEngine.Random.Range(yMin, yMax), 0);
        return randomLocation;
    }
}
