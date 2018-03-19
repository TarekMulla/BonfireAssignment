using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartLifeLtd.Data.Tables
{
    public class TableBase
    {
        public TableBase()
        {
            ID = Guid.NewGuid();
        }

        #region ID
        [Key]
        public virtual Guid ID
        {
            get;
            set;
        }
        #endregion

        #region Creation Date
        [Column(TypeName = "datetime2")]
        public virtual DateTime CreationDate
        {
            set; get;
        }
        #endregion

        [NotMapped]
        public virtual bool IsNew
        {
            get
            {
                return this.CreationDate == DateTime.MinValue;
            }
        }
    }
}
