using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DamageTypes;
public class Bleed : Buff
{

    // Uses Most recent applier
    int level;
    int bleedAmount = 5;

    public Bleed(int currentLevel) {

        level = currentLevel;

        set_ticks(3);
        set_ticks_per_activation(10);
    }

    
    public override bool ApplyBuff(Damageable target) {

        target.TakeDamage(level * bleedAmount * get_ticks(), DamageType.True);

        return tick_down();
    }

}
