using System;
using System.Runtime.InteropServices;
namespace Develope_2_HomeWork
{
    internal class Bits
    {
        public long Number { get; private set; }
        public byte Size { get; private set; }
        public Bits(byte number)
        {
            Number = number;
            Size = 7;
        }
        public Bits(short number)
        {
            Number = number;
            Size = 15;
        }
        public Bits(int number)
        {
            Number = number;
            Size = 31;
        }
        public Bits(long number)
        {
            Number = number;
            Size = 63;
        }
        public bool GetBitByIndex(int index)
        {
            if (index < 0 || index > Size) throw new ArgumentOutOfRangeException("index is out of range");
            return (Number & ((long)1 << index)) != 0;
        }
        public void SetBitByIndex(int index, bool value)
        {
            if (index < 0 || index > Size) throw new ArgumentOutOfRangeException("index is out of range");
            long mask = ((long)1 << index);

            if (value)
                Number |= mask;          // Установка бита
            else
                Number &= (long)~mask;   // Сброс бита
        }

        // Индексатор для удобства вызова
        public bool this[int index]
        {
            get => GetBitByIndex(index);
            set => SetBitByIndex(index, value);
        }

        public override string ToString()
        {
            return $"{Number} -> {Convert.ToString(Number, 2).PadLeft(Size + 1, '0')}";
        }

        // Приведение типов --------------------------------------------------------
        // Неявное приведение Bits -> byte
        public static implicit operator byte(Bits b) => (byte)CheckRange(b.Number, byte.MinValue, byte.MaxValue);
        // Явное приведение byte -> Bits
        public static explicit operator Bits(byte b) => new Bits(b);

        // Неявное приведение Bits -> short
        public static implicit operator short(Bits b) => (short)CheckRange(b.Number, short.MinValue, short.MaxValue);
        // Явное приведение short -> Bits
        public static explicit operator Bits(short s) => new Bits(s);

        // Неявное приведение Bits -> int
        public static implicit operator int(Bits b) => (int)CheckRange(b.Number, int.MinValue, int.MaxValue);
        // Явное приведение int -> Bits
        public static explicit operator Bits(int i) => new Bits(i);

        // Неявное приведение Bits -> long
        public static implicit operator long(Bits l) => l.Number;
        // Явное приведение long -> Bits
        public static explicit operator Bits(long l) => new Bits(l);

        private static long CheckRange(long value, long min, long max)
        {
            if ((value < min) || (value > max))
                throw new InvalidCastException($"Value {value} is out of range for target type.");
            return value;
        }
    }
}