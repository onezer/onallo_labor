using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{

    public class BombAbility : Ability
    {
        public float range;
        public int damage;

        public float ThrowingDegree;

        GameObject CurrentBall;

        public static Vector3 CalculateThrow(Vector3 StartingPos, Vector3 targetPos, float ThrowingDegree)
        {
            float alpha = Mathf.Deg2Rad * ThrowingDegree;

            Vector3 directionvector = targetPos - StartingPos;
            Vector3 throwingvector = new Vector3(0f, 0f, 0f);
            float grav = Physics.gravity.magnitude;

            float v = Mathf.Sqrt((grav * directionvector.magnitude) / Mathf.Sin(2 * alpha));

            throwingvector.x = directionvector.normalized.x * Mathf.Cos(alpha) * v;
            throwingvector.z = directionvector.normalized.z * Mathf.Cos(alpha) * v;
            throwingvector.y = v * Mathf.Sin(alpha);

            return throwingvector;

        }

        public override void Activate()
        {
            

            CurrentBall = Instantiate(AbilityGameObj);
            CurrentBall.transform.position = transform.position;
            BombMechanics Mechanics = CurrentBall.GetComponent<BombMechanics>();

            Mechanics.damage = Mathf.RoundToInt(damage * AbilityPower);
            Mechanics.range = range;

            Vector3 ThrowingForce;
            ThrowingForce = CalculateThrow(transform.position, CursorPoint, ThrowingDegree);

            CurrentBall.GetComponent<Rigidbody>().AddForce(ThrowingForce, ForceMode.Impulse);
        }

    }
}