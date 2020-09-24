// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace AzureKeyVaultEmulator.V7.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The key restore parameters.
    /// </summary>
    public partial class KeyRestoreParameters
    {
        /// <summary>
        /// Initializes a new instance of the KeyRestoreParameters class.
        /// </summary>
        public KeyRestoreParameters()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the KeyRestoreParameters class.
        /// </summary>
        /// <param name="keyBundleBackup">The backup blob associated with a key
        /// bundle.</param>
        public KeyRestoreParameters(byte[] keyBundleBackup)
        {
            KeyBundleBackup = keyBundleBackup;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the backup blob associated with a key bundle.
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "value")]
        public byte[] KeyBundleBackup { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (KeyBundleBackup == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "KeyBundleBackup");
            }
        }
    }
}
