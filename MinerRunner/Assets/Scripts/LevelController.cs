using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public GameObject[] obstacles;
    
    
    // Start is called before the first frame update
    void Start()
    {
    
       
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 6; i++){
            obstacles[i].transform.Translate(Vector3.left * Time.deltaTime * 2, Camera.main.transform);

         if (obstacles[i].transform.position.x < -17.5){
              ResetPosition(i);
             }
        }

       
        
    }


    void ResetPosition(int i){

        int randX = Random.Range(8,15);
        int randY = Random.Range(-2,2);
        float widthA;
        float heightA;
        float widthB;
        float heightB;

        obstacles[i].transform.position = new Vector3(randX,randY, -8);

            for(int j = 0; j < obstacles.Length; j++){
                widthA = obstacles[i].GetComponent<BoxCollider2D>().bounds.size.x / 2;
                widthB = obstacles[j].GetComponent<BoxCollider2D>().bounds.size.x / 2;
                heightA = obstacles[i].GetComponent<BoxCollider2D>().bounds.size.y / 2;
                heightB = obstacles[j].GetComponent<BoxCollider2D>().bounds.size.y / 2;
                /*if (obstacles[g].transform.position.x + widthA < obstacles[j].transform.position.x + widthB &&
                 obstacles[g].transform.position.x - widthA > obstacles[j].transform.position.x - widthB &&
                  obstacles[g].transform.position.y + heightA < obstacles[j].transform.position.y + heightB &&
                   obstacles[g].transform.position.y - heightA > obstacles[j].transform.position.y - heightB){
                   Debug.Log("Hit");
                }*/

                    if (obstacles[i].transform.position.x - widthA < obstacles[j].transform.position.x + widthB &&
                    obstacles[i].transform.position.y + heightA > obstacles[j].transform.position.y - heightB &&
                    obstacles[i].transform.position.y - heightA < obstacles[j].transform.position.y + heightB &&
                    obstacles[i].transform.position.x + widthA > obstacles[j].transform.position.x - widthB){
                    Debug.Log(obstacles[j].name);
                    obstacles[i].transform.position += new Vector3(0, Random.Range(-2,2), 0);
                 }

                }
                

                
    }

        
}
