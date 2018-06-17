using System;

namespace FrontDesk.SharedKernel {
    public class DateTimeRange : ValueObject<DateTimeRange> {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        
        public DateTimeRange(DateTime startDate, DateTime endDate) {
            if (startDate >= endDate)
            {
                throw new ArgumentException("Start date should be earlier than end date.");
            }
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
        
        public DateTimeRange(DateTime startDate, TimeSpan timeLength)
        {
            this.StartDate = startDate;
            this.EndDate = startDate.Add(timeLength);
        }

        /// <summary>
        /// Needed by EF Core.
        /// </summary>
        protected DateTimeRange() { }
    }
}