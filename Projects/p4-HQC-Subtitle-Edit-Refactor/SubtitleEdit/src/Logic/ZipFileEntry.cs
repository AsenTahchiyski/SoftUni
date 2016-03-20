﻿namespace Nikse.SubtitleEdit.Logic
{
    using System;
    using Enums;

    /// <summary>
    /// Represents an entry in Zip file directory
    /// </summary>
    public struct ZipFileEntry
    {
        /// <summary>Compression method</summary>
        public Compression Method;

        /// <summary>Full path and filename as stored in Zip</summary>
        public string FilenameInZip;

        /// <summary>Original file size</summary>
        public uint FileSize;

        /// <summary>Compressed file size</summary>
        public uint CompressedSize;

        /// <summary>Offset of header information inside Zip storage</summary>
        public uint HeaderOffset;

        /// <summary>Offset of file inside Zip storage</summary>
        public uint FileOffset;

        /// <summary>Size of header information</summary>
        public uint HeaderSize;

        /// <summary>32-bit checksum of entire file</summary>
        public uint Crc32;

        /// <summary>Last modification time of file</summary>
        public DateTime ModifyTime;

        /// <summary>User comment for file</summary>
        public string Comment;

        /// <summary>True if UTF8 encoding for filename and comments, false if default (CP 437)</summary>
        public bool EncodeUtf8;

        /// <summary>Overridden method</summary>
        /// <returns>Filename in Zip</returns>
        public override string ToString()
        {
            return this.FilenameInZip;
        }
    }
}
