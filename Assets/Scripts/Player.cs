using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        
         if(!Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * -2);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= 3.0f)
        {
            thisAnimation.Play();
            rb.velocity = Vector3.up * 5;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacles")
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Score")
        {
            GameManager.thisManager.UpdateScore(1);
        }
    }
}
