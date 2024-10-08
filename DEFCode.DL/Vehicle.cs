using DEFCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEFCode.DL
{
    public class Vehicle
    {
        // Value Types
        public DateTime? ReportDate { get; set; }
        public decimal TareWeight { get; set; }
        public decimal GrossWeight { get; set; }
        public int VehicleId { get; set; }

        public string PlateNumber { get; set; } = "";

        //reference type
        public VehicleType Type { get; set; }

        public double CalculateWeight(string tareWeightInput, string grossWeightInput)
        {
            if (string.IsNullOrWhiteSpace(tareWeightInput)) throw new ArgumentException("Please enter the tareweight");
            if (string.IsNullOrWhiteSpace(grossWeightInput)) throw new ArgumentException("Please enter the grossweight");

            var success = double.TryParse(tareWeightInput, out double tareweight);
            if (!success || tareweight < 0) throw new ArgumentException("The tareweight must be a number 0 or greater");

            success = double.TryParse(grossWeightInput, out double grossweight);
            if (!success || grossweight <= 0) throw new ArgumentException("The grossweight must be a number greater than 0");


            if (double.IsNaN(tareweight) || double.IsInfinity(tareweight)) { return 0.0; }
            if (grossweight < tareweight) { return 0.0; }

            double netweight = (grossweight - tareweight);

            return netweight;
        }


        public double CalculateWeightOverLoad(string tareWeightInput, string grossWeightInput)
        {
            if (string.IsNullOrWhiteSpace(tareWeightInput)) throw new ArgumentException("Please enter the tareweight");
            if (string.IsNullOrWhiteSpace(grossWeightInput)) throw new ArgumentException("Please enter the grossweight");

            var success = double.TryParse(tareWeightInput, out double tareweight);
            if (!success || tareweight < 0) throw new ArgumentException("The tareweight must be a number 0 or greater");

            success = double.TryParse(grossWeightInput, out double grossweight);
            if (!success || grossweight <= 0) throw new ArgumentException("The grossweight must be a number greater than 0");


            if (double.IsNaN(tareweight) || double.IsInfinity(tareweight)) { return 0.0; }
            if (grossweight < tareweight) { return 0.0; }

            return CalculateWeightOverLoad(tareweight, grossweight);

        }

        private double CalculateWeightOverLoad(double tareweight, double grossweight)
        {
            
            double netweight = (grossweight - tareweight);
            
            return netweight;

        }


        public bool ValidateReportDateV1(DateTime? reportDate)
        {

            if (!reportDate.HasValue) return false;

            if (reportDate.Value < DateTime.Now.AddDays(7)) return false;

            return true;
        }

        public bool ValidateReportDate(DateTime? reportDate)
        {

            if (!reportDate.HasValue)
                throw new ValidationException("Please enter the report date");

            if (reportDate.Value < DateTime.Now.AddDays(7))
                throw new BusinessRuleException("Date must be > 7 days from today");

            return true;

        }

        public Vehicle FindVehicleV1(List<Vehicle> vehicles, string plateNumber)
        {

            if (vehicles is null) return null;

            var foundVehicle = vehicles.Find(d => d.PlateNumber == plateNumber);

            return foundVehicle;

        }

        public Vehicle FindVehicle(List<Vehicle>? vehicles, string plateNumber)
        {

            if (vehicles is null)
                throw new ArgumentException("No vehicle found");

            var foundVehicle = vehicles.Find(d => d.PlateNumber == plateNumber);

            if (foundVehicle is null)
                throw new KeyNotFoundException("Vehicle not found");

            return foundVehicle;

        }

        public bool ValidateReportDateWithRef(DateTime? reportDate, ref string validationMessage)
        {

            if (!reportDate.HasValue)
            {
                validationMessage = "Date has no value";
                return false;
            };

            if (reportDate.Value < DateTime.Now.AddDays(7))
            {
                validationMessage = "Date must be at least 7 days from today";
                return false;
            }

            return true;

        }

        public bool ValidateReportDateWithOut(DateTime? reportDate, out string validationMessage)
        {

            validationMessage = "";
            if (!reportDate.HasValue)
            {
                validationMessage = "Date has no value";
                return false;
            };

            if (reportDate.Value < DateTime.Now.AddDays(7))
            {
                validationMessage = "Date must be at least 7 days from today";
                return false;
            }

            return true;

        }


        public (bool IsValid, string ValidationMessage) ValidateReportDateWithTuple(DateTime? reportDate)
        {

            if (!reportDate.HasValue) 
                return (IsValid: false, ValidationMessage: "Date has no value");

            if (reportDate.Value < DateTime.Now.AddDays(7)) 
                return (false, "Date must be at least 7 days from today");

            return (IsValid: true, ValidationMessage: "");
        }



        public OperationResult ValidateReportDateWithObject(DateTime? reportDate)
        {

            if (!reportDate.HasValue) return new OperationResult()
            { 
                Success = false, ValidationMessage = "Date has no value" 
            };

            if (reportDate.Value < DateTime.Now.AddDays(7)) return new OperationResult()
            { 
                Success = false, ValidationMessage = "Date must be at least 7 days from today" 
            };

            return new OperationResult() { Success = true };

        }  

    }
}
