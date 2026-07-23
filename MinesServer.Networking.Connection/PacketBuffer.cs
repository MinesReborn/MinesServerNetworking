using MinesServer.Networking.Exceptions;
using System;
using System.Runtime.CompilerServices;

namespace MinesServer.Networking.Connection;

public class PacketBuffer
{
    private byte[] _buffer;
    private int _readPos;
    private int _writePos;
    private readonly int _initialCapacity;
    private readonly int _maxLength;
    private const int ShrinkFactor = 4;

    public PacketBuffer(int initialCapacity = 8192 /* 8K */, int maxLength = 4194304 /* 4M */)
    {
        _initialCapacity = initialCapacity;
        _maxLength = maxLength;
        _buffer = new byte[initialCapacity];
        _readPos = 0;
        _writePos = 0;
    }

    public void Put(byte[] data, int length)
    {
        if (length == 0) return;

        EnsureCapacity(length);
        Unsafe.CopyBlock(ref _buffer[_writePos], ref data[0], (uint)length);
        _writePos += length;
    }

    public bool TryTake(out byte[] packet)
    {
        packet = null;
        int available = _writePos - _readPos;

        if (available < 4) return false;

        int packetLength = Unsafe.ReadUnaligned<int>(ref _buffer[0]);

        if (packetLength < 4)
            throw new PacketDecodeException($"Packet length is too small: {packetLength}");

        if (packetLength > _maxLength)
            throw new PacketDecodeException($"Packet length is too long: {packetLength}");

        if (available < packetLength) return false;

        packet = new byte[packetLength];
        Unsafe.CopyBlock(ref packet[0], ref _buffer[_readPos], (uint)packetLength);
        _readPos += packetLength;

        CompactBuffer();
        return true;
    }

    private void EnsureCapacity(int appendLength)
    {
        int totalRequired = _writePos + appendLength;
        if (totalRequired <= _buffer.Length) return;

        int currentDataLength = _writePos - _readPos;
        int newCapacity = Math.Max(_buffer.Length * 2, currentDataLength + appendLength);

        byte[] newBuffer = new byte[newCapacity];
        if (currentDataLength > 0)
            Unsafe.CopyBlock(ref newBuffer[0], ref _buffer[_readPos], (uint)currentDataLength);

        _buffer = newBuffer;
        _readPos = 0;
        _writePos = currentDataLength;
    }

    private void CompactBuffer()
    {
        int dataLength = _writePos - _readPos;

        if (_readPos == 0)
        {
            TryShrinkBuffer();
            return;
        }

        if (dataLength > 0)
            Unsafe.CopyBlock(ref _buffer[0], ref _buffer[_readPos], (uint)dataLength);

        _readPos = 0;
        _writePos = dataLength;

        TryShrinkBuffer();
    }

    private void TryShrinkBuffer()
    {
        int currentCapacity = _buffer.Length;
        int desiredCapacity = Math.Max(
            _initialCapacity,
            Math.Max(_writePos * 2, _initialCapacity)
        );

        if (currentCapacity > desiredCapacity * ShrinkFactor)
        {
            byte[] newBuffer = new byte[desiredCapacity];
            Unsafe.CopyBlock(ref newBuffer[0], ref _buffer[0], (uint)_writePos);
            _buffer = newBuffer;
        }
    }
}
    