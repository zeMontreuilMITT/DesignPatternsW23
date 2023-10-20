/*

At a Honda dealership, people can choose to buy a car from a
large selection of new cars.
► All new cars have properties like(Year, Model, Base Price, Color,
Body Type).
► After choosing the car they want, customers can select from a
wide range of upgrades.
► Upgrades include (Leather Seats, Ignition Button, Hybrid Engine),
each upgrade costs extra money.
► Create an OOP design to model this system.
► Add “Alloy Rims” to the set of upgrades. */

/* A better example of a problem where Strategy Pattern would be more appropriate:
 * Cars have a set number of different options for different parts 
 * For example, seats can be Synthetic, Leather, Faux Leather, etc.
 * The engine can be gasoline, hybrid, or electric
 * The ignition can be key, button, or remote
 * etc.
 * We would expect more options to be made available for each of these systems */



Vehicle accord = new Vehicle("Blue", "Sedan", "Accord", 40000M);

accord = new DecoratorSpecialEdition(accord);
accord = new DecoratorLeatherSeats(accord);

Console.WriteLine(accord.Model());
Console.WriteLine(accord.BasePrice());

// base class
public class Vehicle
{
    // which of these properties do we think MAY be altered by a decorator? Which of these could change during the lifetime of the object?
    private DateTime _year;
    public DateTime Year { get { return _year; } } // no set method -- will not change after instantiation

    private string _colour;
    public string Colour { get { return _colour; } set { _colour = value; } } // colour can change in the future, but isn't something we plan on "decorating"

    private string _bodyType;
    public string BodyType { get { return _bodyType; } }

    // decorated values
    // get methods are virtual so they can be modified virtual
    private string _model; // model might change based on what kind features are added
    public virtual string Model() 
    {
        return _model;  
    }
    private decimal _basePrice; // price will definitely change based on features
    public virtual decimal BasePrice()
    {
        return _basePrice;
    }

    


    public Vehicle()
    {

    }
    public Vehicle(string colour, string bodyType, string model, decimal basePrice)
    {
        _colour = colour;
        _bodyType = bodyType;
        _model = model;
        _basePrice = basePrice;
        _year = DateTime.Now;
    }
}

public abstract class VehicleDecorator: Vehicle
{
    // decorator class must have a property of the object that it is decorating
    // this is the same class as the one it inherits from
    public Vehicle Vehicle { get; set; }

    // requires overrides of the decorated values
    // these will be abstract because the concrete decorators must decide on their value
    public abstract override decimal BasePrice();
    public abstract override string Model();
    
    public VehicleDecorator(Vehicle decorated)
    {
        Vehicle = decorated;
    }
}

public class DecoratorLeatherSeats : VehicleDecorator
{
    public override decimal BasePrice()
    {
        return Vehicle.BasePrice() + 2000;
    }

    public override string Model()
    {   
        if (Vehicle is VehicleDecorator)
        {
            return $"{Vehicle.Model()}L";
        }
        else
        {
            return $"{Vehicle.Model()} L";
        }
    }

    public DecoratorLeatherSeats(Vehicle decorated) : base(decorated)
    {

    }
}

public class DecoratorIgnitionButton : VehicleDecorator
{
    public override decimal BasePrice()
    {
        return Vehicle.BasePrice() + 1000;
    }

    public override string Model()
    {
        // it should add these letters without a space to previous decorator letters
        // but it should add a space if the base model is the vehicle name
        // Accord LIV instead of Accord L I V

        if (Vehicle is VehicleDecorator)
        {
            return $"{Vehicle.Model()}I";
        }
        else
        {
            return $"{Vehicle.Model()} I";
        }
    }

    public DecoratorIgnitionButton(Vehicle decorated) : base(decorated)
    {

    }
}

public class DecoratorSpecialEdition : VehicleDecorator
{
    public override decimal BasePrice()
    {
        return Vehicle.BasePrice() + 20000;
    }

    public override string Model()
    {
        if (Vehicle is VehicleDecorator)
        {
            return $"{Vehicle.Model()}SE";
        }
        else
        {
            return $"{Vehicle.Model()} SE";
        }
    }

    public DecoratorSpecialEdition(Vehicle decorated): base(decorated) { }
}