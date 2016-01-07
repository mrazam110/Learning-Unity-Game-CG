using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour {

    private Vector2 jumpForce = new Vector2(0, 300);
    public GameObject[] Islands;
    public GameObject[] jewel;
    public GameObject Fire;
    public Text ScoreText;
    private int score = 0;
    public GameObject EndMenu;

    public GameObject Sun;

	void Start () {
       // Islands = new GameObject[3];
        Time.timeScale = 1;
        InvokeRepeating("CreateObstacle", 1f, 2.5f);
        EndMenu.SetActive(false);
    }

    void CreateObstacle()
    {
        int i=1;
        i = Random.Range(0, 2);
        var instantiatedIsland = Instantiate(Islands[i]);
        instantiatedIsland.transform.position = new Vector2(instantiatedIsland.transform.position.x+10, -0.7f);
        ;
        if (i <= 2)
        {
            var instantiatedJewel = Instantiate(jewel[i]);
            instantiatedJewel.transform.position = instantiatedIsland.transform.position + new Vector3(1,0,0);

        }
        if (i >= 1) 
        {
            Instantiate(Fire);
            Fire.transform.position = instantiatedIsland.transform.position;

        }
    }

	
	
	// Update is called once per frame
	void Update () {
        ScoreText.text = "Score: " + score.ToString();

        Sun.transform.Rotate(new Vector3(0, 0, 0.5f));

        if(Input.GetMouseButton(0))
        //if (Input.GetKeyDown(KeyCode.Space)) 
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(jumpForce);
        }
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        //if (screenPosition.y > Screen.height || screenPosition.y < 0)
        if (transform.position.y > 25 || transform.position.y < -15) 
        {
            Die();
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Fire")
        {
            Die();
        }
        else if (other.gameObject.tag == "Coin") 
        {
            score += 5;
            Destroy(other.gameObject);
            
        }
    }

    void Die() 
    {
        EndMenu.SetActive(true);
        Time.timeScale = 0;
    }

    
}
