using UnityEngine;
using System.Collections;
using System;

public class PatrolState : IEnemyState 
{
	private Enemy enemy;
	private float patrolTimer;
	private float patrolDuration;

	public void Enter(Enemy enemy)
	{
		patrolDuration = UnityEngine.Random.Range (1, 10);
		this.enemy = enemy;
	}

	public void Execute()
	{
		Debug.Log ("Patrolling");
		Patrol ();

		enemy.Move ();

		if (enemy.Target != null && enemy.InShootArrowRange) 
		{
			enemy.ChangeState (new RangedState ());
		}
	}

	public void Exit()
	{

	}

	public void OnTriggerEnter(Collider2D other)
	{
		if (other.tag == "Arrow")
		{
			enemy.Target = Player_New.Instance.gameObject;
		}
	}

	private void Patrol()
	{
		patrolTimer += Time.deltaTime;

		if (patrolTimer >= patrolDuration) 
		{
			enemy.ChangeState (new IdleState ());
		}
	}

}