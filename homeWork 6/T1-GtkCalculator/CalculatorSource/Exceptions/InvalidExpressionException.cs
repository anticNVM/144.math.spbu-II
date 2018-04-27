using System;
using System.Collections.Generic;

namespace CalculatorSource.Exceptions
{
    [System.Serializable]
    public class InvalidExpressionException : Exception
    {
        public enum MessageTypes
        {
            MissedOpeningBracket,
            MissedClosingBracket,
            UnsupportedCharacters,
            OverOperands,
            NotEnoughOperands,
            DivisionByZero
        }

        public static readonly Dictionary<MessageTypes, string> _messages = new Dictionary<MessageTypes, string>()
        {
            [MessageTypes.MissedOpeningBracket] = "В выражении пропущена открывающаяя скобка",
            [MessageTypes.UnsupportedCharacters] = "Неподдерживаемый символ",
            [MessageTypes.MissedClosingBracket] = "В выражении пропущена закрывающая скобка",
            [MessageTypes.OverOperands] = "Неверное число операндов (больше необходимого)",
            [MessageTypes.NotEnoughOperands] = "Неверное число операндов (меньше необходимого)",
            [MessageTypes.DivisionByZero] = "Деление на ноль",
        };


        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyException"/> class
        /// </summary>
        public InvalidExpressionException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyException"/> class
        /// </summary>
        /// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
        public InvalidExpressionException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyException"/> class
        /// </summary>
        /// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
        /// <param name="inner">The exception that is the cause of the current exception. </param>
        public InvalidExpressionException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyException"/> class
        /// </summary>
        /// <param name="context">The contextual information about the source or destination.</param>
        /// <param name="info">The object that holds the serialized object data.</param>
        protected InvalidExpressionException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}
