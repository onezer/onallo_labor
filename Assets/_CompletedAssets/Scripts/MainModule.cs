using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public interface MainModule
    {

        int GetHealth();
        Vector3 GetPosition();
        Vector3 GetMovement();

        void Stun(float Time);
        void Slow(float Percent, float Duration);

        void TakeDamage(int Damage);
        void TakeHealing(int Heal);
    }
}