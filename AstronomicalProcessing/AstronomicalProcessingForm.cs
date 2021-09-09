using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// C Sharp 1 Assessment 2
// James Boyd, Team Elljam, Sprint Number One
// Date: 09/09/2021
// Version 1.0 (Fill, Search and Sort functions implemented)
// Astronomical Processing
//
// Explanation: A program for a local observatory that stores the number of neutrino
// interactions per hour as integer values in an array of size 24. This forms-based 
// GUI application displays the data in a list box and uses text boxes and buttons for processing.
//
// Functionality: User can add/remove/edit data using a textbox for input. Data can be
// sorted or searched. An option to randomly generate data with a button press is included


namespace AstronomicalProcessing
{
    public partial class AstronomicalProcessingForm : Form
    {
        public AstronomicalProcessingForm()
        {
            InitializeComponent();
        }
        // Creating array to hold 24 integers
        static int max = 24;
        int[] astroArray = new int[max];
        Random rnd = new Random();

        #region Add/Remove/Edit
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            // TODO: Enable user to add item to the array
            // Add error trapping to ensure user enters an integer
            // Status strip message confirming item added/telling user to type valid integer
            // Button tooltip: "Enter an item to add it to the list"
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            // TODO: Enable user to click an item in Listbox or enter item in Textbox
            // Ask user for confirmation with DialogResult delRecord MessageBox code
            // Remove that item from the array
            // Add error trapping to ensure user enters integer
            // Status strip message confirming item deletion/telling user to enter valid item
            // Button tooltip: "Select an item to delete"
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            // TODO: Enable user to click an item in Listbox
            // User will enter new number in textbox, click Edit button, item will be updated
            // DialogResult confirmation required before editing
            // Add error trapping to ensure user has clicked on an item
            // Button tooltip: "Select an item to edit"

        }
        #endregion

        #region Sort/Search
        // Calls Bubble Sort algorithm to sort array and display in Listbox
        private void ButtonSort_Click(object sender, EventArgs e)
        {
            SortArray();
            DisplayArray();
        }

        // Bubble Sort algorithm
        private void SortArray()
        {
            // TODO: Add error trapping (make sure list isn't empty before Sort is clicked)
            for (int i = 0; i < max; i++)
            {
                for (int j = i + 1; j < max; j++)
                {
                    if (astroArray[i] > astroArray[j])
                    {
                        int temp = astroArray[i];
                        astroArray[i] = astroArray[j];
                        astroArray[j] = temp;
                    }
                }
            }
        }

        // Searches for a target using Binary Search algorithm
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            // TODO: Add error trapping (make sure user can't enter string/double/etc)
            // TODO: Add useful error/feedback messages in status strip
            
            SortArray();
            DisplayArray();
            Int32.TryParse(TextBoxInput.Text, out int target);
            int lowBound = 0;
            int highBound = max - 1;
            int mid = 0;
            bool found = false;

            while (lowBound <= highBound)
            {
                mid = (lowBound + highBound) / 2;
                if (target == astroArray[mid])
                {
                    found = true;
                    break;
                }
                else if (target > astroArray[mid])
                {
                    lowBound = mid + 1;
                }
                else
                {
                    highBound = mid - 1;
                }
            }

            if(found)
            {
                // clear textbox
                // highlight search target in listbox
                // display "found at index __" in status strip
                StripStatus.Text = "Found";
            }
            else
            {
                // clear textbox
                // display "item not found" in status strip
            }
        }
        #endregion

        #region Utilities
        // Fills astroArray with 24 randomly generated integers between 10 and 99
        private void ButtonFill_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < max; x++)
            {
                astroArray[x] = rnd.Next(10, 99);
            }
            DisplayArray();
        }

        // Displays array in Listbox
        private void DisplayArray()
        {
            ListBoxOutput.Items.Clear();
            for (int y = 0; y < max; y++)
            {
                ListBoxOutput.Items.Add(astroArray[y]);
            }
        }
        #endregion
    }
}
