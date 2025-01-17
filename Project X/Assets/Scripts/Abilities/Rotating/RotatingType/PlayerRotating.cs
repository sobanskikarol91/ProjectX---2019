﻿using UnityEngine;

[CreateAssetMenu(fileName = "PlayerRotation", menuName = "Rotating/Player")]
public class PlayerRotating : RotateType
{
    private PlayerInput input;

    public override void Init(RotatingAbility ability)
    {
        base.Init(ability);
        input = GameManager.instance.Platform.GetPlayerInputDependsOnPlatform();
    }

    public override void Execute()
    {
        Vector2 direction = input.Rotating.Direction;
        SetNewRotation(direction);
    }
}