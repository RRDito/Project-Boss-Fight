using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public GameObject Enemy;
	public GameObject Player;
	
	public Vector3 temp;
	
	private float ztemp, xtemp;	
	
		
	public void AdjustView()
    {
		Vector3 direction = new Vector3();
		direction = Player.transform.position - Enemy.transform.position;
        //Vector3.Normalize(direction);
        temp = Player.transform.position + direction.normalized*12;		
		this.transform.position = new Vector3(temp.x, Player.transform.position.y + 6.1f , temp.z);
	}	
		
	public void Update()
	{
		AdjustView();
		this.transform.LookAt(Enemy.transform);		
	}    	
}
