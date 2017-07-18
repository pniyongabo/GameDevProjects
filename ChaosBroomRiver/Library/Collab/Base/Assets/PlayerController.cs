using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    Vector3 moveDirection;
    float speed = 50f;
    GameObject player;
    Rigidbody rb;
    Vector3 start = Vector3.zero;

    void Awake()
    {
        player = GameObject.Find("Player");
        moveDirection = player.transform.TransformDirection(start);
        rb = GetComponent<Rigidbody>();
        
    }

 
    void FixedUpdate()
    {
        CharacterController controller = GetComponent<CharacterController>();
        moveDirection = transform.TransformDirection(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection *= speed;

        //rb.AddForce(0, 0, 10);
        
        controller.Move(moveDirection * Time.deltaTime);
    }

    //public float speed;

    //private Rigidbody rb;

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    //void FixedUpdate()
    //{
    //    float moveHorizontal = Input.GetAxis("Horizontal");

    //    float x = GameObject.Find("Player").transform.position.x;
    //    float y = GameObject.Find("Player").transform.position.y;

    //    Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

    //    rb.AddForce(movement * speed);

    //    rb.rotation = Quaternion.LookRotation(new Vector3(x, y, 0));
}
