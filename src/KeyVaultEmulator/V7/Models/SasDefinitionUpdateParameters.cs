// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace AzureKeyVaultEmulator.V7.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The SAS definition update parameters.
    /// </summary>
    public partial class SasDefinitionUpdateParameters
    {
        /// <summary>
        /// Initializes a new instance of the SasDefinitionUpdateParameters
        /// class.
        /// </summary>
        public SasDefinitionUpdateParameters()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SasDefinitionUpdateParameters
        /// class.
        /// </summary>
        /// <param name="templateUri">The SAS definition token template signed
        /// with an arbitrary key.  Tokens created according to the SAS
        /// definition will have the same properties as the template.</param>
        /// <param name="sasType">The type of SAS token the SAS definition will
        /// create. Possible values include: 'account', 'service'</param>
        /// <param name="validityPeriod">The validity period of SAS tokens
        /// created according to the SAS definition.</param>
        /// <param name="sasDefinitionAttributes">The attributes of the SAS
        /// definition.</param>
        /// <param name="tags">Application specific metadata in the form of
        /// key-value pairs.</param>
        public SasDefinitionUpdateParameters(string templateUri = default(string), string sasType = default(string), string validityPeriod = default(string), SasDefinitionAttributes sasDefinitionAttributes = default(SasDefinitionAttributes), IDictionary<string, string> tags = default(IDictionary<string, string>))
        {
            TemplateUri = templateUri;
            SasType = sasType;
            ValidityPeriod = validityPeriod;
            SasDefinitionAttributes = sasDefinitionAttributes;
            Tags = tags;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the SAS definition token template signed with an
        /// arbitrary key.  Tokens created according to the SAS definition will
        /// have the same properties as the template.
        /// </summary>
        [JsonProperty(PropertyName = "templateUri")]
        public string TemplateUri { get; set; }

        /// <summary>
        /// Gets or sets the type of SAS token the SAS definition will create.
        /// Possible values include: 'account', 'service'
        /// </summary>
        [JsonProperty(PropertyName = "sasType")]
        public string SasType { get; set; }

        /// <summary>
        /// Gets or sets the validity period of SAS tokens created according to
        /// the SAS definition.
        /// </summary>
        [JsonProperty(PropertyName = "validityPeriod")]
        public string ValidityPeriod { get; set; }

        /// <summary>
        /// Gets or sets the attributes of the SAS definition.
        /// </summary>
        [JsonProperty(PropertyName = "attributes")]
        public SasDefinitionAttributes SasDefinitionAttributes { get; set; }

        /// <summary>
        /// Gets or sets application specific metadata in the form of key-value
        /// pairs.
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IDictionary<string, string> Tags { get; set; }

    }
}
