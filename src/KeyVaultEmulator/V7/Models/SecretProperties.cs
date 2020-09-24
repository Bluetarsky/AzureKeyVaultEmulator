// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace AzureKeyVaultEmulator.V7.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Properties of the key backing a certificate.
    /// </summary>
    public partial class SecretProperties
    {
        /// <summary>
        /// Initializes a new instance of the SecretProperties class.
        /// </summary>
        public SecretProperties()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SecretProperties class.
        /// </summary>
        /// <param name="contentType">The media type (MIME type).</param>
        public SecretProperties(string contentType = default(string))
        {
            ContentType = contentType;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the media type (MIME type).
        /// </summary>
        [JsonProperty(PropertyName = "contentType")]
        public string ContentType { get; set; }

    }
}
