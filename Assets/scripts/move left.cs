using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveleft : MonoBehaviour

{
    public float speed = 30;
    private PlayerController PlayerControllerScript;
    private float leftbound = -15;

    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GameObject.Find("player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControllerScript.gameover == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed );
        }

        if (transform.position.x < leftbound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }


    }

}
