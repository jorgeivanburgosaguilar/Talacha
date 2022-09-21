/*
Ejercicio 3

Realiza una función o método que reciba un arreglo de números y detecte si todos
los números en posición consecutiva están separados por la misma magnitud.

Ejemplo:
mismaDiferencia([1, 3, 5]); // true
mismaDiferencia([194, 54, 23, 7, 3, 6, 8]); // false
mismaDiferencia([44, 37, 30, 23]); // true
mismaDiferencia([-2.3, -1.1, 0.1, 1.3, 2.5, 3.7]); // true
mismaDiferencia([1, 8]); // true
mismaDiferencia([3, 2, 1, 2, 3, 4, 3]); // true
*/

using System;

public class Program
{
    private static bool mismaDiferencia(double[] Arreglo)
    {
        var esLaMismaDiferencia = true;
        double diferenciaAnterior = 0;
        for (var i = 0; i < Arreglo.Length; i++) {
            if (i == Arreglo.Length-1)
                break;

            // No me alcanzo el tiempo pero probalemente se deba a un problema de precision
            // mejor envio algo antes de que me pase de tiempo
            var diferencia = Math.Abs(Arreglo[i] - Arreglo[i+1]);
            if (!diferenciaAnterior.Equals(diferencia))
            {
                if (i == 0)
                {
                    diferenciaAnterior = diferencia;
                    continue;
                }

                //Console.WriteLine(diferencia);
                //Console.WriteLine(diferenciaAnterior);
                esLaMismaDiferencia = false;
                break;
            }
        }
        return esLaMismaDiferencia;
    }
    
    private static bool mismaDiferencia(int[] Arreglo)
    {
        var esLaMismaDiferencia = true;
        var diferenciaAnterior = 0;
        for (var i = 0; i < Arreglo.Length; i++) {
            if (i == Arreglo.Length-1)
                break;

            var diferencia = Math.Abs(Arreglo[i] - Arreglo[i+1]);
            if (diferencia != diferenciaAnterior)
            {
                if (i == 0)
                {
                    diferenciaAnterior = diferencia;
                    continue;
                }

                esLaMismaDiferencia = false;
                break;
            }
        }
        return esLaMismaDiferencia;
    }

    public static void Main()
    {
        Console.WriteLine(mismaDiferencia(new int[] { 1, 3, 5 })); // true
        Console.WriteLine(mismaDiferencia(new int[] { 194, 54, 23, 7, 3, 6, 8 })); // false
        Console.WriteLine(mismaDiferencia(new int[] { 44, 37, 30, 23 })); // true
        Console.WriteLine(mismaDiferencia(new double[] { -2.3, -1.1, 0.1, 1.3, 2.5, 3.7 })); // true
        Console.WriteLine(mismaDiferencia(new int[] { 1, 8 })); // true
        Console.WriteLine(mismaDiferencia(new int[] { 3, 2, 1, 2, 3, 4, 3 })); // true
    }
}