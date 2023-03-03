using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 25f;
    private Vector3 _moveDirection = Vector3.zero;
    public float jumpSpeed = 10f;
    CharacterController mycharacter;
    float ySpeed;


    private void Awake()
    {
        mycharacter = GetComponent<CharacterController>();
    }
    private void Update()
    {
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _moveDirection = transform.TransformDirection(_moveDirection);
   
        _moveDirection *= _movementSpeed;
 
        
        ySpeed += Physics.gravity.y * Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            ySpeed = jumpSpeed;
        }
        
       _moveDirection.y = ySpeed;
        _moveDirection.y -= 2;
        mycharacter.Move(_moveDirection * Time.deltaTime);
    }
}
