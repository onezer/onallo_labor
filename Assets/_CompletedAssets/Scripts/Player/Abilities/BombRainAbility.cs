using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class BombRainAbility : Ability
    {

        BombRain Mechanics;
        GameObject CurrentRain;

        public int BombNumber;
        public float TimeBetweenBombs;
        public float Radius;
        public int Damage;
        public float ExplosionRange;

        public override void Activate()
        {
            CurrentRain = Instantiate(AbilityGameObj);
            CurrentRain.transform.position = new Vector3(CursorPoint.x, 1f, CursorPoint.z);
            CurrentRain.transform.rotation = new Quaternion(0.7f, 0.3f, -0.3f, 0.7f);
            Debug.Log(CurrentRain.transform.rotation);
            Mechanics = CurrentRain.GetComponent<BombRain>();
            Mechanics.BombNumber = BombNumber;
            Mechanics.TimeBetweenBombs = TimeBetweenBombs;
            Mechanics.Radius = Radius;
            Mechanics.Damage = Damage;
            Mechanics.ExplosionRange = ExplosionRange;
        }

    }
}