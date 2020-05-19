using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class SawScript : MonoBehaviour {

    public float sawSpeed = 100f;
    public float repelForce = 10;
    
    
    // Use this for initialization
    void Start() {      
    }

    

    // Update is called once per frame
    void Update() {
        transform.Rotate(transform.forward, sawSpeed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            /*var forceVec = (other.gameObject.transform.position - transform.position).normalized * repelForce;
            var playerBody = other.gameObject.GetComponent<Rigidbody2D>();
            //playerBody.AddForce(forceVec);

            playerBody.AddForce(new Vector2(0, -100));*/

            //other.gameObject.GetComponent<PlatformerCharacter2D>().Move(0f, false, true);

        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10000, 0));

        var forceVec = (coll.gameObject.transform.position - transform.position).normalized * repelForce;
        var playerBody = coll.gameObject.GetComponent<Rigidbody2D>();
        playerBody.AddForce(new Vector2(forceVec.x, 0));

        //other.gameObject.GetComponent<PlatformerCharacter2D>().Move(0f, false, true);
    }

    
}
