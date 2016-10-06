using PrideTek.Shell.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.TheOne.Maintenance.Data
{
    public class Entity : NotificationObject
    {
        [NotMapped]
        public bool IsDirty { get; set; }
        
        protected override bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            var result = base.SetField<T>(ref field, value);
            IsDirty = IsDirty || result;
            return result;
        }
    }
}
