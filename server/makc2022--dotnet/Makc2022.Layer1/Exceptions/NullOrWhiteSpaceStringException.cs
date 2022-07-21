// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer1.Exceptions
{
    /// <summary>
    /// Исключение, выбрасываемое в случае обнаружения нуля вместо строки
    /// или пустой строки или строки, состоящий только из пробельных символов.
    /// </summary>
    public class NullOrWhiteSpaceStringException : Exception
    {
        #region Properties

        /// <summary>
        /// Имя строки.
        /// </summary>
        public string StringName { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="stringNameParts">Части имени строки.</param>
        public NullOrWhiteSpaceStringException(params string[] stringNameParts)
        {
            StringName = string.Join(".", stringNameParts);
        }

        #endregion Constructors
    }
}
