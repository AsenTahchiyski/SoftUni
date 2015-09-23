namespace StringExtension
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// This class contains a couple of extension methods for the System.String class: MD5 hash calculator, statement to boolean value converter, parsers to short, int, long and DateTime, first letter capitalizer, method for getting a substring between two other substrings, cyrillic to latin and vice versa converters, string to valid username converter, string to valid latin filename converter, method for getting a substring of the first N characters, file extension extractor from filename, content type provider based on file extension and string to byte array converter.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Calculates the MD5 hash of a given string.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>MD5 hash of the string.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Checks whether the input string represents a positive statement in either boolean, english or bulgarian.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>Bool value representing whether the input statement is positive or not.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts the provided string value to a variable of type short.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>Parses the string to a short and returns it. If no success, returns 0.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts the provided string value to a variable of type integer.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>Parses the input string to a integer and returns it. If no success, returns 0.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts the provided string value to a variable of type long.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>Parses the input string to a long and returns it. If no success, returns 0.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts the provided string value to a variable of type DateTime.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>Parses the input string to a DateTime and returns it. If no success - returns DateTime.MinValue.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalizes the string's first letter.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>Returns the string with its first letter capitalized. If string is null or empty, returns it unchanged.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return
                input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) +
                input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Takes a substring from the input string, that is contained between two other substrings - start and end. 
        /// Index of the original string to start the search from can be specified, default value is 0.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="startString">Substring to start from.</param>
        /// <param name="endString">Substring to end by.</param>
        /// <param name="startFrom">Specifies the index from which a start string is looked for. Default value is 0.</param>
        /// <returns>The substring contained between start and end substrings.</returns>
        public static string GetStringBetween(
            this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition =
                input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts cyrillic letters in the input string to latin letters (either one or a combination).
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>The input string with all cyrillic letters converted to their latin counterpart.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
        {
            "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о",
            "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
        };
            var latinRepresentationsOfBulgarianLetters = new[]
        {
            "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
            "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
            "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
        };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(),
                    latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts latin letters in the input string to cyrillic letters.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>The input string with all latin letters converted to their cyrillic counterpart.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
            "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
        };

            var bulgarianRepresentationOfLatinKeyboard = new[]
        {
            "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
            "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
            "в", "ь", "ъ", "з"
        };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(),
                    bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts the provided string to a valid username using RegEx. A valid username is considered one that may contain only latin letters (both uppercase and/or lowercase), digits, underscores and dots.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>Converts all cyrillic letters to latin, removes all characters that are not considered valid and returns the result.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts the provided string to a valid latin filename using RegEx. A valid latin filename is considered one that may contain only latin letters (both uppercase and/or lowercase), digits, underscores, dashes and dots.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>Converts all cyrillic letters to latin, removes all characters that are not considered valid and returns the result.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Provides the first N input characters.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="charsCount">Number of characters to get from the beginning.</param>
        /// <returns>Substring of the first N characters.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Gets the extension from a file name.
        /// </summary>
        /// <param name="fileName">File name.</param>
        /// <returns>The file extension, converted to lowercase stirng.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Provides the content type based on file extension. Works for the following extension: jpg, jpeg, png, docx, doc, pdf, txt, rtf.
        /// </summary>
        /// <param name="fileExtension">File extension string.</param>
        /// <returns>File content type as string. If extension is not recognized, returns "application/octet-stream".</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
        {
            { "jpg", "image/jpeg" },
            { "jpeg", "image/jpeg" },
            { "png", "image/x-png" },
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { "doc", "application/msword" },
            { "pdf", "application/pdf" },
            { "txt", "text/plain" },
            { "rtf", "application/rtf" }
        };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts the input string to byte array.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>Byte array containing the string data.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }

}

