﻿using System;
using System.Runtime.Serialization;

namespace Expressive.Exceptions
{
    /// <summary>
    /// Represents an error that is thrown when a token is not recognised inside an <see cref="Expression"/>.
    /// </summary>
    [Serializable]
    public sealed class UnrecognisedTokenException : Exception
    {
        /// <summary>
        /// Gets the unrecognised token in the <see cref="Expression"/>.
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnrecognisedTokenException"/> class with a specified unrecognised token.
        /// </summary>
        /// <param name="token">The unrecognised token.</param>
        internal UnrecognisedTokenException(string token)
            : base("Unrecognised token '" + token + "'")
        {
            this.Token = token;
        }

        /// <summary>
        /// Set the <see cref="SerializationInfo"/> with information about this exception.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("Token", Token);
        }
    }
}
