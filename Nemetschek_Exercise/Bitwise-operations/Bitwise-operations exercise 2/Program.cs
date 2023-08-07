int n = int.Parse(Console.ReadLine());
int p = int.Parse(Console.ReadLine());
int v = int.Parse(Console.ReadLine());
int mask = (1 << p);

if (v == 0)
{
    n = n & ~mask;
}
else
{
    n = n | mask;
}

Console.WriteLine(n);