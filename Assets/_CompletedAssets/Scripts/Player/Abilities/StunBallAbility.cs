using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{

    public class StunBallAbility : Ability
    {

        GameObject CurrentBall;

        public float MovSpeed;
        public float LifeSpan;
        public float Radius;
        public int Speed;
        public float Height;

        Vector3 Direction;
        public override void Activate()
        {
            Direction = (CursorPoint - transform.position).normalized;

            CurrentBall = Instantiate(AbilityGameObj);
            CurrentBall.transform.position = transform.position;
            CurrentBall.GetComponent<StunBallMove>().Direction = Direction;
            CurrentBall.GetComponent<StunBallMove>().Movspeed = MovSpeed;
            CurrentBall.GetComponent<StunBallMove>().LifeSpan = LifeSpan;
            CurrentBall.GetComponent<StunBallMove>().Speed = Speed;
            CurrentBall.GetComponent<StunBallMove>().Height = Height;
        }


    }
}