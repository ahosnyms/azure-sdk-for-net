// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.RecoveryServices.Backup
{
    using System.Threading.Tasks;
   using Microsoft.Rest.Azure;
   using Models;

    /// <summary>
    /// Extension methods for JobCancellationsOperations.
    /// </summary>
    public static partial class JobCancellationsOperationsExtensions
    {
            /// <summary>
            /// Cancels a job. This is an asynchronous operation. To know the status of
            /// the cancellation, call GetCancelOperationResult API.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='vaultName'>
            /// The name of the recovery services vault.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group where the recovery services vault is
            /// present.
            /// </param>
            /// <param name='jobName'>
            /// Name of the job to cancel.
            /// </param>
            public static void Trigger(this IJobCancellationsOperations operations, string vaultName, string resourceGroupName, string jobName)
            {
                System.Threading.Tasks.Task.Factory.StartNew(s => ((IJobCancellationsOperations)s).TriggerAsync(vaultName, resourceGroupName, jobName), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None,  System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Cancels a job. This is an asynchronous operation. To know the status of
            /// the cancellation, call GetCancelOperationResult API.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='vaultName'>
            /// The name of the recovery services vault.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group where the recovery services vault is
            /// present.
            /// </param>
            /// <param name='jobName'>
            /// Name of the job to cancel.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task TriggerAsync(this IJobCancellationsOperations operations, string vaultName, string resourceGroupName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                await operations.TriggerWithHttpMessagesAsync(vaultName, resourceGroupName, jobName, null, cancellationToken).ConfigureAwait(false);
            }

    }
}
