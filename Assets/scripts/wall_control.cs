using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wall_control : MonoBehaviour
{
    public GameObject panel; 
    private Rigidbody2D rb; 
    public Text timer; 
    public Text text; 
    public float time = 60; 
    private bool left = false; 
    private bool right = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        time -= Time.deltaTime; 
        timer.text = Mathf.Ceil(time).ToString(); 

        if (time <= 0)
        {
            Time.timeScale = 0f; 
            GameOver(); 
            timer.text = "0"; 
        }

        if (Input.touchCount > 0)
        {
            text.enabled = false; 
            Touch touch = Input.GetTouch(0);

            if (touch.deltaPosition.x > 50f)
            {
                right = true;
                left = false;
            }

            if (touch.deltaPosition.x < -50f)
            {
                right = false;
                left = true;
            }
        }

        if (left)
        {
            MoveLeft();
        }
        else if (right)
        {
            MoveRight();
        }
    }

    public void GameOver()
    {
        panel.SetActive(true); 
        Time.timeScale = 1; 
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-10, 0); 
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(10, 0); 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            Collider2D collider = other.collider;

            if (collider.sharedMaterial != null)
            {
                float bounciness = collider.sharedMaterial.bounciness;
                PhysicsMaterial2D newMaterial = new PhysicsMaterial2D();
                newMaterial.bounciness = 0; 
                collider.sharedMaterial = newMaterial;
            }
        }
    }
}
