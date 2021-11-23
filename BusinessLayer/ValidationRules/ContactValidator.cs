using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).EmailAddress().WithMessage("Mail adresi boş veya uygun formatta değil");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu kısmı boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girişi yapınız");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("50 karakterden fazla değer girişi yapılamaz");
            RuleFor(x => x.Message).MinimumLength(10).WithMessage("Lütfen en az 10 karakter girişi yapınız");


        }
    }
}
