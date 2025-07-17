using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float range;
    float startingY;
    float dir = 1f;
    
    // Start is called before the first frame update
    
    void Start()
    {
        startingY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * dir * Time.deltaTime); 
        if(transform.position.y < startingY || transform.position.y > startingY + range)
        {
            dir *= -1f;
        }
    }
}
