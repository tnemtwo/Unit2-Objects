using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bird : Animal
{
    public override void Eat()
    {
        
    }

    public override void Move()
    {
        
    }
}

public class Eagle : Bird, IFly, ILayEgg
{
    public void Fly()
    {
        
    }

    public void LayEgg()
    {
        
    }
}

public class Penguin : Bird 
{

}

public class Chicken : Bird
{

}

