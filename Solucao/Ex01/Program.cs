// Variáveis
int tmnVetor = 1000;
int maxValor = 100;
Random random = new Random();
bool ordenado = false;
int[] vetor = new int[tmnVetor];

Console.WriteLine("\nDesordenados:");

// Coloca valores no vetor e imprime vetor desordenado
for (int i = 0; i < tmnVetor; i++)
{
    vetor[i] = random.Next(maxValor) + 1;
    Console.Write(vetor[i] + " ");
}

Console.WriteLine("\n");

// Imprime quantidade de vezes que cada valor apareceu: vetor desordenado
for (int i = 0; i < maxValor + 1; i++)
{
    int quantidadeValor = 0;
    for (int j = 0; j < tmnVetor; j++)
    {
        if (i == vetor[j])
        {
            quantidadeValor++;
        }
    }
    Console.WriteLine(i + ": " + quantidadeValor);
}

// Sai do loop apenas se vetor estiver ordenado
while (!ordenado)
{
    // Troca os valores se a posição atual do vetor for maior que a posterior
    for (int i = 0; i < tmnVetor; i++)
    {
        if (i < tmnVetor - 1 && vetor[i] > vetor[i + 1])
        {
            int aux = vetor[i];
            vetor[i] = vetor[i + 1];
            vetor[i + 1] = aux;
        }
    }

    // Verifica se o vetor está ordenado corretamente
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

// Imprime vetor ordenado
for (int i = 0; i < tmnVetor; i++)
{
    Console.Write(vetor[i] + " ");
}

Console.WriteLine("\n");

// Imprime quantidade de vezes que cada valor apareceu: vetor ordenado
for (int i = 0; i < maxValor + 1; i++)
{
    int quantidadeValor = 0;
    for (int j = 0; j < tmnVetor; j++)
    {
        if (i == vetor[j])
        {
            quantidadeValor++;
        }
    }
    Console.WriteLine(i + ": " + quantidadeValor);
}