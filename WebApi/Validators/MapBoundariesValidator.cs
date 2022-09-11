using Core.ViewModels;
using FluentValidation;

namespace WebApi.Validators;

public class MapBoundariesValidator : AbstractValidator<MapBoundaries>
{
    public MapBoundariesValidator()
    {
        RuleFor(c => c.South)
            .GreaterThanOrEqualTo(-90)
            .WithMessage("Latitude(South) must be greater than -90 deg.")
            .LessThanOrEqualTo(90)
            .WithMessage("Latitude(South) must be less than +90 deg.");
        
        RuleFor(c => c.North)
            .GreaterThanOrEqualTo(-90)
            .WithMessage("Latitude(North) must be greater than -90 deg.")
            .LessThanOrEqualTo(90)
            .WithMessage("Latitude(North) must be less than +90 deg.");
        
        RuleFor(c => c.East)
            .GreaterThanOrEqualTo(-180)
            .WithMessage("Longitude(East) must be greater than -180 deg.")
            .LessThanOrEqualTo(180)
            .WithMessage("Longitude(East) must be less than 180 deg.");
        
        RuleFor(c => c.West)
            .GreaterThanOrEqualTo(-180)
            .WithMessage("Longitude(West) must be greater than -180 deg.")
            .LessThanOrEqualTo(180)
            .WithMessage("Longitude(West) must be less than 180 deg.");
    }
}