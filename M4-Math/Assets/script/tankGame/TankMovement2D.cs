using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement2D : MonoBehaviour
{
    public Vector3 velocity = new Vector3(0, 1, 0);
    public float speed = 1.0f;
    Vector2 minView;
    Vector2 maxView;

    void Start()
    {
        minView = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxView = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void Update()
    {
        BorderControl();
        transform.position += velocity * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localEulerAngles += new Vector3(0, 0, -90);
            velocity = Quaternion.Euler(0, 0, -90) * velocity;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localEulerAngles += new Vector3(0, 0, 90);
            velocity = Quaternion.Euler(0, 0, 90) * velocity;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            speed++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            speed--;
        }

    }

    public void BorderControl()
    {
        if (transform.position.y > maxView.y)
        {
            transform.position = new Vector3(transform.position.x, minView.y, 0);
        }
        if (transform.position.y < minView.y)
        {
            transform.position = new Vector3(transform.position.x, maxView.y, 0);
        }
        if(transform.position.x > maxView.x)
        {
            transform.position = new Vector3(transform.position.y, minView.x, 0);
        }
        if (transform.position.x < minView.x)
        {
            transform.position = new Vector3(transform.position.y, maxView.x, 0);
        }

    }
}
