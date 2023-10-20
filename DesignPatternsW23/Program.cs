PizzaStore winnipegStore = new WinnipegPizzaStore();
PizzaStore florenceStore = new FlorencePizzaStore();

try
{
    Pizza firstNewPizza = winnipegStore.OrderPizza("cheese");

    Console.WriteLine("======");

    Pizza secondNewPizza = florenceStore.OrderPizza("cheese");
} catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

// "Factory class"
public abstract class PizzaStore
{
    // this method will be the same for all subclasses
    public Pizza OrderPizza(string type)
    {
            Pizza newPizza;

            // note that createPizza method definition is left to children of this abstract class
            newPizza = CreatePizza(type);

            newPizza.Prepare();
            newPizza.Bake();
            newPizza.Cut();
            newPizza.Box();

            return newPizza;
    }

    // this method must be implemented differently for each subclass
    // "Factory method"
    protected abstract Pizza CreatePizza(string type);
}

public class WinnipegPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        Pizza newPizza;
        if(type == "cheese")
        {
            newPizza = new WinnipegCheesePizza();
        } else
        {
            throw new InvalidOperationException();
        }

        return newPizza;
    }
}

public class FlorencePizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        Pizza newPizza;
        if (type == "cheese")
        {
            newPizza = new FlorenceCheesePizza();
        }
        else
        {
            throw new InvalidOperationException();
        }

        return newPizza;
    }
}


// Abstract + Concrete Pizza classes

public abstract class Pizza
{
    public abstract void Prepare();
    public abstract void Bake();
    public abstract void Cut();
    public abstract void Box();
}

public class WinnipegCheesePizza: Pizza
{
    public override void Prepare()
    {
        Console.WriteLine("Getting cheddar cheese");
    }

    public override void Bake()
    {
        Console.WriteLine("Baking at 450 degrees for 20 minutes");
    }

    public override void Cut()
    {
        Console.WriteLine("Cutting into triangles");
    }

    public override void Box()
    {
        Console.WriteLine("Placing into a big red box");
    }
}

public class FlorenceCheesePizza : Pizza
{
    public override void Prepare()
    {
        Console.WriteLine("Getting mozarella cheese");
    }

    public override void Bake()
    {
        Console.WriteLine("Baking at 500 degrees for 15 minutes");
    }

    public override void Cut()
    {
        Console.WriteLine("Cutting into squares");
    }

    public override void Box()
    {
        Console.WriteLine("Placing into a little white box");
    }
}