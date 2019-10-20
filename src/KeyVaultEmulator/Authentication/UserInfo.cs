using System;
using System.Runtime.Serialization;

namespace AzureKeyVaultEmulator.Authentication
{
    /// <summary>
    /// Contains information of a single user. This information is used for token cache lookup. Also if created with userId, userId is sent to the service when login_hint is accepted.
    /// </summary>
    [DataContract]
    public sealed class UserInfo
    {
        /// <summary>
        /// Create user information for token cache lookup
        /// </summary>
        public UserInfo()
        {
        }

        /// <summary>
        /// Create user information for token cache lookup
        /// </summary>
        internal UserInfo(AdalUserInfo adalUserInfo) : this(adalUserInfo?.UniqueId, adalUserInfo?.DisplayableId,
            adalUserInfo?.GivenName, adalUserInfo?.FamilyName, adalUserInfo?.IdentityProvider,
            adalUserInfo?.PasswordChangeUrl, adalUserInfo?.PasswordExpiresOn)
        {
        }

        /// <summary>
        /// Create user information copied from another UserInfo object
        /// </summary>
        public UserInfo(UserInfo other) : this(other?.UniqueId, other?.DisplayableId, other?.GivenName,
            other?.FamilyName, other?.IdentityProvider, other?.PasswordChangeUrl, other?.PasswordExpiresOn)
        {
        }

        private UserInfo(string uniqueId, string displayableId, string givenName, string familyName,
            string identityProvider, Uri passwordChangeUrl, DateTimeOffset? passwordExpiresOn)
        {
            this.UniqueId = uniqueId;
            this.DisplayableId = displayableId;
            this.GivenName = givenName;
            this.FamilyName = familyName;
            this.IdentityProvider = identityProvider;
            this.PasswordChangeUrl = passwordChangeUrl;
            this.PasswordExpiresOn = passwordExpiresOn;
        }

        /// <summary>
        /// Gets identifier of the user authenticated during token acquisition. 
        /// </summary>
        [DataMember]
        public string UniqueId { get; internal set; }

        /// <summary>
        /// Gets a displayable value in UserPrincipalName (UPN) format. The value can be null.
        /// </summary>
        [DataMember]
        public string DisplayableId { get; internal set; }

        /// <summary>
        /// Gets given name of the user if provided by the service. If not, the value is null. 
        /// </summary>
        [DataMember]
        public string GivenName { get; internal set; }

        /// <summary>
        /// Gets family name of the user if provided by the service. If not, the value is null. 
        /// </summary>
        [DataMember]
        public string FamilyName { get; internal set; }

        /// <summary>
        /// Gets the time when the password expires. Default value is 0.
        /// </summary>
        [DataMember]
        public DateTimeOffset? PasswordExpiresOn { get; internal set; }

        /// <summary>
        /// Gets the url where the user can change the expiring password. The value can be null.
        /// </summary>
        [DataMember]
        public Uri PasswordChangeUrl { get; internal set; }

        /// <summary>
        /// Gets identity provider if returned by the service. If not, the value is null. 
        /// </summary>
        [DataMember]
        public string IdentityProvider { get; internal set; }
    }
}