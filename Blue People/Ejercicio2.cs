/*
Ejercicio 2

Realiza una función o método que reciba un arreglo y regresa la mayor diferencia
entre cualquier par de números, independientemente de su posición.

Ejemplo:
mayorDiferencia([1, 1, 4]); // 3
mayorDiferencia([9, 8]); // 1
mayorDiferencia([6, 22, 16, 29, 23]); // 23
mayorDiferencia([28, 16, 28, 11, 14, 26, 23, 25, 17, 3, 22, 23, 23, 10]); // 25
*/

using System;

public class Program
{
    private static int mayorDiferencia(int[] Arreglo)
    {
        int maximaDiferencia = 0;
        for (var i = 0; i < Arreglo.Length; i++) {
            for (var j = 0; j < Arreglo.Length; j++) {
                if (i == j)
                    continue;
                
                var diferencia = Arreglo[i] - Arreglo[j];
                if (diferencia > maximaDiferencia)
                    maximaDiferencia = diferencia;
            }
        }
        return maximaDiferencia;
    }

    public static void Main()
    {
        Console.WriteLine(mayorDiferencia(new int[] {1, 1, 4})); // 3
        Console.WriteLine(mayorDiferencia(new int[] {9, 8})); // 1
        Console.WriteLine(mayorDiferencia(new int[] {6, 22, 16, 29, 23})); // 23
        Console.WriteLine(mayorDiferencia(new int[] {28, 16, 28, 11, 14, 26, 23, 25, 17, 3, 22, 23, 23, 10})); // 25
    }
}