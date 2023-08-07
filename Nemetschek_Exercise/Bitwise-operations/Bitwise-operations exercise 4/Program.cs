int n = int.Parse(Console.ReadLine());
int p = int.Parse(Console.ReadLine());
int q = int.Parse(Console.ReadLine());
int k = int.Parse(Console.ReadLine());

int mask1 = 0;
int mask2 = 0;

for (int i = 0; i < k; i++)
{
    mask1 |= (1 << (p + i));
    mask2 |= (1 << (q + i));
}

int bitsFromMask1 = (n & mask1) >> p;
int bitsFromMask2 = (n & mask2) >> q;

n &= ~(mask1 | mask2);

n |= ((bitsFromMask2 << p) | (bitsFromMask1 << q));