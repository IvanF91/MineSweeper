
GO
-- Create the table in the specified schema
CREATE TABLE dbo.FieldSettings
(
   FieldId      INT  NOT NULL   PRIMARY KEY, -- primary key column
   RowsNo		INT  NOT NULL,
   ColumnsNo	INT  NOT NULL,
   MinesNo		INT  NOT NULL
);
GO