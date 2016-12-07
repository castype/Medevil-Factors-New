using UnityEngine;
using System.Collections;
using System;

public class RangedState : IEnemyState 
{
	private Enemy enemy;

	private float shootArrowTimer;
	private float shootArrowCoolDown = 3;
	private bool canShootArrow = true;

	public void Enter(Enemy enemy)
	{
		this.enemy = enemy;
	}

	public void Execute()
	{
		ShootArrow ();
		if (enemy.InMeleeRange)
		{
			enemy.ChangeState (new MeleeState ());
		}
		else if (enemy.Target != null)
		{
			enemy.Move ();
		} 
		else 
		{
			enemy.ChangeState (new IdleState ());
		}
	}

	public void Exit()
	{

	}

	public void OnTriggerEnter(Collider2D other)
	{

	}

	private void ShootArrow()
	{
		shootArrowTimer += Time.deltaTime;

		if (shootArrowTimer >= shootArrowCoolDown) 
		{
			canShootArrow = true;
			shootArrowTimer = 0;
		}

		if (canShootArrow)
		{
			canShootArrow = false;
			enemy.MyAnimator.SetTrigger ("shootArrow");
		}
	}
}