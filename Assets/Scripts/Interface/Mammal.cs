using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mammal : Animal
{
    public override void Eat()
    {
        
    }

    public override void Move()
    {

    }
}

public class Platypus : Mammal, ILayEgg
{
    public void LayEgg()
    {
        
    }
}

public class Dog : Mammal
{

}


