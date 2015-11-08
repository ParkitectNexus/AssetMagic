// ParkitectNexus.AssetMagic
// Copyright 2015 Tim Potze
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace ParkitectNexus.AssetMagic.Streams
{
    public class BitmapDataStream : Stream
    {
        private const int OffsetHeader = 0;
        private const int OffsetVersion = 2;
        private const int OffsetLength = 3;
        private const int OffsetChecksum = 7;
        private const int OffsetData = 23;
        private const byte Version = 1;

        private static readonly byte[] Header = {0x53, 0x4D};
        private readonly Bitmap _bitmap;
        private readonly byte[] _buffer;
        private int _index;
        private int _length;

        public BitmapDataStream(Bitmap bitmap)
        {
            if (bitmap == null) throw new ArgumentNullException(nameof(bitmap));
            _bitmap = bitmap;

            var hdr = ReadImage().Take(OffsetData).ToArray();
            _buffer = ReadImage().Skip(OffsetData).ToArray();

            if (_buffer.Length != ((_bitmap.Width*_bitmap.Height)/2) - OffsetData)
                throw new IOException("unexpected length");

            _length = BitConverter.ToInt32(hdr.Skip(OffsetLength).Take(4).ToArray(), 0);

            var md5 = MD5.Create();
            var checksum = md5.ComputeHash(_buffer, 0, _length);

            var version = hdr.ElementAt(OffsetVersion);

            if (!Header.SequenceEqual(hdr.Skip(OffsetHeader).Take(Header.Length)) ||
                version != Version ||
                _length < 0 || _length >= _buffer.Length - OffsetData ||
                !checksum.SequenceEqual(hdr.Skip(OffsetChecksum).Take(checksum.Length)))
            {
                ClearBuffer();
            }
        }

        private void ClearBuffer()
        {
            _index = 0;
            _length = 0;
        }

        private void WriteHeader()
        {
            WriteBytes(OffsetHeader, Header, 0, Header.Length);
        }

        private void WriteVersion()
        {
            WriteByte(OffsetVersion, 1);
        }

        private void WriteLength()
        {
            WriteBytes(OffsetLength, BitConverter.GetBytes(_length), 0, 4);
        }

        private void WriteChecksum()
        {
            var md5 = MD5.Create();
            var checksum = md5.ComputeHash(_buffer, 0, _length);

            WriteBytes(OffsetChecksum, checksum, 0, 16);
        }

        private void WriteData()
        {
            WriteBytes(OffsetData, _buffer, 0, _length);
        }

        private byte ReadNibble(Color pixel)
        {
            return (byte) (
                ((pixel.A & 1) << 3) |
                ((pixel.B & 1) << 2) |
                ((pixel.G & 1) << 1) |
                (pixel.R & 1)
                );
        }

        private IEnumerable<byte> ReadImage()
        {
            var swap = false;
            byte memory = 0;

            for (var y = 0; y < _bitmap.Height; y++)
                for (var x = 0; x < _bitmap.Width; x++)
                {
                    var nibble = ReadNibble(_bitmap.GetPixel(x, y));

                    if (swap)
                        yield return (byte) ((nibble << 4) | memory);
                    else
                        memory = nibble;

                    swap = !swap;
                }
        }

        private void WriteNibble(ref Color color, byte nibble)
        {
            color = Color.FromArgb(
                ((color.A & ~1) | ((nibble >> 3) & 1)),
                ((color.R & ~1) | ((nibble >> 0) & 1)),
                ((color.G & ~1) | ((nibble >> 1) & 1)),
                ((color.B & ~1) | ((nibble >> 2) & 1))
                );
        }

        private void WriteByte(int index, byte value)
        {
            var lIndex = index*2;
            var rIndex = lIndex + 1;

            var ly = lIndex/_bitmap.Width;
            var lx = lIndex%_bitmap.Width;

            var ry = rIndex/_bitmap.Width;
            var rx = rIndex%_bitmap.Width;

            if (ry >= _bitmap.Height)
                throw new IOException("Out of range of image");

            var lPixel = _bitmap.GetPixel(lx, ly);
            var rPixel = _bitmap.GetPixel(rx, ry);

            WriteNibble(ref lPixel, (byte) (value & 15));
            WriteNibble(ref rPixel, (byte) (value >> 4));

            _bitmap.SetPixel(lx, ly, lPixel);
            _bitmap.SetPixel(rx, ry, rPixel);
        }

        private void WriteBytes(int startIndex, byte[] buffer, int index, int count)
        {
            for (var i = 0; i < count; i++)
                WriteByte(startIndex + i, buffer[index + i]);
        }

        #region Overrides of Stream

        /// <summary>
        ///     Releases the unmanaged resources used by the <see cref="T:System.IO.Stream" /> and optionally releases the managed
        ///     resources.
        /// </summary>
        /// <param name="disposing">
        ///     true to release both managed and unmanaged resources; false to release only unmanaged
        ///     resources.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            Flush();
            base.Dispose(disposing);
        }

        /// <summary>
        ///     When overridden in a derived class, clears all buffers for this stream and causes any buffered data to be written
        ///     to the underlying device.
        /// </summary>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Flush()
        {
            WriteHeader();
            WriteVersion();
            WriteLength();
            WriteChecksum();
            WriteData();
        }

        /// <summary>
        ///     When overridden in a derived class, sets the position within the current stream.
        /// </summary>
        /// <returns>
        ///     The new position within the current stream.
        /// </returns>
        /// <param name="offset">A byte offset relative to the <paramref name="origin" /> parameter. </param>
        /// <param name="origin">
        ///     A value of type <see cref="T:System.IO.SeekOrigin" /> indicating the reference point used to
        ///     obtain the new position.
        /// </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    _index = (int) offset;
                    break;
                case SeekOrigin.Current:
                    _index = (int) offset;
                    break;
                case SeekOrigin.End:
                    _index = _length + (int) offset;
                    break;
            }

            if (_index < 0)
                _index = 0;

            if (_index > _length)
                _index = _length;

            return _index;
        }

        /// <summary>
        ///     When overridden in a derived class, sets the length of the current stream.
        /// </summary>
        /// <param name="value">The desired length of the current stream in bytes. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///     The stream does not support both writing and seeking, such as if the
        ///     stream is constructed from a pipe or console output.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
        public override void SetLength(long value)
        {
            if (value < 0 || value >= _bitmap.Width*_bitmap.Height)
                throw new IOException("length cannot surpass bounds of image.");

            _length = (int) value;
        }

        /// <summary>
        ///     When overridden in a derived class, reads a sequence of bytes from the current stream and advances the position
        ///     within the stream by the number of bytes read.
        /// </summary>
        /// <returns>
        ///     The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many
        ///     bytes are not currently available, or zero (0) if the end of the stream has been reached.
        /// </returns>
        /// <param name="buffer">
        ///     An array of bytes. When this method returns, the buffer contains the specified byte array with the
        ///     values between <paramref name="offset" /> and (<paramref name="offset" /> + <paramref name="count" /> - 1) replaced
        ///     by the bytes read from the current source.
        /// </param>
        /// <param name="offset">
        ///     The zero-based byte offset in <paramref name="buffer" /> at which to begin storing the data read
        ///     from the current stream.
        /// </param>
        /// <param name="count">The maximum number of bytes to be read from the current stream. </param>
        /// <exception cref="T:System.ArgumentException">
        ///     The sum of <paramref name="offset" /> and <paramref name="count" /> is
        ///     larger than the buffer length.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="buffer" /> is null. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="offset" /> or <paramref name="count" /> is
        ///     negative.
        /// </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.NotSupportedException">The stream does not support reading. </exception>
        /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));
            var maxCount = _length - _index;
            if (count > maxCount)
                count = maxCount;

            Array.Copy(_buffer, _index, buffer, offset, count);

            _index += count;
            return count;
        }

        /// <summary>
        ///     When overridden in a derived class, writes a sequence of bytes to the current stream and advances the current
        ///     position within this stream by the number of bytes written.
        /// </summary>
        /// <param name="buffer">
        ///     An array of bytes. This method copies <paramref name="count" /> bytes from
        ///     <paramref name="buffer" /> to the current stream.
        /// </param>
        /// <param name="offset">
        ///     The zero-based byte offset in <paramref name="buffer" /> at which to begin copying bytes to the
        ///     current stream.
        /// </param>
        /// <param name="count">The number of bytes to be written to the current stream. </param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));
            if (_length < _index + count)
                SetLength(_index + count);

            Array.Copy(buffer, 0, _buffer, _index, count);

            _index += count;
        }

        /// <summary>
        ///     When overridden in a derived class, gets a value indicating whether the current stream supports reading.
        /// </summary>
        /// <returns>
        ///     true if the stream supports reading; otherwise, false.
        /// </returns>
        public override bool CanRead { get; } = true;

        /// <summary>
        ///     When overridden in a derived class, gets a value indicating whether the current stream supports seeking.
        /// </summary>
        /// <returns>
        ///     true if the stream supports seeking; otherwise, false.
        /// </returns>
        public override bool CanSeek { get; } = true;

        /// <summary>
        ///     When overridden in a derived class, gets a value indicating whether the current stream supports writing.
        /// </summary>
        /// <returns>
        ///     true if the stream supports writing; otherwise, false.
        /// </returns>
        public override bool CanWrite { get; } = true;

        /// <summary>
        ///     When overridden in a derived class, gets the length in bytes of the stream.
        /// </summary>
        /// <returns>
        ///     A long value representing the length of the stream in bytes.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">A class derived from Stream does not support seeking. </exception>
        /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
        public override long Length => _length;

        /// <summary>
        ///     When overridden in a derived class, gets or sets the position within the current stream.
        /// </summary>
        /// <returns>
        ///     The current position within the stream.
        /// </returns>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.NotSupportedException">The stream does not support seeking. </exception>
        /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
        public override long Position
        {
            get { return _index; }
            set { Seek(value, SeekOrigin.Begin); }
        }

        #endregion
    }
}