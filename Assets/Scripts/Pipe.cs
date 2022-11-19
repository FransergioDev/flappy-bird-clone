using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] float speed = -0.2f;
    [SerializeField] float leftBoard = 0f;
    //private Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        // transform = GetComponent<Transform>();
        leftBoard = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 3f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime,0,0);
        if (transform.position.x <= leftBoard) 
        {
           Destroy(gameObject);
        }
    }
}
