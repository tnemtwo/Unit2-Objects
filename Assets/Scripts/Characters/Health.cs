using UnityEngine;
using UnityEngine.Events;
public class Health
{
    public UnityEvent OnDied;
    private float healthValue;
    private Character myCharacter;

    public void DecreaseHealth(float damageParameter)
    {
        healthValue -= damageParameter;
        Debug.Log("Health decreasing to: " + healthValue);
        //UPDATE THE UI
        //CHECK IF IS DEAD
        if(IsDead())
        {
            OnDied.Invoke();

        }
    }

    public void IncreaseHealth(float increaseParameter)
    {
        healthValue += increaseParameter;
    }


    public bool IsDead()
    {
        return healthValue <= 0;
    }

    public float GetHealthValue()
    {
        return healthValue;
    }

    public Health()
    {
        healthValue = 100;
        OnDied = new UnityEvent();
    }

    public Health(float initialHealth)
    {
        healthValue = initialHealth;
        OnDied = new UnityEvent();

    }




}