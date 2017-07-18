using UnityEngine;
using UnityEngine.SceneManagement;
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
		if (player.transform.position.y < -5f) {
			SceneManager.LoadScene("ChaosBroomRiver");
		}
    }
		

}
