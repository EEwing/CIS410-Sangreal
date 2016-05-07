using UnityEngine.UI;
using System.Collections;

public abstract class Damageable : Entity {

    public int maxHealth;
    public int Health;
    public Text healthText;

    public void Awake() {
        Health = maxHealth;
        UpdateTextBox();
    }

    public void Damage(int damage) {
        Health -= damage;
        UpdateTextBox();
        CheckForDeath();
    }

    private void UpdateTextBox() {
        if (healthText == null) {
            return;
        }

        healthText.text = "Health: " + Health;
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
