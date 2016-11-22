// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Models
{
    using System.Linq;

    /// <summary>
    /// Yearly retention schedule.
    /// </summary>
    public partial class YearlyRetentionSchedule
    {
        /// <summary>
        /// Initializes a new instance of the YearlyRetentionSchedule class.
        /// </summary>
        public YearlyRetentionSchedule() { }

        /// <summary>
        /// Initializes a new instance of the YearlyRetentionSchedule class.
        /// </summary>
        /// <param name="retentionScheduleFormatType">Retention schedule
        /// format for yearly retention policy. Possible values include:
        /// 'Invalid', 'Daily', 'Weekly'</param>
        /// <param name="monthsOfYear">List of months of year of yearly
        /// retention policy.</param>
        /// <param name="retentionScheduleDaily">Daily retention format for
        /// yearly retention policy.</param>
        /// <param name="retentionScheduleWeekly">Weekly retention format for
        /// yearly retention policy.</param>
        /// <param name="retentionTimes">Retention times of retention
        /// policy.</param>
        /// <param name="retentionDuration">Retention duration of retention
        /// Policy.</param>
        public YearlyRetentionSchedule(RetentionScheduleFormat? retentionScheduleFormatType = default(RetentionScheduleFormat?), System.Collections.Generic.IList<MonthOfYear?> monthsOfYear = default(System.Collections.Generic.IList<MonthOfYear?>), DailyRetentionFormat retentionScheduleDaily = default(DailyRetentionFormat), WeeklyRetentionFormat retentionScheduleWeekly = default(WeeklyRetentionFormat), System.Collections.Generic.IList<System.DateTime?> retentionTimes = default(System.Collections.Generic.IList<System.DateTime?>), RetentionDuration retentionDuration = default(RetentionDuration))
        {
            RetentionScheduleFormatType = retentionScheduleFormatType;
            MonthsOfYear = monthsOfYear;
            RetentionScheduleDaily = retentionScheduleDaily;
            RetentionScheduleWeekly = retentionScheduleWeekly;
            RetentionTimes = retentionTimes;
            RetentionDuration = retentionDuration;
        }

        /// <summary>
        /// Gets or sets retention schedule format for yearly retention
        /// policy. Possible values include: 'Invalid', 'Daily', 'Weekly'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "retentionScheduleFormatType")]
        public RetentionScheduleFormat? RetentionScheduleFormatType { get; set; }

        /// <summary>
        /// Gets or sets list of months of year of yearly retention policy.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "monthsOfYear")]
        public System.Collections.Generic.IList<MonthOfYear?> MonthsOfYear { get; set; }

        /// <summary>
        /// Gets or sets daily retention format for yearly retention policy.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "retentionScheduleDaily")]
        public DailyRetentionFormat RetentionScheduleDaily { get; set; }

        /// <summary>
        /// Gets or sets weekly retention format for yearly retention policy.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "retentionScheduleWeekly")]
        public WeeklyRetentionFormat RetentionScheduleWeekly { get; set; }

        /// <summary>
        /// Gets or sets retention times of retention policy.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "retentionTimes")]
        public System.Collections.Generic.IList<System.DateTime?> RetentionTimes { get; set; }

        /// <summary>
        /// Gets or sets retention duration of retention Policy.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "retentionDuration")]
        public RetentionDuration RetentionDuration { get; set; }

    }
}
