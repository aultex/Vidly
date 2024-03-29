﻿using System.ComponentModel.DataAnnotations;
using Vidly.Dtos;

namespace Vidly.Models
{
    public class Min18YearsIfAMember: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var customer = (CustomerDto)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipTypes.Unknown || customer.MembershipTypeId == MembershipTypes.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be atleast 18 years old to go on a membership");

            //return base.IsValid(value, validationContext);
        }
    }
}
