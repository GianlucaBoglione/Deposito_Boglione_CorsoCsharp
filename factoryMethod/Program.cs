using System;

public interface IShape
{
    void Draw();
}

// classe derivata che implementa cerchio
public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Disegna un cerchio.");
    }
}
// classe derivata che implementa quadrato
public class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("Disegna un quadrato.");
    }
}
// classe astratta ShapeCreator con il metodo CreateShape(string type).

public abstract class ShapeCreator
{
    public abstract IShape CreateShape(string type);
}


// Classe che implementa due ConcreteShapeCreator ("creator") che, a seconda di "type" ("circle" o "square"), restituiscano l'istanza corretta. 
public class CircleCreator : ShapeCreator
{
    public override IShape CreateShape(string type)
    {
        return new Circle();
    }
}

public class SquareCreator : ShapeCreator
{
    public override IShape CreateShape(string type)
    {
        return new Square();
    }
}



public class Client
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Quale forma vuoi disegnare ? (cerchio / quadrato)");
        string input = Console.ReadLine().ToLower();

        ShapeCreator creator = null;


        switch (input)
        {
            case "cerchio":
                creator = new CircleCreator();
                break;
            case "quadrato":
                creator = new SquareCreator();
                break;
            default:
                Console.WriteLine("scelta non valida.");
                break;
        }

        IShape shape = creator.CreateShape(input);

        if (shape != null)
        {
            shape.Draw();
        }
        else
        {
            Console.WriteLine("Impossibile creare la forma richiesta.");
        }
    }
}
