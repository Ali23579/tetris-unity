using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_gameobject : MonoBehaviour
{
    public GameObject extend_ball, extend_wall, short_ball, short_wall;
    private Rigidbody2D rb,eb;
    private float time = 5;
    public List<GameObject> liste;
    void Start()
    {
        eb = extend_ball.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();

        liste.Add(extend_ball);
        liste.Add(extend_wall);
        liste.Add(short_ball);
        liste.Add(short_wall);
    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time < 0)
        {
            Vector2 random_location = new Vector2(Random.Range(-1.85f,1.85f),Random.Range(-1.10f,3f));
            eb.transform.position = random_location;
            time = 5;

            if (liste.Count > 0)
            {
                int index = Random.Range(0, liste.Count);
                GameObject selectedObject = liste[index]; 
                
                if (selectedObject.name == "extend_wall")
                {
                    GameObject clon_extend_wall = Instantiate(extend_wall,random_location, Quaternion.identity);
                    rb.velocity = new Vector2(0,-5);
                }

                else if (selectedObject.name == "shortten_wall")
                {
                    GameObject clon_short_wall = Instantiate(short_wall, random_location, Quaternion.identity);
                    rb.velocity = new Vector2(0,-5);
                }

                else if (selectedObject.name == "extend_ball")
                {
                    GameObject clon_extend_ball = Instantiate(extend_ball, random_location, Quaternion.identity);
                    rb.velocity = new Vector2(0,-5);
                }

                else if (selectedObject.name == "shorted_ball")
                {
                    GameObject clon_short_ball = Instantiate(short_ball, random_location, Quaternion.identity);
                    rb.velocity = new Vector2(0,-5);
                }
            }
        }
    }
}
