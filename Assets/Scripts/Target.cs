using UnityEngine;
using UnityEngine.InputSystem;

public class Target : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

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
            Debug.DrawRay(ray.origin , ray.direction * 100f, Color.red, 2.0f);

        }
    }
}
