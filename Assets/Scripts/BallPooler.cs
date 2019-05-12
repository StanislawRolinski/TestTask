using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPooler : MonoBehaviour
{
    public static BallPooler current;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject mine;
    [SerializeField] int poolBallAmount = 16;
    [SerializeField] int poolMineAmount = 4;

    List<GameObject> pooledBalls;
    List<GameObject> pooledMines;

    private void Awake()
    {
        current = this;
    }
    void Start()
    {
        pooledBalls = new List<GameObject>();
        pooledMines = new List<GameObject>();
        for (int i = 0; i < poolBallAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(ball);
            obj.SetActive(false);
            pooledBalls.Add(obj);
        }
        for (int i = 0; i < poolMineAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(mine);
            obj.SetActive(false);
            pooledMines.Add(obj);
        }
    }
    public GameObject GetPooledBall()
    {
        for (int i = 0; i < pooledBalls.Count; i++)
        {
            if (!pooledBalls[i].activeInHierarchy)
            {
                return pooledBalls[i];
            }
        }
        return null;
    }
    public GameObject GetPooledMine()
    {
        for (int i = 0; i < pooledMines.Count; i++)
        {
            if (!pooledMines[i].activeInHierarchy)
            {
                return pooledMines[i];
            }
        }
        return null;
    }
}
