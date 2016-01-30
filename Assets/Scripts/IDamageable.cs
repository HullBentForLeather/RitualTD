using UnityEngine;
using System.Collections;

public interface IDamageable
{
    void DoDamage(int amount);

    bool IsAlive();

    Vector3 GetPosition();
}
