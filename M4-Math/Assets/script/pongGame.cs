using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class pongGame : MonoBehaviour
{
    public GameObject pongBall;
    public Vector3 velocity = new Vector3(-1, 2, 0);
    public Vector2 viewMax;
    public Vector2 viewMin;

    public GameObject PlayerA;
    public GameObject PlayerB;
    public float speed;

    RaycastHit2D hit;

    public TMP_Text ScoreboardA;
    public TMP_Text ScoreboardB;

    int scoreA = 0;
    int scoreB = 0;

    void Start()
    {
        ScoreboardA.text = scoreA.ToString();
        ScoreboardB.text = scoreB.ToString();

        viewMax = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        viewMin = Camera.main.ScreenToWorldPoint(Vector2.zero);

        Debug.Log(viewMax);
        Debug.Log(viewMin);



    }

    // Update is called once per frame
    void Update()
    {
        ScoreboardA.text = scoreA.ToString();
        ScoreboardB.text = scoreB.ToString();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerB.transform.position += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerB.transform.position += new Vector3(0, -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayerA.transform.position += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerA.transform.position += new Vector3(0, -1, 0);
        }



        
      
        pongBall.transform.position += velocity * speed * Time.deltaTime;
        hit = Physics2D.Raycast(pongBall.transform.position, new Vector3(velocity.x, 0, 0), 0.5f);
        Debug.DrawRay(pongBall.transform.position, new Vector3(velocity.x, 0, 0), Color.white);
        
        

        if (hit.collider != null)
        {
            Debug.Log("hit!!!");
            velocity = new Vector3(-velocity.x, velocity.y, 0);
        }
        
        


        if (pongBall.transform.position.y > viewMax.y - pongBall.transform.localScale.x / 2)
        {
            velocity = new Vector3(velocity.x, -velocity.y, 0);
        }

        if (pongBall.transform.position.y < viewMin.y + pongBall.transform.localScale.x / 2)
        {
            velocity = new Vector3(velocity.x, -velocity.y, 0);
        }
        if (pongBall.transform.position.x > viewMax.x + pongBall.transform.localScale.x / 2)
        {
            pongBall.transform.position = Vector3.zero;
            scoreA++;
        }
        if (pongBall.transform.position.x < viewMin.x - pongBall.transform.localScale.x / 2)
        {
            pongBall.transform.position = Vector3.zero;
            scoreB++;
        }
        
    }
}
