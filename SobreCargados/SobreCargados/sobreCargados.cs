namespace sobreCargados
{
    public class Operaciones
    {
        // Método Cuadrado para un número entero (int)
        public int Cuadrado(int valorInt)
        {
            Console.WriteLine($"Se llamó a Cuadrado con argumento int: {valorInt}");
            return valorInt * valorInt;
        }

        // Método Cuadrado sobrecargado para un número decimal (double)
        public double Cuadrado(double valorDouble)
        {
            Console.WriteLine($"Se llamó a Cuadrado con argumento double: {valorDouble}");
            return valorDouble * valorDouble;
        }
    }
}