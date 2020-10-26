using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    public GameObject[] gems;

    private float gameTime;
    private bool spawn;
    
    public Transform spawnLocation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > 10) {
         spawn = true;
        }

        if(spawn){
            SpawnGem();
            spawn = false;
            gameTime = 0;
        }

        

        
    }

    private void FixedUpdate() {
        
        for(int i = 0; i < gems.Length; i++){
            gems[i].transform.Translate(Vector3.left * Time.deltaTime * 2, Camera.main.transform);
        }
    }

    private void SpawnGem(){
         Instantiate (gems[Random.Range(0,gems.Length)], spawnLocation.position, spawnLocation.rotation);
    }
}
