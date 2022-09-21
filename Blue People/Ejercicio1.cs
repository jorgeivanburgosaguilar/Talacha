/*
Ejercicio 1

Escribe una función o método que detecte si en un arreglo un número se repite,
al menos cierta cantidad de veces. La función debe recibir el arreglo, el número 
que se quiere detectar y la cantidad de veces mínimas que debe aparecer

Ejemplo:
contiene([4, 5, 2, 4, 5, 9, 9, 4, 4], 4, 5); // Regresa false;
contiene([4, 5, 2, 4, 5, 9, 9, 4, 4], 4, 4); // Regresa true;
contiene([4, 5, 2, 4, 5, 9, 9, 4, 4], 4, 3); // Regresa true;
contiene([4, 5, 2, 4, 5, 9, 9, 4, 4], 9, 2); // Regresa true;
*/
using System;

public class Program
{
    private static bool contiene(int[] Arreglo, int NumeroBuscar, int CantidadVecesMinima)
    {
        var contador = 0;
        foreach(var numero in Arreglo)
        {
            if (NumeroBuscar == numero)
                contador++;
        }
        return contador >= CantidadVecesMinima;
    }

    public static void Main()
    {
        int[] arreglo = { 4, 5, 2, 4, 5, 9, 9, 4, 4 };
        Console.WriteLine(contiene(arreglo, 4, 5)); // Regresa false;
        Console.WriteLine(contiene(arreglo, 4, 4)); // Regresa true;
        Console.WriteLine(contiene(arreglo, 4, 3)); // Regresa true;
        Console.WriteLine(contiene(arreglo, 9, 2)); // Regresa true;
    }
}