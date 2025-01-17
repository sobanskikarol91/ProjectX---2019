﻿using System;
using UnityEngine;
using System.Linq;

public class DamageOnRaycastHit : Damagable
{
    public void CastRay(Vector3 origin, Vector3 direction, float length)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, direction, length);

        if (hits.Length > 0)
            Array.ForEach(hits, h => CheckHitObject(h, damageObjects));
    }

    private void CheckHitObject(RaycastHit2D hit, ObjectType[] damagable)
    {
        InteractiveObject interactive = hit.collider.gameObject.GetComponent<InteractiveObject>();

        if (!interactive) return;
        else if (!damagable.Contains(interactive.Type)) return;
        interactive.GetComponent<HealthAbility>()?.DoDamage(Damage);
    }
}