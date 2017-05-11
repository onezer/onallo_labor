using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{

    public class SlowTrapAbility : Ability
    {
        public float SlowPercent;
        public float SlowDuration;

        public float LifeSpan;

        GameObject CurrentTrap;

        SlowTrapMechanics Mechanics;

        public override void Activate()
        {
            
            CurrentTrap = Instantiate(AbilityGameObj);
            CurrentTrap.transform.position = transform.position;
            Mechanics = CurrentTrap.GetComponent<SlowTrapMechanics>();
            Mechanics.SlowPercent = SlowPercent;
            Mechanics.SlowDuration = SlowDuration;
            Mechanics.LifeSpan = LifeSpan;
        }
    }
}