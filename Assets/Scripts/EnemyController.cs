using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    private void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        if (dir.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        float distance = Mathf.Abs(player.transform.position.x - transform.position.x);
        if (distance < 3f)
        {
            Debug.Log("enemy attack");  
            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 6f * Time.deltaTime);
        }
    }
}
