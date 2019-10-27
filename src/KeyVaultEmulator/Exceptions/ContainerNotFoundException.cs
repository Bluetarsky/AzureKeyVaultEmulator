using System;

namespace AzureKeyVaultEmulator.Exceptions
{

    [Serializable]
    public class ContainerNotFoundException : Exception
    {
        public ContainerNotFoundException() { }
        public ContainerNotFoundException(string message) : base(message) { }
        public ContainerNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected ContainerNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
