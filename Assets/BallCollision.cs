using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    // public int speed = 30;
    public Rigidbody2D sesuatu;

    public GameObject masterScript;

    public Animator animtr;

    public AudioSource hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(0, 2) * 2 - 1; // nilai x bisa bernilai -1 atau 1
        int y = Random.Range(0, 2) * 2 - 1; // nilai y bisa bernilai -1 atau 1
        int speed = Random.Range(20, 26); // nilai speed antara 20 sampai 25
        sesuatu.velocity = new Vector2(x, y) * speed;
        sesuatu.GetComponent<Transform>().position = Vector2.zero;
        animtr.SetBool("IsMove", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(sesuatu.velocity.x > 0){ // bola bergerak ke kanan
            sesuatu.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        }else{
            sesuatu.GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);    
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.name == "TembokKanan" || other.collider.name == "TembokKiri"){
            masterScript.GetComponent<ScoringScript>().UpdateScore(other.collider.name);
            StartCoroutine(jeda()); // untuk pindah ke tengah
            //GetComponent<Rigidbody2D>().velocity = new Vector2 (-1,-1) * 30;
        }
        if(other.collider.tag=="Player"){
            hitEffect.Play();
    }

    IEnumerator jeda(){
        sesuatu.velocity = Vector2.zero; //menghentikan bola
        animtr.SetBool("IsMove", false); //mengubah animasi ke api berhenti
        sesuatu.GetComponent<Transform>().position = Vector2.zero; //mengubah posisi bola

        yield return new WaitForSeconds(1);

        int x = Random.Range(0, 2) * 2 - 1; // nilai x bisa bernilai -1 atau 1
        int y = Random.Range(0, 2) * 2 - 1; // nilai y bisa bernilai -1 atau 1
        int speed = Random.Range(20, 26); // nilai speed antara 20 sampai 25
        sesuatu.velocity = new Vector2(x, y) * speed; //mengatur kecepatan
        animtr.SetBool("IsMove", true); //mengubah animasi ke api bergerak
    }
}
}
