using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
  private CharacterController controller;
  public Vector3 playerVelocity;
  private bool IsGrounded;
  public float gravity = -9.8f;
  public float speed = 5f;
  public float jumpheight = 3f;
  void Start()
  {
    controller = GetComponent<CharacterController>();
  }

  void Update()
  {
    IsGrounded = controller.isGrounded;
  }
  //recieve the input for the inputmanager and apply it to our character controller
  public void ProcessMove(Vector2 input)
  {
    Vector3 moveDirection = Vector3.zero;
    moveDirection.x = input.x;
    moveDirection.z = input.y;
    controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
    playerVelocity.y += gravity * Time.deltaTime;
    if (IsGrounded && playerVelocity.y < 0)
      playerVelocity.y = -2f;
    controller.Move(playerVelocity * Time.deltaTime);
    

  }
  public void jump()
  {
    if (IsGrounded)
    {
      playerVelocity.y = Mathf.Sqrt(jumpheight * -3f * gravity);
    }
      
    }
}
