using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CatMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;

    public float speed = 12f;

    public float gravity = -9.9f;

    public float jumpHeight = 5f;

    public Transform groundCheck;
    public float groundDistance =0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded  = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        
        if(Input.GetButton("Jump")) {
        if((controller.isGrounded)){
            velocity.y =Mathf.Sqrt(jumpHeight * -2f* gravity);

          }
 }





         velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
      
    }





            void OnControllerColliderHit (ControllerColliderHit hit){

        if(hit.gameObject.tag == "Enemy"){
            Debug.Log("Respawn");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
} 
