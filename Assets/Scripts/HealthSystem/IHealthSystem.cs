public interface IHealthSystem    
{
    public float GetMaxHealth();

    public void SetMaxHelath(float number);

    public float GetCurrentHealth();

    public void SetCurrentHelath(float number);

    public void TakeDamage(float number);
}
