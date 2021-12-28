﻿using FluentValidation;

namespace FrwkBootCampFidelidade.DTO.PromotionContext
{
    public class PromotionCreateValidator: AbstractValidator<PromotionCreateDTO>
    {
        public PromotionCreateValidator()
        {
            RuleFor(x => x.Active)
                .NotNull()
                .NotEmpty()
                .WithMessage("Active é obrigatório.");

            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("UserId é obrigatório.");

            RuleFor(x => x.DrugstoreId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("DrugstoreId é obrigatório.");

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("Description é obrigatório.");

            RuleFor(x => x.StartDate)
                .NotNull()
                .NotEmpty()
                .WithMessage("StartDate é obrigatório.");

            RuleFor(x => x.EndDate)
                .NotNull()
                .NotEmpty()
                .WithMessage("StartDate é obrigatório.");
        }
    }
}
