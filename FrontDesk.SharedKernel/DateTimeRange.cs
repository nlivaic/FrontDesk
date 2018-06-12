using System;

namespace FrontDesk.SharedKernel {
    public class DateTimeRange {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public DateTimeRange(DateTime startDate, DateTime endDate) {
            if (startDate < endDate)
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
    }
}