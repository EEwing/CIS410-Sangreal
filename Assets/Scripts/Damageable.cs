using UnityEngine;
using UnityEngine.UI;

public abstract class Damageable : Entity {

    public int MaxHealth;
    public int Health;

    public Image HealthBar;

    public void Awake() {
        Health = MaxHealth;
        UpdateTextBox();
    }

	public void Heal() {
		Health = MaxHealth;
		UpdateTextBox();
	}

    public void Damage(int damage) {
        Health -= damage;
        UpdateTextBox();
        CheckForDeath();
    }

    private void UpdateTextBox() {
        if(HealthBar != null) {
            float fillAmt = (float)Health / (float)MaxHealth;
            Debug.Log("Fill amount: " + fillAmt);
            HealthBar.fillAmount = fillAmt;
        }
    }

    public bool CheckForDeath() {
        if(Health <= 0) {
            OnDeath();
            return true;
        }
        return false;
    }

    protected virtual void OnDeath() {
		SpecialEffectsHelper.Instance.PowerUp (gameObject.transform.position);
        gameObject.SetActive(false);
    }

}
