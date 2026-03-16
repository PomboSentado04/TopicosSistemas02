int tmnVetor = 1000;
int maxValor = 100;
Random random = new Random();
bool ordenado = false;
int[] vetor = new int[tmnVetor];

Console.WriteLine("\nDesordenados:");

for (int i = 0; i < tmnVetor; i++)
{
    vetor[i] = random.Next(maxValor) + 1;
    Console.Write(vetor[i] + " ");
}

while (!ordenado)
{
    for (int i = 0; i < tmnVetor; i++)
    {
        if (i < tmnVetor - 1 && vetor[i] > vetor[i + 1])
        {
            int aux = vetor[i];
            vetor[i] = vetor[i + 1];
            vetor[i + 1] = aux;
        }
    }

    for (int i = 0; i < tmnVetor; i++)
    {
        ordenado = true;
        if (i < tmnVetor - 1 && vetor[i] > vetor[i + 1])
        {
            ordenado = false;
            break;
        }
    }
}

Console.WriteLine("\n\nOrdenados:");

for (int i = 0; i < tmnVetor; i++)
{
    Console.Write(vetor[i] + " ");
}