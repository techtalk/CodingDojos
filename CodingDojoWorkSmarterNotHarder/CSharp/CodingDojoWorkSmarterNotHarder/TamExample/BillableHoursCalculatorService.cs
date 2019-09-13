//using System;
//using System.Collections.Generic;

//namespace CodingDojoWorkSmarterNotHarder.TamExample
//{
//    public class BillableHoursCalculatorService
//    {
//        private readonly MinutesToHoursConvertingService _minutesToHoursConvertingService;

//        public BillableHoursCalculatorService(MinutesToHoursConvertingService minutesToHoursConvertingService)
//        {
//            _minutesToHoursConvertingService = minutesToHoursConvertingService;
//        }

//        public BillableHoursResult Calculate(IEnumerable<TamBooking> bookings)
//        {
//            var workingMinutes = 0m;
//            var billableMinutes = 0m;
//            var nonBillableMinutes = 0m;

//            foreach (var tamBooking in bookings)
//            {
//                workingMinutes += tamBooking.Minutes;

//                if (tamBooking.Billable)
//                {
//                    billableMinutes += tamBooking.Minutes;
//                }
//                else
//                {
//                    nonBillableMinutes += tamBooking.Minutes;
//                }
//            }

//            var result = new BillableHoursResult
//            {
//                WorkingHoursPercent = 1m
//            };

//            if (workingMinutes == 0)
//            {
//                result.WorkingHours = 0m;
//                result.BillableHours = 0m;
//                result.BillableHoursPercent = 1m;
//                result.NonBillableHours = 0m;
//                result.NonBillableHoursPercent = 1m;
//            }
//            else
//            {
//                result.WorkingHours = _minutesToHoursConvertingService.Convert(workingMinutes);
//                result.BillableHours = _minutesToHoursConvertingService.Convert(billableMinutes);
//                result.NonBillableHours = _minutesToHoursConvertingService.Convert(nonBillableMinutes);
//                result.BillableHoursPercent = Math.Round(billableMinutes / workingMinutes, 4);
//                result.BillableHoursPercent = Math.Round(nonBillableMinutes / workingMinutes, 4);
//            }

//            return result;
//        }
//    }
//}
