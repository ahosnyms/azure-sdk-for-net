// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Models
{
    using System.Linq;

    /// <summary>
    /// IaaS VM workload-specific backup item representing the Classic Compute
    /// VM.
    /// </summary>
    [Newtonsoft.Json.JsonObject("Microsoft.ClassicCompute/virtualMachines")]
    public partial class AzureIaaSClassicComputeVMProtectableItem : IaaSVMProtectableItem
    {
        /// <summary>
        /// Initializes a new instance of the
        /// AzureIaaSClassicComputeVMProtectableItem class.
        /// </summary>
        public AzureIaaSClassicComputeVMProtectableItem() { }

        /// <summary>
        /// Initializes a new instance of the
        /// AzureIaaSClassicComputeVMProtectableItem class.
        /// </summary>
        /// <param name="backupManagementType">Type of backup managemenent to
        /// backup an item.</param>
        /// <param name="friendlyName">Friendly name of the backup
        /// item.</param>
        /// <param name="protectionState">State of the back up item. Possible
        /// values include: 'Invalid', 'NotProtected', 'Protecting',
        /// 'Protected'</param>
        /// <param name="virtualMachineId">Fully qualified ARM ID of the
        /// virtual machine.</param>
        public AzureIaaSClassicComputeVMProtectableItem(string backupManagementType = default(string), string friendlyName = default(string), ProtectionStatus? protectionState = default(ProtectionStatus?), string virtualMachineId = default(string))
            : base(backupManagementType, friendlyName, protectionState, virtualMachineId)
        {
        }

    }
}
