//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkPlan.Base
{
    using System;
    using System.Collections.Generic;
    
    public partial class Applications
    {
        public int ID_application { get; set; }
        public Nullable<int> ID_goods { get; set; }
        public Nullable<int> Количество { get; set; }
        public Nullable<int> ID_status { get; set; }
        public Nullable<int> ID_department { get; set; }
    
        public virtual Departments Departments { get; set; }
        public virtual Goods Goods { get; set; }
        public virtual Status Status { get; set; }
    }
}
