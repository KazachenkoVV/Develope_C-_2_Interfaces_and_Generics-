// Домашнее задание. Семинар 2. Интерфейсы и обобщения.
// Реализуйте операторы явного и неявного приведения из
// long, int, byte в Bits
namespace Develope_2_HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Работа через индексатор. Размер long");
            Console.WriteLine("Запись 1 с последующим стиранием в каждый разряд:");

            Bits b1 = new Bits((byte)0);
            int size = sizeof(byte) * 8;
            int j = 0;
            Console.WriteLine($"Разряд {j} -> {(b1[j] ? 1 : 0)} => {b1.ToString()}");
            for (int i = 1; i < size; i++)
            {
                b1[i - 1] = true;
                Console.WriteLine($"Разряд {i} -> {(b1[i - 1] ? 1 : 0)} => {b1.ToString()}");
                b1[i - 1] = false;
            }
            b1[size - 1] = true;
            Console.WriteLine($"Разряд {j} -> {(b1[j] ? 1 : 0)} => {b1.ToString()}");
            Console.WriteLine("---");

            Bits l1 = new Bits((long)0);
            size = sizeof(long) * 8;
            j = 0;
            Console.WriteLine($"Разряд {j} -> {(l1[j] ? 1 : 0)} => {l1.ToString()}");
            for (int i = 1; i < size; i++)
            {
                l1[i - 1] = true;
                Console.WriteLine($"Разряд {i} -> {(l1[i - 1] ? 1 : 0)} => {l1.ToString()}");
                l1[i - 1] = false;
            }
            l1[size - 1] = true;
            Console.WriteLine($"Разряд {j} -> {(l1[j] ? 1 : 0)} => {l1.ToString()}");

            // Приведение типов
            Console.WriteLine("\nПриведение типов");
            long l2 = new Bits((long)1000); // Неявное
            var l3 = (Bits)l2;              // Явное
            Console.WriteLine($"Bits  -> long  : l2 = {l2}");
            Console.WriteLine($"long  -> Bits  : l3 = {l3.ToString()}");

            int i2 = new Bits((int)1000); // Неявное
            var i3 = (Bits)i2;              // Явное
            Console.WriteLine($"Bits  -> int   : i2 = {i2}");
            Console.WriteLine($"int   -> Bits  : i3 = {i3.ToString()}");

            short s2 = new Bits((short)1000); // Неявное
            var s3 = (Bits)s2;              // Явное
            Console.WriteLine($"Bits  -> short : s2 = {s2}");
            Console.WriteLine($"short -> Bits  : s3 = {s3.ToString()}");

            byte b2 = new Bits((byte)100); // Неявное
            var b3 = (Bits)b2;              // Явное
            Console.WriteLine($"Bits  -> byte  : b2 = {b2}");
            Console.WriteLine($"byte  -> Bits  : b3 = {b3.ToString()}");
        }
    }
}
