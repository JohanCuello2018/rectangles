// See https://aka.ms/new-console-template for more information
using RectangleProcessor.Core;

Console.WriteLine("First Rectangle");
Console.WriteLine(@"Please, add the coordinates, width and height of the rectangle.");

int x1;
do
{
    Console.Write("X: ");
} while (!int.TryParse(Console.ReadLine(), out x1));

int y1;
do
{
    Console.Write("Y: ");
} while (!int.TryParse(Console.ReadLine(), out y1));

int width1;
do
{
    Console.Write("Width: ");
} while (!int.TryParse(Console.ReadLine(), out width1));

int height1;
do
{
    Console.Write("Height: ");
} while (!int.TryParse(Console.ReadLine(), out height1));


Console.WriteLine("\n");
Console.WriteLine("Second Rectangle");
Console.WriteLine(@"Please, add the coordinates, width and height of the rectangle.");
Console.WriteLine("Example: (x, y, height, width)");

int x2;
do
{
    Console.Write("X: ");
} while (!int.TryParse(Console.ReadLine(), out x2));

int y2;
do
{
    Console.Write("Y: ");
} while (!int.TryParse(Console.ReadLine(), out y2));

int width2;
do
{
    Console.Write("Width: ");
} while (!int.TryParse(Console.ReadLine(), out width2));

int height2;
do
{
    Console.Write("Height: ");
} while (!int.TryParse(Console.ReadLine(), out height2));

Rectangle rect1 = new Rectangle(x1, y1, width1, height1);
Rectangle rect2 = new Rectangle(x2, y2, width2, height2);

var isContainment = rect1.Contains(rect2);
var isIntersected = rect1.Intersects(rect2);
var isAdjacent = rect1.Adjacent(rect2);
var intersectionPoints = rect1.GetIntersectionPoints(rect2);

Console.WriteLine("\n");
Console.WriteLine("Results:");

Console.WriteLine($"The rectangle is contained: {isContainment}");
Console.WriteLine($"The rectangles are adjacent: {isAdjacent}");
Console.WriteLine($"The rectangles are intesected: {isIntersected}");

if (intersectionPoints != null && intersectionPoints.Any())
{
    Console.WriteLine($"Intersection Points:");

    foreach (var item in intersectionPoints)
    {
        Console.WriteLine($"\tX: {item.X}, Y: {item.Y}");
    }
}

Console.WriteLine("Press any key to continue...");
Console.ReadLine();
