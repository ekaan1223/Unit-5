using UnityEngine;
using UnityEngine.InputSystem;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gameManager;

    public int pointValue;
    public ParticleSystem explosionParticle;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        rb.AddForce(Vector3.up * Random.Range(12 ,16), ForceMode.Impulse); //throw
       
        rb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);  //spin
        
        // AddTorque(float x, float y, float z, ForceMode mode);

        transform.position = new Vector3(Random.Range(-4 ,4), -2, 0); //spawn position
        // -4 , 4 = x     -2 = y     0 = z
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Clicked");

            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 1.0f);

            if(Physics.Raycast(ray , out RaycastHit hit))
            {

                if (hit.transform == transform)
                {
                    if (gameManager.isGameActive == true)
                    {
                        Destroy(gameObject);
                        gameManager.UpdateScore(pointValue);
                        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
                    }
                }
               
                
            }

        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("destroyZone"))
        {
            Destroy(gameObject);
            if (!gameObject.CompareTag("bad"))
            {
                gameManager.GameOver();
                
            }
            
        }
    }
}
