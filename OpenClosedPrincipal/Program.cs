//open/closed principal

var operationList = new List<AbstractOperation> { new SumClass { x = 5, y = 6 }, new SubtractClass { x = 7, y = 3 }, new MultiplyClass { x = 3, y = 3 } };
var calculationClass = new CalculationClass();
calculationClass.Calculate(operationList);

var operList = new List<AbstractOper> { new AddOperation { x = 5, y = 6 }, new SubtractOperation { x = 7, y = 3 }, new MultiplyOperation { x = 3, y = 3 } };
Operation.Calculate(operList);
public abstract class AbstractOperation
{
    public int x { get; set; }
    public int y { get; set; }
}
public class SumClass : AbstractOperation { }
public class SubtractClass : AbstractOperation { }
public class MultiplyClass : AbstractOperation { }

public class CalculationClass
{
    public void Calculate(List<AbstractOperation> operations)
    {
        foreach (var operation in operations)
        {
            if (operation is SumClass)
            {
                Console.WriteLine($"x+y={operation.x + operation.y}");
            }
            else if (operation is SubtractClass)
            {
                Console.WriteLine($"x-y={operation.x - operation.y}");
            }
            else if (operation is MultiplyClass)
            {
                Console.WriteLine($"x*y={operation.x * operation.y}");
            }
        }

    }
}

//при добавлении новой операции нужно изменять класс CalculationClass
//для класса каждой операции сделать возможным запусскать свою собстенную калькуляцию
//и абстрагировать операции из CalculationClass
public abstract class AbstractOper
{
    public int x { get; set; }
    public int y { get; set; }
    public abstract void Exec();

}
public class AddOperation : AbstractOper
{
    public override void Exec()
    {
        Console.WriteLine($"x+y={x + y}");
    }
}

public class SubtractOperation : AbstractOper
{
    public override void Exec()
    {
        Console.WriteLine($"x-y={x - y}");
    }
}

public class MultiplyOperation : AbstractOper
{
    public override void Exec()
    {
        Console.WriteLine($"x*y={x * y}");
    }
}

public static class Operation
{
    public static void Calculate(List<AbstractOper> operations)
    {
        foreach (var operation in operations)
        {
            operation.Exec();
        }

    }
}