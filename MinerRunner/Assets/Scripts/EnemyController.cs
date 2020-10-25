using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public BoxCollider2D batRb;
    // Start is called before the first frame update
    void Start()
    {
        batRb = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * 4, Camera.main.transform);

        if(transform.position.x < -17.5f){
            ResetPosition();
        }
    }

    void ResetPosition(){
        int randX = Random.Range(8,15);
        int randY = Random.Range(-2,2);

        transform.position = new Vector3(randX,randY, -8);
    }
}
