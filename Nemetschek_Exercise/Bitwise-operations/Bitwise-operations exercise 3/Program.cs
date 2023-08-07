int n = int.Parse(Console.ReadLine());

int maskForFirstPositions = (1 << 3) | (1 << 4) | (1 << 5);
int maskForSecondPositions = (1 << 24) | (1 << 25) | (1 << 26);

int clearedBits1 = n & ~maskForFirstPositions;
int clearedBits2 = n & ~maskForSecondPositions;
int shiftedBits1 = (n & maskForFirstPositions) << 21;
int shiftedBits2 = (n & maskForSecondPositions) >> 21;
n = clearedBits1 | clearedBits2 | shiftedBits1 | shiftedBits2;

Console.WriteLine(n);
