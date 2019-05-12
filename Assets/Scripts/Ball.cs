using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    SpriteRenderer spriteRenderer;
    private string invokeCreate = "Create";
    private bool isTapped;
    [SerializeField] GameObject tapPartickle;
    [SerializeField] BallSpawner spawner;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    

    private void OnMouseDown()
    {
        var tapVFX = Instantiate(tapPartickle, transform.position, transform.rotation);
        Destroy(tapVFX, .5f);
        isTapped = true;
        gameObject.SetActive(false);
        SceneController.sceneController.AddToScore();
    }
    private void OnEnable()
    {
        float lifeTime = SceneController.sceneController.BallLifeTime;
        spriteRenderer.color = Color.green;
        Invoke("Disable", lifeTime);
        Invoke("ChangeToYellowCollor", lifeTime / 3);
        Invoke("ChangeToRedCollor", lifeTime * 2 / 3);
        isTapped = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        transform.position = spawner.SetRandomLocation();
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    private void Disable()
    {
        if (isTapped)
        {
            return;
        }
        else
        {
            Time.timeScale = 0;
            SceneController.sceneController.ShowHighestScore();
        }
        
    }
    private void ChangeToYellowCollor()
    {
        spriteRenderer.color = Color.yellow;
    }
    private void ChangeToRedCollor()
    {
        spriteRenderer.color = Color.red;
    }
}
