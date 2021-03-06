﻿// Copyright (c) Six Labors and contributors.
// Licensed under the Apache License, Version 2.0.

using System;
using SixLabors.ImageSharp.MetaData.Profiles.Icc;
using Xunit;

namespace SixLabors.ImageSharp.Tests.Icc
{
    public class IccDataWriterPrimitivesTests
    {
        [Theory]
        [MemberData(nameof(IccTestDataPrimitives.AsciiWriteTestData), MemberType = typeof(IccTestDataPrimitives))]
        public void WriteAsciiString(byte[] expected, string data)
        {
            IccDataWriter writer = CreateWriter();

            writer.WriteAsciiString(data);
            byte[] output = writer.GetData();

            Assert.Equal(expected, output);
        }

        [Theory]
        [MemberData(nameof(IccTestDataPrimitives.AsciiPaddingTestData), MemberType = typeof(IccTestDataPrimitives))]
        public void WriteAsciiStringPadded(byte[] expected, int length, string data, bool ensureNullTerminator)
        {
            IccDataWriter writer = CreateWriter();

            writer.WriteAsciiString(data, length, ensureNullTerminator);
            byte[] output = writer.GetData();

            Assert.Equal(expected, output);
        }

        [Fact]
        public void WriteAsciiStringWithNullWritesEmpty()
        {
            IccDataWriter writer = CreateWriter();

            int count = writer.WriteAsciiString(null);
            byte[] output = writer.GetData();

            Assert.Equal(0, count);
            Assert.Equal(new byte[0], output);
        }

        [Fact]
        public void WriteAsciiStringWithNegativeLenghtThrowsArgumentException()
        {
            IccDataWriter writer = CreateWriter();

            Assert.Throws<ArgumentOutOfRangeException>(() => writer.WriteAsciiString("abcd", -1, false));
        }

        [Fact]
        public void WriteUnicodeStringWithNullWritesEmpty()
        {
            IccDataWriter writer = CreateWriter();

            int count = writer.WriteUnicodeString(null);
            byte[] output = writer.GetData();

            Assert.Equal(0, count);
            Assert.Equal(new byte[0], output);
        }

        [Theory]
        [MemberData(nameof(IccTestDataPrimitives.Fix16TestData), MemberType = typeof(IccTestDataPrimitives))]
        public void WriteFix16(byte[] expected, float data)
        {
            IccDataWriter writer = CreateWriter();

            writer.WriteFix16(data);
            byte[] output = writer.GetData();

            Assert.Equal(expected, output);
        }

        [Theory]
        [MemberData(nameof(IccTestDataPrimitives.UFix16TestData), MemberType = typeof(IccTestDataPrimitives))]
        public void WriteUFix16(byte[] expected, float data)
        {
            IccDataWriter writer = CreateWriter();

            writer.WriteUFix16(data);
            byte[] output = writer.GetData();

            Assert.Equal(expected, output);
        }

        [Theory]
        [MemberData(nameof(IccTestDataPrimitives.U1Fix15TestData), MemberType = typeof(IccTestDataPrimitives))]
        public void WriteU1Fix15(byte[] expected, float data)
        {
            IccDataWriter writer = CreateWriter();

            writer.WriteU1Fix15(data);
            byte[] output = writer.GetData();

            Assert.Equal(expected, output);
        }

        [Theory]
        [MemberData(nameof(IccTestDataPrimitives.UFix8TestData), MemberType = typeof(IccTestDataPrimitives))]
        public void WriteUFix8(byte[] expected, float data)
        {
            IccDataWriter writer = CreateWriter();

            writer.WriteUFix8(data);
            byte[] output = writer.GetData();

            Assert.Equal(expected, output);
        }

        private IccDataWriter CreateWriter()
        {
            return new IccDataWriter();
        }
    }
}
