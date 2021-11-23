using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı veya takma ad boş geçilemez.");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("20 karakterden fazla değer girişi yapılamaz.");
            //22.10.2021 22:08 sadece nick name kullanmak isteyenler için boş bıraktım daha sonradan kontrol eklenebılır.
            //  RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadı boş geçilemez.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmı boş geçilemez.");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Geçersiz e-posta formatı");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan kısmı boş geçilemez");
        }
    }
}
