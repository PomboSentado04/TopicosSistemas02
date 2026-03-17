// Variáveis
int tmnVetor = 100;
int maxValor = 1000;
Random random = new Random();
int[] vetor = new int[tmnVetor];

Console.WriteLine("\nDesordenados:");

// Coloca valores no vetor e imprime vetor desordenado
for (int i = 0; i < tmnVetor; i++)
{
    vetor[i] = random.Next(maxValor) + 1;
    Console.Write(vetor[i] + " ");
}

Console.WriteLine("\n");

Array.Sort(vetor);
Array.Reverse(vetor);

Console.WriteLine("\nOrdenados:");

// Imprime vetor ordenado
for (int i = 0; i < tmnVetor; i++)
{
    Console.Write(vetor[i] + " ");
}