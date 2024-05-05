using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkills : MonoBehaviour
{
    
	public GameObject throwingRock;
	private int action;
	private bool isAttacking = false;
	
	// Start is called before the first frame update
    void Start()
    {
       
    }

	void Update()
	{
		CheckRockThrow();
	}
    
	
	// Update is called once per frame
    void CheckRockThrow()
    {
        action = Random.Range(0, 500);
		
		if (action == 1 && !isAttacking)
		{			
			isAttacking = true;
			this.GetComponent<Animator>().Play("Throw");
			Invoke("ThrowRock", 0.50f);						
		}
    }
	
	void ThrowRock()
	{		
		GameObject Rock = Instantiate(throwingRock);
		Invoke("EndThrowRock", 0.40f);				
	}
	
	void EndThrowRock()
	{
		isAttacking = false;
	}
}
