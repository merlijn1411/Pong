using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 velocity = new Vector3(1, 2, 0);
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.0f);
        
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += velocity  * speed * Time.deltaTime;  
    }
}
