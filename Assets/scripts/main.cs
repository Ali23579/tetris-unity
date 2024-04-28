using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    public Image isplaying, isstoping; 
    public GameObject panel,panel_stop, wal,eb,ew,sb,sw,bal,control_wall; 
    public Text sayac_text, number_text; 
    private Rigidbody2D wal_rb; 
    private Rigidbody2D ball_rb; 
    private float TOUCH = 0, number_scorer = 0, timer = 2, NUMBER = 0; 
    private bool gameplaying = true, musicplaying = true; 
    void Start()
    {
        wal_rb = wal.GetComponent<Rigidbody2D>();
        ball_rb = GetComponent<Rigidbody2D>();

        Vector2 randomPosition = new Vector2(Random.Range(-2.45f, 2.45f), Random.Range(-2.5f, 3.6f));
        wal_rb.transform.position = randomPosition;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (Input.touchCount > 0)
        {
            TOUCH++;
        }

        if (TOUCH >= 1 && timer >= 0)
        {
            ball_rb.velocity = new Vector2(2.5f, 5);
        }
    }

    public void button()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void start_stop_control()
    {
        if (gameplaying)
        {
            Time.timeScale = 0;
            isplaying.enabled = false;
            isstoping.enabled = true;

            gameplaying = false;
            musicplaying = false;

            panel_stop.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            isplaying.enabled = true;
            isstoping.enabled = false;

            gameplaying = true;
            musicplaying = true;

            panel_stop.SetActive(false);
        }

        music_start_stop();
    }

    public void music_start_stop()
    {
        if (musicplaying)
        {
            AudioListener.pause = false;
        }
        else
        {
            AudioListener.pause = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("down_wall"))
        {
            Time.timeScale = 0;
            panel.SetActive(true);
        }

        if (other.gameObject.CompareTag("sayac"))
        {
            NUMBER++;
            number_scorer++;

            if (wal_rb != null)
            {
                Vector2 randomPosition = new Vector2(Random.Range(-2.45f, 2.45f), Random.Range(-2.5f, 3.6f));
                wal_rb.transform.position = randomPosition;
            }
        }
        number_text.text = NUMBER.ToString();
        sayac_text.text = number_scorer.ToString();
    }

   private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name =="extend_ball(Clone)")
        {
            if(bal.transform.localScale.x == 0.2f)
            {
                bal.transform.localScale = new Vector2(0.4f, 0.4f);
            }
            else
            {
                bal.transform.localScale = new Vector2(0.8f, 0.8f);
            }

            Destroy(other.gameObject);
        }

        else if(other.gameObject.name == "extend_wall(Clone)")
        {
            if(control_wall.transform.localScale.x == 1f)
            {
                control_wall.transform.localScale = new Vector2(1.7f, 0.3f);
            }
            else
            {
                control_wall.transform.localScale = new Vector2(2.5f, 0.3f);
            }

            Destroy(other.gameObject);
        }

        else if(other.gameObject.name == "shorted_ball(Clone)")
        {
            if(bal.transform.localScale.x == 0.8f)
            {
                bal.transform.localScale = new Vector2(0.4f, 0.4f);
            }
            else
            {
                bal.transform.localScale = new Vector2(0.2f, 0.2f);
            }

            Destroy(other.gameObject);
        }

        else if(other.gameObject.name == "shortten_wall(Clone)")
        {
            if(control_wall.transform.localScale.x == 2.5f)
            {
                control_wall.transform.localScale = new Vector2(1.7f, 0.3f);
            }
            else
            {
                control_wall.transform.localScale = new Vector2(1f, 0.3f);
            }

            Destroy(other.gameObject);
        }
    }
}
