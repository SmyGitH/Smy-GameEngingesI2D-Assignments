using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public BoxCollider2D background;

    private float width;
    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<BoxCollider2D>();

        width = background.size.x;
        background.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector3.left * Time.deltaTime / 1.25f, Camera.main.transform);

        if (transform.position.x < -width - 7.5){
            Vector2 resetPosition = new Vector2(width * 2 + 20, 0 );
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }
}
