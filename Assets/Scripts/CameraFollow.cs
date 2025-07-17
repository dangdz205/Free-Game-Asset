using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;// di theo obj nao
    [SerializeField] Vector3 offset;// khoang cach
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        target = FindAnyObjectByType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime); ;
    }
}
