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