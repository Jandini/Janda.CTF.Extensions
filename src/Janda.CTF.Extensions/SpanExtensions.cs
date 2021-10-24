using System;
using System.Runtime.CompilerServices;

namespace Janda.CTF
{
    public static class SpanExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] Concat<T>(this ReadOnlySpan<T> span0, ReadOnlySpan<T> span1) => SpanTool.Concat(span0, span1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] Concat<T>(this ReadOnlySpan<T> span0, ReadOnlySpan<T> span1, ReadOnlySpan<T> span2) => SpanTool.Concat(span0, span1, span2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] Concat<T>(this ReadOnlySpan<T> span0, ReadOnlySpan<T> span1, ReadOnlySpan<T> span2, ReadOnlySpan<T> span3) => SpanTool.Concat(span0, span1, span2, span3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] Concat<T>(this ReadOnlySpan<T> span0, ReadOnlySpan<T> span1, ReadOnlySpan<T> span2, ReadOnlySpan<T> span3, ReadOnlySpan<T> span4) => SpanTool.Concat(span0, span1, span2, span3, span4);

    }
}
