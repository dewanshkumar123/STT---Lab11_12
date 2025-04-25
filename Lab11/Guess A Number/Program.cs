using System;

int value = Random.Shared.Next(1, 101);
while (true)
{
	Console.Write("Guess a number (1-100): ");
	bool valid = int.TryParse((Console.ReadLine() ?? "").Trim(), out int input);
	if (!valid) Console.WriteLine("Invalid.");
	else if (input == value) break;
	else Console.WriteLine($"Incorrect. Too {(input < value ? "Low" : "High")}.");
}
Console.WriteLine("You guessed it!");
Console.Write("Press any key to exit...");
Console.ReadKey(true);


//int value = Random.Shared.Next(1, 101);

//while (true)
//{
//	Console.Write("Guess a number (1-100): ");
//	string? inputStr = Console.ReadLine();
//	if (string.IsNullOrWhiteSpace(inputStr))
//	{
//		Console.WriteLine("Invalid input. Try again.");
//		continue;
//	}
//	if (inputStr == value.ToString())
//	{
//		break; 
//	}

//	bool valid = int.TryParse(inputStr.Trim(), out int input);
//	if (!valid)
//		Console.WriteLine("Invalid number.");
//	else if (input == value)
//		break; 
//	else
//		Console.WriteLine($"Incorrect. Too {(input < value ? "Low" : "High")}.");
//}