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
    /// The attributes of a key managed by the key vault service.
    /// </summary>
    public partial class KeyAttributes : Attributes
    {
        /// <summary>
        /// Initializes a new instance of the KeyAttributes class.
        /// </summary>
        public KeyAttributes()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the KeyAttributes class.
        /// </summary>
        /// <param name="enabled">Determines whether the object is
        /// enabled.</param>
        /// <param name="notBefore">Not before date in UTC.</param>
        /// <param name="expires">Expiry date in UTC.</param>
        /// <param name="created">Creation time in UTC.</param>
        /// <param name="updated">Last updated time in UTC.</param>
        /// <param name="recoveryLevel">Reflects the deletion recovery level
        /// currently in effect for keys in the current vault. If it contains
        /// 'Purgeable' the key can be permanently deleted by a privileged
        /// user; otherwise, only the system can purge the key, at the end of
        /// the retention interval. Possible values include: 'Purgeable',
        /// 'Recoverable+Purgeable', 'Recoverable',
        /// 'Recoverable+ProtectedSubscription',
        /// 'CustomizedRecoverable+Purgeable', 'CustomizedRecoverable',
        /// 'CustomizedRecoverable+ProtectedSubscription'</param>
        public KeyAttributes(bool? enabled = default(bool?), System.DateTime? notBefore = default(System.DateTime?), System.DateTime? expires = default(System.DateTime?), System.DateTime? created = default(System.DateTime?), System.DateTime? updated = default(System.DateTime?), string recoveryLevel = default(string))
            : base(enabled, notBefore, expires, created, updated)
        {
            RecoveryLevel = recoveryLevel;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets reflects the deletion recovery level currently in effect for
        /// keys in the current vault. If it contains 'Purgeable' the key can
        /// be permanently deleted by a privileged user; otherwise, only the
        /// system can purge the key, at the end of the retention interval.
        /// Possible values include: 'Purgeable', 'Recoverable+Purgeable',
        /// 'Recoverable', 'Recoverable+ProtectedSubscription',
        /// 'CustomizedRecoverable+Purgeable', 'CustomizedRecoverable',
        /// 'CustomizedRecoverable+ProtectedSubscription'
        /// </summary>
        [JsonProperty(PropertyName = "recoveryLevel")]
        public string RecoveryLevel { get; private set; }

    }
}
