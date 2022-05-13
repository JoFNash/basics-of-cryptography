#include <iostream>
#include <bitset>

using namespace std;

int P_block[] = {16, 7, 20, 21,
            29, 12, 28, 17,
            1, 15, 23, 26,
            5, 18, 31, 10,
            2, 8, 24, 14,
            32, 27, 3, 9,
            19, 13, 30, 6,
            22, 11, 4, 25};

template <size_t N>
bitset<N> BitSwapping(bitset<N> input, int rule[])
{
	size_t		i;
	bitset<N>	res_bitset;

	i = 0;
	while (i < N)
	{
		res_bitset[(N - 1) - i] = input[(N - 1) - (rule[i] - 1);
		i++;
	}
	return (res_bitset);
}

// template <size_t N>
// bitset<N> BitSwapping(bitset<N> input, int rule[])
// {
// 	int n;
// 	bitset<N> res_bitset;
// 	bitset<N> copy_input;

// 	unsigned int bit;

// 	n = 0;
// 	while (n < N)
// 	{
// 		copy_input = input;
// 		copy_input &= (1 << n);
// 		if (copy_input[n])
// 			res_bitset |= (1 << (n - 1));
// 		//cout << copy_input << endl; 
// 		n++;
// 	}
// 	return (res_bitset);
// }

int main(int argc, char *argv[])
{
	bitset<32> bit(180);

	cout << bit << endl;

	bit = BitSwapping(bit, P_block);
	
	cout << bit << endl;

	return (0);
}