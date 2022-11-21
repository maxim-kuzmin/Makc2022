// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer1.Exceptions.VariableExceptions
{
    /// <summary>
    /// Исключение, выбрасываемое в случае если переменная равна нулю.
    /// </summary>
    public class NullVariableException : VariableException
    {
        #region Constructors

        /// <inheritdoc/>
        public NullVariableException(params string[] variableNameParts)
            : base(variableNameParts)
        {
        }

        /// <inheritdoc/>
        public NullVariableException(Type type, params string[] variableNameParts)
            : base(type, variableNameParts)
        {
        }

        #endregion Constructors
    }

    /// <summary>
    /// Исключение, выбрасываемое в случае если переменная равна нулю.
    /// </summary>
    /// <typeparam name="T">Тип, содержащий переменную.</typeparam>
    public class NullVariableException<T> : VariableException<T>
    {
        #region Constructors

        /// <inheritdoc/>
        public NullVariableException(params string[] variableNameParts) : base(variableNameParts)
        {
        }

        #endregion Constructors
    }
}
