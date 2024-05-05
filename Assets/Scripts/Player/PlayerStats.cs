using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int ATK;
	public int HP;
	public float MoveSpeed;
	public float JumpPower;
	public float AttackSpeed;
	
	// Start is called before the first frame update
    void Awake()
    {
        HP = 3;
		ATK = 1;
		MoveSpeed = 10.0f;
		JumpPower = 30.0f;
		AttackSpeed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
		{
			//Do Something
		}
    }
}
