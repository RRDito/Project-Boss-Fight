using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    public GameObject Player;
	
	private float rotateSpeed = 1.0f;	
	
	// Start is called before the first frame update
    void Start()
    {
        
    }
	
	void Update()
	{
		LookAtPlayer();
	}

    void LookAtPlayer()
    {   
		
		Quaternion targetRotation = Quaternion.LookRotation(Player.transform.position - this.transform.position);
       
		if (targetRotation != this.transform.rotation)
		{
			this.GetComponent<Animator>().SetBool("isRotating", true);
			// Smoothly rotate towards the target point.
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
		}
		else
		{
			this.GetComponent<Animator>().SetBool("isRotating", false);
		}
		
    }
}
