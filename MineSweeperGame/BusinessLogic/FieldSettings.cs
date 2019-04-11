using MineSweeperGame.Interfaces;

namespace MineSweeperGame.BusinessLogic
{
    /// <summary>
    /// Model that contains the settings of a mine field
    /// </summary>
    public class FieldSettings : IFieldSettings
    {
        public int FieldId { get; set ; }
        public int RowsNo { get; set; }
        public int ColumnsNo { get; set; }
        public int MinesNo { get; set ; }
    }
}
