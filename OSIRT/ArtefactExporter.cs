using OSIRT.Enums;
using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT
{
    public class ArtefactExporter
    {

        private string exportPath;
        private string reportContainerName;
        private DataTable table;


        public ArtefactExporter(DataTable table, string exportPath, string reportContainerName)
        {
            this.exportPath = exportPath;
            this.reportContainerName = reportContainerName;
            this.table = table;

            GenerateArtefactDirectories();
            ExportArtefacts();
        }

        private void GenerateArtefactDirectories()
        {
            List<string> directories = Constants.Directories.GetCaseDirectories();
            foreach (string directory in directories)
            {
                Directory.CreateDirectory(Path.Combine($"{exportPath}", reportContainerName, Constants.Artefacts, directory));
            }
        }

        private void ExportArtefacts()
        {
            string columnName;

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    string cellValue = row[column] != null ? row[column].ToString() : "";
                    columnName = column.ColumnName;

                    if (columnName == "note" && !UserSettings.Load().PrintAuditNotes) continue;

                    if (columnName == "file" && table.TableName != "osirt_actions" && cellValue != "")
                    {
                        string rowAction = row["action"].ToString();
                        if (Path.HasExtension(cellValue) && rowAction != "Case Notes")
                        {
                            Actions action = (Actions)Enum.Parse(typeof(Actions), rowAction);
                            string location = Constants.Directories.GetSpecifiedCaseDirectory(action);
                            string sourceFile = Path.Combine(Constants.ContainerLocation, location, cellValue);
                            string relativePath = Path.Combine(Constants.Artefacts, location, cellValue);
                            string destination = Path.Combine($"{exportPath}", reportContainerName, relativePath);

                            File.Copy(sourceFile, destination, true);

                        }
                    }
                }

            }
        }

    }
}
