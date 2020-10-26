public class Player : Entity
{
    public PlayerHealthDisplay healthDisplay;

    public void Start()
    {
        healthDisplay.SetDisplay(Health, MaxHealth);
    }

    public override void SetMaxHealth(int newMax)
    {
        base.SetMaxHealth(newMax);
        healthDisplay.SetDisplay(Health, MaxHealth);
    }

    public override void OnDamaged(int damage)
    {
        base.OnDamaged(damage);
        healthDisplay.SetDisplay(Health, MaxHealth);    
    }
}
