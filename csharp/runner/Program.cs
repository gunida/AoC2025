// See https://aka.ms/new-console-template for more information

using code;

var dataFolder = args[0];

var day1_1 = await DayOne.SolveAsync(50, Path.Combine(dataFolder, "day1_1.txt"));

Console.WriteLine($"day1_1 Solution: {day1_1}");


var day1_2 = await DayOne.SolvePartTwoAsync(50, Path.Combine(dataFolder, "day1_1.txt"));

Console.WriteLine($"day1_2 Solution: {day1_2}");