﻿using UnityEngine;


[CreateAssetMenu(fileName = "AIMoving", menuName = "Moving/FollowPlayer")]
public class FollowPlayer : MoveType
{
    private Player player;

    public override void Init(MovingAbility ability)
    {
        base.Init(ability);
        player = GameManager.instance.Player;
    }

    public override void Execute()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.position += (Vector3)(settings.Speed * direction * Time.deltaTime);
    }
}