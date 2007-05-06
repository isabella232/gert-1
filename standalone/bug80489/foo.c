

unsigned long long ull = 0x12345678abcdef0LLU;
int shift2 = 60;

int main()
{
    if ( ((ull >> shift2) | (ull << (64 - shift2))) != 0x12345678abcdef00LLU )
        return 1;
    return 0;
}
