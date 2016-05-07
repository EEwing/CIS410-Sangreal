using UnityEngine;
using System.Collections;

public abstract class Damageable : Entity {

    public int Health;

    public void Damage(int damage) {
        Health -= damage;
        CheckForDeath();
    }

    public bool CheckForDeath() {
        if(Health <= 0) {
            OnDeath();
            return true;
        }
        return false;
    }

    protected virtual void OnDeath() {

    }

}
