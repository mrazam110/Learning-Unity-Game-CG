using UnityEngine;
using System.Collections;

public class obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity =  new Vector2(-4,0);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (this.gameObject.tag == "Fire") {
            Destroy(other.gameObject);
        }
    }
}
