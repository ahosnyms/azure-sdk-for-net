// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Models
{
    using System.Linq;

    /// <summary>
    /// The base backup engine class. All workload specific backup engines
    /// derive from this class.
    /// </summary>
    public partial class BackupEngineBase
    {
        /// <summary>
        /// Initializes a new instance of the BackupEngineBase class.
        /// </summary>
        public BackupEngineBase() { }

        /// <summary>
        /// Initializes a new instance of the BackupEngineBase class.
        /// </summary>
        /// <param name="friendlyName">Friendly name of the backup
        /// engine.</param>
        /// <param name="backupManagementType">Type of backup management for
        /// the backup engine. Possible values include: 'Invalid',
        /// 'AzureIaasVM', 'MAB', 'DPM', 'AzureBackupServer',
        /// 'AzureSql'</param>
        /// <param name="registrationStatus">Registration status of the backup
        /// engine with the Recovery Services Vault.</param>
        /// <param name="healthStatus">Backup status of the backup
        /// engine.</param>
        /// <param name="canReRegister">Flag indicating if the backup engine
        /// be registered, once already registered.</param>
        /// <param name="backupEngineId">ID of the backup engine.</param>
        public BackupEngineBase(string friendlyName = default(string), BackupManagementType? backupManagementType = default(BackupManagementType?), string registrationStatus = default(string), string healthStatus = default(string), bool? canReRegister = default(bool?), string backupEngineId = default(string))
        {
            FriendlyName = friendlyName;
            BackupManagementType = backupManagementType;
            RegistrationStatus = registrationStatus;
            HealthStatus = healthStatus;
            CanReRegister = canReRegister;
            BackupEngineId = backupEngineId;
        }

        /// <summary>
        /// Gets or sets friendly name of the backup engine.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "friendlyName")]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets type of backup management for the backup engine.
        /// Possible values include: 'Invalid', 'AzureIaasVM', 'MAB', 'DPM',
        /// 'AzureBackupServer', 'AzureSql'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "backupManagementType")]
        public BackupManagementType? BackupManagementType { get; set; }

        /// <summary>
        /// Gets or sets registration status of the backup engine with the
        /// Recovery Services Vault.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "registrationStatus")]
        public string RegistrationStatus { get; set; }

        /// <summary>
        /// Gets or sets backup status of the backup engine.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "healthStatus")]
        public string HealthStatus { get; set; }

        /// <summary>
        /// Gets or sets flag indicating if the backup engine be registered,
        /// once already registered.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "canReRegister")]
        public bool? CanReRegister { get; set; }

        /// <summary>
        /// Gets or sets ID of the backup engine.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "backupEngineId")]
        public string BackupEngineId { get; set; }

    }
}
