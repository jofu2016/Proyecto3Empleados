//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoEmpleados.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empleados
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> HorasNormales { get; set; }
        public Nullable<int> HorasExtras { get; set; }
        public Nullable<decimal> SalarioBruto { get; set; }
        public Nullable<decimal> Deducciones { get; set; }
        public Nullable<decimal> SalarioNeto { get; set; }
    }
}
