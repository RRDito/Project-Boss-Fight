using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{	
    public Transform Center;	//the enemy transform will be the center of the radius
	
	private float angle;     //angle related to the initial position
    private float moveSpeed; //speed at which the angle changes
    private float jumpPower;
	private Vector3 change;  //this vector calcs the change from the center to the new position of the player  
	private Vector3 TheMove; //this vector will be the sum of all moves
	
	
	public bool isJumpingUp;
	public bool isJumpingDown;
	public bool isAttacking; 	
	
	
	private float jumpHeight;
	private float radius;    
    private float Ez;
    private float Ex;
	private CharacterController controller;
	
    void OnEnable()
    {  
        change = new Vector3();        
		controller = this.GetComponent<CharacterController>();
		
		Ez = Center.position.z;
	    Ex = Center.position.x;
		
		radius = 150.0f;		
		angle = 0;		

        AngularMovement(); //this sets the starting position		
    }

	void Start()
	{
		moveSpeed = this.GetComponent<PlayerStats>().MoveSpeed; 
		jumpPower = this.GetComponent<PlayerStats>().JumpPower;
	}
    
	void AngularMovement()
	{
		change.Set( Mathf.Cos(angle* Mathf.Deg2Rad) * radius, 0, Mathf.Sin(angle* Mathf.Deg2Rad) * radius);
		//this is the change that needs to be applied to the center to find the new player position
		Vector3 nowpos = this.transform.position;
		Vector3 nextpos = new Vector3(Center.position.x + change.x, transform.position.y, Center.position.z + change.z);
        
		TheMove += nextpos-nowpos;		
        		
	}
	
	public bool isJumping()
	{
		if (isJumpingUp || isJumpingDown)
		{
			return true;
		}
		else return false;
	}
	
	
    void Update()
    {	
        if (angle>=360.0f || angle <= -360.0f){ angle = 0;} 
 		TheMove = Vector3.zero;		
		
		//Jump and Gravity
		if (Input.GetKey(KeyCode.UpArrow) && !isJumpingUp && controller.isGrounded)  
        {	            
			isJumpingUp = true;
			jumpHeight = transform.position.y + jumpPower;            
            this.GetComponent<Animator>().Play("JumpStart");			
		}		
		else if (isJumpingUp && (transform.position.y < jumpHeight) )
		{
			TheMove += 50*Vector3.up*Time.deltaTime;
						
		}
		else if (isJumpingUp && (transform.position.y >= jumpHeight))
		{	
            isJumpingUp = false;
		    isJumpingDown = true;               
			
			this.GetComponent<Animator>().Play("JumpDown");
		}
		else if (isJumpingDown && controller.isGrounded)  
		{			
		    isJumpingDown = false;			
			
			this.GetComponent<Animator>().Play("JumpEnd");
		}	     			
		else   //also happens  if (isJumpingDown && !controller.isGrounded)
		{
			TheMove += 5*Physics.gravity*Time.deltaTime;			
		}		
		
		
		
		
		//Left and Right Move
        if ( ( !isAttacking || isJumping() ) && Input.GetKey(KeyCode.LeftArrow))
        {			
			angle -= moveSpeed*Time.deltaTime; //check if this works independent of framerate for webgl build
			
			AngularMovement();
			
			this.GetComponent<Animator>().SetBool("isLeftPressed", true);            		
        }
        else if ( ( !isAttacking || isJumping() ) && Input.GetKey(KeyCode.RightArrow))
        {			
			angle += moveSpeed*Time.deltaTime;
            
			AngularMovement();
			
			this.GetComponent<Animator>().SetBool("isRightPressed", true);			
		}
		else
			{
				this.GetComponent<Animator>().SetBool("isLeftPressed", false);
				this.GetComponent<Animator>().SetBool("isRightPressed", false);				
			}
		
		this.transform.LookAt(Center);
		 
		
		controller.Move(TheMove);
    }
}
