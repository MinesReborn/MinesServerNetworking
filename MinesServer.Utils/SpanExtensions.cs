using System;

namespace MinesServer.Utils
{
    public static class SpanExtensions
    {
        public static MemoryWriter Writer(this Span<byte> destination) => new(destination);

        public static MemoryReader Reader(this Span<byte> destination) => new(destination);

        public static MemoryReader Reader(this ReadOnlySpan<byte> destination) => new(destination);
    }
}
