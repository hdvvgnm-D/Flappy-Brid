using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BridScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logicScript;
    public bool IsBridAlive = true;
    public AudioSource SpaceAudio;
    // Start is called before the first frame update
    void Start()
    {
        //logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsBridAlive == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            SpaceAudio.Play();
        }
        if((transform.position.y<=-13.5|| transform.position.y>=14)&& IsBridAlive==true)
        {
            logicScript.GameOverWindow();
            IsBridAlive = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.GameOverWindow();
        IsBridAlive = false;
    }
}
