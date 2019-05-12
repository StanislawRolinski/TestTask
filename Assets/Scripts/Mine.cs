using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    private float lifeTime = 3f;
    [SerializeField] BallSpawner spawner;


    private void OnMouseDown()
    {
        gameObject.SetActive(false);
        Time.timeScale = 0;
        SceneController.sceneController.ShowHighestScore();
    }
    private void OnEnable()
    {
        Invoke("Disable", lifeTime);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    private void Disable()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        transform.position = spawner.SetRandomLocation();
    }
}
