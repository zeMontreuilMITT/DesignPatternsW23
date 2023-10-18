// initialize a coffee and add two espresso
Beverage coffee = new Coffee();
// coffee variable refers to any concrete implementation of the Beverage abstract class

// get base values
Console.WriteLine(coffee.Description());
Console.WriteLine(coffee.Cost());

// then add decorators
// re-define the instance we want decorate as a decorator with a reference to what it is decorating
// coffee variable now refers to the new EspressoShot decorator
// the decorator gets a reference to the previous object (e.g. before it was redefined)
coffee = new EspressoShot(coffee);
coffee = new EspressoShot(coffee);

Console.WriteLine("AFTER DECORATOR");
Console.WriteLine(coffee.Description());
Console.WriteLine(coffee.Cost());



// ABSTRACT COMPONENT
public abstract class Beverage
{
    // use decorator pattern to gradually and repeatedly modify the virtual methods on the abstract component
    protected string _description = "Unspecified Beverage";
    public virtual string Description() 
    { 
        return _description;
    }


    protected double _cost;
    public virtual double Cost()
    {
        return _cost;
    }
}

// === CONCRETE COMPONENTS === 
public class Coffee : Beverage
{
    public Coffee()
    {
        _description = "Dark Roast Coffee";
        _cost = 2.00;
    }
}
public class Tea : Beverage
{
    public Tea()
    {
        _description = "Loose Leaf Tea";
        _cost = 1.75;
    }

}


// === ABSTRACT DECORATOR ===
// inherit from the abstract component
// it will override the abstract methods that it modifies
// it also needs a member referring to a component

// A decorator MUST INHERIT from the class that it is decorating
public abstract class CondimentDecorator: Beverage
{
    // the decorator class MUST have a reference to the object that it is decorating, which must be of the type of the abstract component
    public Beverage Beverage { get; set; }


    // the child classes of CondimentDecorator MUST override the "decorated" methods of the parent
    public abstract override double Cost();
    public abstract override string Description();

    public CondimentDecorator(Beverage beverage)
    {
        Beverage = beverage;
    }
}

// Concrete Decorator
public class EspressoShot: CondimentDecorator
{
    public EspressoShot(Beverage beverage): base(beverage)
    {
        _cost = 1.50;
        _description = "Espresso Shot";
    }

    public override string Description()
    {
        return $"{Beverage.Description()}, {_description}";
    }

    public override double Cost()
    {
        return Beverage.Cost() + _cost;
    }
}