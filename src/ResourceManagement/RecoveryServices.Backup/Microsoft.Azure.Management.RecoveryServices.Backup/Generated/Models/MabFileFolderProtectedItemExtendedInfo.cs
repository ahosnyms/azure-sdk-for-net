// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Models
{
    using System.Linq;

    /// <summary>
    /// Additional information on the backed up item.
    /// </summary>
    public partial class MabFileFolderProtectedItemExtendedInfo
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MabFileFolderProtectedItemExtendedInfo class.
        /// </summary>
        public MabFileFolderProtectedItemExtendedInfo() { }

        /// <summary>
        /// Initializes a new instance of the
        /// MabFileFolderProtectedItemExtendedInfo class.
        /// </summary>
        /// <param name="lastRefreshedAt">Last time when the agent data synced
        /// to service.</param>
        /// <param name="oldestRecoveryPoint">The oldest backup copy
        /// available.</param>
        /// <param name="recoveryPointCount">Number of backup copies
        /// associated with the backup item.</param>
        public MabFileFolderProtectedItemExtendedInfo(System.DateTime? lastRefreshedAt = default(System.DateTime?), System.DateTime? oldestRecoveryPoint = default(System.DateTime?), int? recoveryPointCount = default(int?))
        {
            LastRefreshedAt = lastRefreshedAt;
            OldestRecoveryPoint = oldestRecoveryPoint;
            RecoveryPointCount = recoveryPointCount;
        }

        /// <summary>
        /// Gets or sets last time when the agent data synced to service.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "lastRefreshedAt")]
        public System.DateTime? LastRefreshedAt { get; set; }

        /// <summary>
        /// Gets or sets the oldest backup copy available.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "oldestRecoveryPoint")]
        public System.DateTime? OldestRecoveryPoint { get; set; }

        /// <summary>
        /// Gets or sets number of backup copies associated with the backup
        /// item.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "recoveryPointCount")]
        public int? RecoveryPointCount { get; set; }

    }
}
