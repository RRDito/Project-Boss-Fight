using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{    
	private GameObject Battle;
	private GameObject Player;
	private GameObject Enemy;
	
	Vector3 direction;
	
	void Start()
	{	
        Battle = GameObject.FindWithTag("battle");
		Enemy = Battle.GetComponent<BattleCoordinator>().Enemy;		 
        Player = Battle.GetComponent<BattleCoordinator>().Player;
		
		direction = Enemy.transform.position + Vector3.up*10 - Player.transform.position;        
        Vector3 temp = new Vector3();
		temp = Player.transform.position + direction.normalized*12;		
		this.transform.position = new Vector3(temp.x, Player.transform.position.y + 6.1f , temp.z);
	}
	
    // Update is called once per frame
    void Update()
    {
        transform.position += direction.normalized * 80f * Time.deltaTime;
        
	}
	
	void OnCollisionEnter(Collision collision)
	{
		//Debug.Log("Do something here");
		if (collision.gameObject.tag == "enemy")
		{
			Battle.GetComponent<BattleCoordinator>().PlayerNormalAttack();			
			Destroy(gameObject);
		}		
	}
	
}
