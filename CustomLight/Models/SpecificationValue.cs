//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CustomLight.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SpecificationValue
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int ProductId { get; set; }
        public int SpecificationTitleId { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual SpecificationTitle SpecificationTitle { get; set; }
    }
}