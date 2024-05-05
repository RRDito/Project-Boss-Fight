using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrown : MonoBehaviour
{    
	private GameObject Battle;
	private GameObject Player;
	private GameObject Enemy;

	
	private Vector3 startPoint;
    private Vector3 endPoint;
    private	float totalDistance;
	private float startTime;
    
	private float speed;
	
	
	
	
	void Start()
	{	
        Battle = GameObject.FindWithTag("battle");
		Enemy = Battle.GetComponent<BattleCoordinator>().Enemy;		 
        Player = Battle.GetComponent<BattleCoordinator>().Player;
		
		speed = Enemy.GetComponent<EnemyStats>().RockSpeed;
		
		//starts the rock over the enemy's head
		transform.position = new Vector3(Enemy.transform.position.x , Enemy.transform.position.y  + 55.0f , Enemy.transform.position.z);
		
		startPoint = transform.position;
		endPoint = Player.transform.position;
		startTime = Time.time;
		totalDistance = Vector3.Distance(startPoint, endPoint);
		
	}
	
    // Update is called once per frame
    void Update()
    {       
		float timePassed = Time.time - startTime;
		float distanceCovered = timePassed * speed;
		float journeyCompleted = distanceCovered/totalDistance;		
		
		
		// Calculate the direction to the end point
        Vector3 direction = endPoint - startPoint;

        // Normalize the direction
        direction = direction.normalized;
		
		// Move the object towards the end point
        transform.position += direction * speed * Time.deltaTime;

		//this adds the parabole effect by increasing the y axis at the beginning of the travel time
		//the increase is compensated towards the end, but not fully so it doesnt go directly to the ground
		transform.Translate(0, 0.15f - 0.29f*journeyCompleted, 0);
		
		if (journeyCompleted > 1.5f)
		{
			Destroy(gameObject);
		}
	}		
	
	
	void OnCollisionEnter(Collision collision)
	{
		//Debug.Log("Do something here");
		if (collision.gameObject.tag == "player")
		{
			//Debug.Log("Hit");			
			Battle.GetComponent<BattleCoordinator>().EnemyNormalAttack();
			Destroy(gameObject);
		}		
	}
	
}
