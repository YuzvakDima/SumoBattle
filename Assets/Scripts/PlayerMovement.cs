using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 100f;
    public float sidewayForce = 50f;
    public float jumpForce = 1f;
    private bool isGrounded;
    public Vector3 jump;
    public GameObject gameover;
    public GameObject restart;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0f, 2f, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0 ,forwardForce * Time.deltaTime);   
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }

        if (Input.GetKey ("d"))
        {
            rb.AddForce(sidewayForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("space"))
        {
            rb.AddForce(0, 200 * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (gameObject.transform.position.y < -3)
            GameOver();
    }

    private void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void GameOver()
    {
        Destroy(gameObject);
        FindObjectOfType<AudioManager>().Play("Death");
        Debug.Log("GameOver");
        gameover.SetActive(true);
        restart.SetActive(true);

    }
}
