using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperGame.Interfaces
{
    public interface IFieldSettings
    {
        int FieldId { get; set; }

        int RowsNo { get; set; }

        int ColumnsNo { get; set; }

        int MinesNo { get; set; }
    }
}
