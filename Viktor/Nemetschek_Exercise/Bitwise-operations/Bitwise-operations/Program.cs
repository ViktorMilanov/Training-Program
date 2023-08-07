int n = int.Parse(Console.ReadLine());
int p = int.Parse(Console.ReadLine());

int mask = 1 << p;

int ValueOfTheBitInThePosition = (n & mask) >> p;

Console.WriteLine(ValueOfTheBitInThePosition);