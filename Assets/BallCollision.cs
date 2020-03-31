using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public int speed = 30;
    public Rigidbody2D sesuatu;
    // Start is called before the first frame update
    void Start()
    {
        sesuatu.velocity = new Vector2(-1,-1) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.name == "TembokKanan" || other.collider.name == "TembokKiri"){
            StartCoroutine(jeda());
            //GetComponent<Rigidbody2D>().velocity = new Vector2 (-1,-1) * 30;
        }
    }

    IEnumerator jeda(){
        sesuatu.velocity = Vector2.zero;
        sesuatu.GetComponent<Transform>().position = Vector2.zero;
        yield return new WaitForSeconds(1);
        sesuatu.velocity = new Vector2(-1,-1) * speed;
    }
}
