//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CustomLight.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Specification
    {
        public int Id { get; set; }
        public Nullable<int> Diameter { get; set; }
        public Nullable<int> Length { get; set; }
        public Nullable<int> Width { get; set; }
        public Nullable<int> Height { get; set; }
        public Nullable<int> Power { get; set; }
        public Nullable<int> LightOutput { get; set; }
        public double Price { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Updated { get; set; }
        public int Product_Id { get; set; }
    
        public virtual Product Product { get; set; }
    }
}