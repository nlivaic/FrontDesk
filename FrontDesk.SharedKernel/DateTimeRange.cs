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

        public bool IsOnDate(DateTime targetDate)
        {
            return StartDate >= targetDate.Date && EndDate < targetDate.Date.AddDays(1);
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}", StartDate.ToString(), EndDate.ToString());
        }
    }
}