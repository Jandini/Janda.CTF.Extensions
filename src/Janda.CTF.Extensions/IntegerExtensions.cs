using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

namespace Janda.CTF
{
    public static class IntegerExtensions
    {

        public static Span<byte> ToLittleEndianSpan(this int value)
        {
            var result = new byte[4].AsSpan();
            BinaryPrimitives.WriteInt32LittleEndian(result, value);
            return result;
        }

        public static Span<byte> ToBigEndianSpan(this int value)
        {
            var result = new byte[4].AsSpan();
            BinaryPrimitives.WriteInt32BigEndian(result, value);
            return result;
        }

        public static void CopyTo(this int value, Span<byte> span)
        {
            BinaryPrimitives.WriteInt32LittleEndian(span, value);
        }

        public static void CopyTo(this int value, Span<byte> span, int start)
        {
            BinaryPrimitives.WriteInt32LittleEndian(span.Slice(start), value);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<byte> ToSpan(this int value)
        {
            return (new byte[value]).AsSpan();
        }



        /// <summary>
        /// Create byte span and fill it with single character. 
        /// 128.AsSpan('A') creates 128 byte array filled with 0x65 'A' character
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fill"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<byte> ToSpan(this int value, char fill)
        {
            var result = (new byte[value]).AsSpan();
            result.Fill((byte)fill);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<byte> ToSpan(this int value, byte fill)
        {
            var result = (new byte[value]).AsSpan();
            result.Fill(fill);
            return result;
        }
    }
}
