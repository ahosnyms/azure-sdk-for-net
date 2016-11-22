// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Models
{
    using System.Linq;

    /// <summary>
    /// IaaS VM workload-specific backup item representing the Azure Resource
    /// Manager VM.
    /// </summary>
    [Newtonsoft.Json.JsonObject("Microsoft.Compute/virtualMachines")]
    public partial class AzureIaaSComputeVMProtectedItem : AzureIaaSVMProtectedItem
    {
        /// <summary>
        /// Initializes a new instance of the AzureIaaSComputeVMProtectedItem
        /// class.
        /// </summary>
        public AzureIaaSComputeVMProtectedItem() { }

        /// <summary>
        /// Initializes a new instance of the AzureIaaSComputeVMProtectedItem
        /// class.
        /// </summary>
        /// <param name="backupManagementType">Type of backup managemenent for
        /// the backed up item. Possible values include: 'Invalid',
        /// 'AzureIaasVM', 'MAB', 'DPM', 'AzureBackupServer',
        /// 'AzureSql'</param>
        /// <param name="workloadType">Type of workload this item represents.
        /// Possible values include: 'Invalid', 'VM', 'FileFolder',
        /// 'AzureSqlDb', 'SQLDB', 'Exchange', 'Sharepoint',
        /// 'DPMUnknown'</param>
        /// <param name="sourceResourceId">ARM ID of the resource to be backed
        /// up.</param>
        /// <param name="policyId">ID of the backup policy with which this
        /// item is backed up.</param>
        /// <param name="lastRecoveryPoint">Timestamp when the last (latest)
        /// backup copy was created for this backup item.</param>
        /// <param name="friendlyName">Friendly name of the VM represented by
        /// this backup item.</param>
        /// <param name="virtualMachineId">Fully qualified ARM ID of the
        /// virtual machine represented by this item.</param>
        /// <param name="protectionStatus">Backup status of this backup
        /// item.</param>
        /// <param name="protectionState">Backup state of this backup item.
        /// Possible values include: 'Invalid', 'IRPending', 'Protected',
        /// 'ProtectionError', 'ProtectionStopped', 'ProtectionPaused'</param>
        /// <param name="lastBackupStatus">Last backup operation status.
        /// Possible values: Healthy, Unhealthy.</param>
        /// <param name="lastBackupTime">Timestamp of the last backup
        /// operation on this backup item.</param>
        /// <param name="extendedInfo">Additional information for this backup
        /// item.</param>
        public AzureIaaSComputeVMProtectedItem(BackupManagementType? backupManagementType = default(BackupManagementType?), DataSourceType? workloadType = default(DataSourceType?), string sourceResourceId = default(string), string policyId = default(string), System.DateTime? lastRecoveryPoint = default(System.DateTime?), string friendlyName = default(string), string virtualMachineId = default(string), string protectionStatus = default(string), ProtectionState? protectionState = default(ProtectionState?), string lastBackupStatus = default(string), System.DateTime? lastBackupTime = default(System.DateTime?), AzureIaaSVMProtectedItemExtendedInfo extendedInfo = default(AzureIaaSVMProtectedItemExtendedInfo))
            : base(backupManagementType, workloadType, sourceResourceId, policyId, lastRecoveryPoint, friendlyName, virtualMachineId, protectionStatus, protectionState, lastBackupStatus, lastBackupTime, extendedInfo)
        {
        }

    }
}
