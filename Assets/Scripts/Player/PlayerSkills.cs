using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
	public GameObject bullet;
	public float AttackSpeed;	
	
	void Start()
	{
		AttackSpeed = this.GetComponent<PlayerStats>().AttackSpeed;
	}
	
	
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && this.GetComponent<PlayerMovement>().isAttacking == false)
        {	
            this.GetComponent<PlayerMovement>().isAttacking = true;
			this.GetComponent<Animator>().SetFloat("AttackSpeed", AttackSpeed);			
			this.GetComponent<Animator>().Play("Attack");
			Invoke("Attack", 1/AttackSpeed);
        }
    }
	
	void Attack()
	{			
		GameObject Bullet = Instantiate(bullet);
		//Bullet.transform.position = new Vector3(this.transform.position.x, this.transform.position.y  + 6.1f , this.transform.position.z);
		
		Invoke("EndAttack", 0.1f);
	}
	
	void EndAttack()
	{
		this.GetComponent<PlayerMovement>().isAttacking = false;
	}
}
