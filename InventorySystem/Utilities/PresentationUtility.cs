using SharedUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem.Utilities
{
    internal class PresentationUtility
    {

        /// <summary>
        /// Sets column widths and headers for a DataGridView.
        /// </summary>
        public static void SetDataGridViewColumns(DataGridView dgv, Dictionary<int, (string header, int width)> columnSettings)
        {
            foreach (var setting in columnSettings)
            {
                if (setting.Key < dgv.Columns.Count)
                {
                    dgv.Columns[setting.Key].HeaderText = setting.Value.header;
                    dgv.Columns[setting.Key].Width = setting.Value.width;
                }
            }
        }


        public static void ApplyFilter(DataTable dataTable, string filterColumn, string filterValue)
        {
            if (dataTable == null) return;

            // Reset filters if nothing is selected or filter value is empty
            if (string.IsNullOrWhiteSpace(filterValue) || filterColumn == "None")
            {
                dataTable.DefaultView.RowFilter = "";
                return;
            }

            // Apply filter based on data type
            if (filterColumn == "EmployeeID")
            {
                // Ensure valid number input
                if (int.TryParse(filterValue.Trim(), out _))
                {
                    dataTable.DefaultView.RowFilter = $"[{filterColumn}] = {filterValue.Trim()}";
                }
                else
                {
                    dataTable.DefaultView.RowFilter = "";
                }
            }
            else
            {
                // Handle string filtering safely
                dataTable.DefaultView.RowFilter = $"[{filterColumn}] LIKE '{filterValue.Trim().Replace("'", "''")}%'";
            }
        }

        public static void ApplyIsActiveFilter(DataTable dataTable, string filterValue, out string recordCount)
        {
            if (dataTable == null)
            {
                recordCount = "0";
                return;
            }

            string filterColumn = "IsActive";

            // Handle "All" case first
            if (filterValue == "All")
            {
                dataTable.DefaultView.RowFilter = "";
            }
            else
            {
                // Mapping user-friendly values to database values
                Dictionary<string, string> filterMap = new Dictionary<string, string>
                {
                    { "Yes", "1" },
                    { "No", "0" }
                };

                // Convert user-friendly value to database value
                if (filterMap.TryGetValue(filterValue, out string mappedValue))
                {
                    filterValue = mappedValue;
                }

                // Apply filter
                dataTable.DefaultView.RowFilter = $"[{filterColumn}] = {filterValue}";
            }

            // Update record count
            recordCount = dataTable.DefaultView.Count.ToString();
        }


        public static void ApplyMoneyFilter(DataTable dataTable, string filterColumn, string filterValue, string operation, out string recordCount)
        {
            recordCount = "0";

            if (dataTable == null || string.IsNullOrWhiteSpace(filterValue))
            {
                // Reset filter if input is empty
                dataTable.DefaultView.RowFilter = string.Empty;
                recordCount = dataTable.DefaultView.Count.ToString();
                return;
            }

            if (!float.TryParse(filterValue, out float parsedValue))
            {
                MessageBox.Show("Please enter a valid numeric value for the filter.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mapping user-friendly values to database operators
            Dictionary<string, string> filterMap = new Dictionary<string, string>
            {
                { "Equals", "=" },
                { "Bigger Than", ">" },
                { "Smaller Than", "<" }
            };

            // Convert user-friendly text to an actual SQL operator
            if (!filterMap.TryGetValue(operation, out string mappedOperator))
            {
                MessageBox.Show("Invalid operation selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Properly format the filter to prevent errors
            string formattedFilter = $"[{filterColumn}] {mappedOperator} {parsedValue}";

            try
            {
                // Apply filter
                dataTable.DefaultView.RowFilter = formattedFilter;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying filter: {ex.Message}", "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update record count
            recordCount = dataTable.DefaultView.Count.ToString();
        }

        public static void ValidateEmptyTextBox(object sender, ErrorProvider errorProvider, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(textBox, ValidationMessages.Error_RequiredField);
            }
            else
            {
                e.Cancel = false; // Ensure the cancel flag is reset if validation passes
                errorProvider.SetError(textBox, null); // Clear the error
            }
        }

        public static void ValidateEmail(object sender, ErrorProvider errorProvider, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Validate email format
            if (!Validation.ValidateEmail(textBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBox, ValidationMessages.Error_InvalidEmail);
            }
            else
            {
                e.Cancel = false; // Ensure the cancel flag is reset if validation passes
                errorProvider.SetError(textBox, null); // Clear the error
            }
        }


        public static void ValidatePhone(object sender, ErrorProvider errorProvider, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!Validation.IsValidPhone(textBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBox, ValidationMessages.Error_InvalidPhone);
            }
            else
            {
                e.Cancel = false; // Ensure the cancel flag is reset if validation passes
                errorProvider.SetError(textBox, null); // Clear the error
            }
        }

        // validate the salary of text box 
        public static void ValidateSalary(object sender, ErrorProvider errorProvider, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!Validation.IsValidSalary(textBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBox, ValidationMessages.Error_InvalidSalary);
            }
            else
            {
                e.Cancel = false; // Ensure the cancel flag is reset if validation passes
                errorProvider.SetError(textBox, null); // Clear the error
            }
        }

        public static void ValidateModifiedDate(DateTimePicker dtpCreatedDate, DateTimePicker dtpModifiedDate, ErrorProvider errorProvider, CancelEventArgs e)
        {
            if (dtpCreatedDate.Value > dtpModifiedDate.Value) // Created Date is AFTER Modified Date
            {
                errorProvider.SetError(dtpModifiedDate, "Modified Date cannot be earlier than Created Date.");
                e.Cancel = true; // Prevents losing focus
                dtpModifiedDate.Focus();
            }
            else
            {
                errorProvider.SetError(dtpModifiedDate, ""); // Clears the error if validation passes
            }
        }

        public static void ValidateCreationDate(DateTimePicker dtpCreatedDate, DateTimePicker dtpModifiedDate, ErrorProvider errorProvider, CancelEventArgs e)
        {
            if (dtpCreatedDate.Value > dtpModifiedDate.Value) // Created Date is AFTER Modified Date
            {
                errorProvider.SetError(dtpCreatedDate, "Created Date cannot be later than Modified Date.");
                e.Cancel = true; // Prevents losing focus
                dtpCreatedDate.Focus();
            }
            else
            {
                errorProvider.SetError(dtpCreatedDate, ""); // Clears the error if validation passes
            }
        }

        public static void ValidateNotesIsLessThan250Char(object sender, ErrorProvider errorProvider, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (textBox.Text.Length > 250)
                {
                    errorProvider.SetError(textBox, "Notes should not exceed 250 characters.");
                    e.Cancel = true; // Prevent focus change
                }
                else
                {
                    errorProvider.SetError(textBox, ""); // Clear error
                }
            }
        }




    }
}
