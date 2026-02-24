using UnityEngine.UI;
using UnityEngine;

public class MeteorBehavior : MonoBehaviour
{

    private Vector3 targetPos;
    private Vector3 centralPos;
    [SerializeField] float speed;
    private Rigidbody rb;
    public int damageDealt;
    private GameObject Player;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Start()
    {
        if (Player != null)
        {
            targetPos = (new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z) - transform.position).normalized;
            Debug.Log("Meteor target Position : " + targetPos);
            rb.AddForce(targetPos * speed, ForceMode.Impulse);
        }
        else
        {
            centralPos = (new Vector3(0f, 2, 0f) - transform.position).normalized;
            rb.AddForce(centralPos * speed, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth playerHealthScript = collision.gameObject.GetComponent<PlayerHealth>();

            playerHealthScript.TakeDamage(damageDealt);

            Destroy(gameObject);
        }


    }


}
