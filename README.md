# CRUD in CSharp (C#) and MySQL Database
This code is implementing a simple CRUD (Create, Read, Update, Delete) application in C# using MySQL as the database. The application is a Windows Forms application, and the code is defining the behavior of the buttons and data grid view on the form.

The code defines event handlers for the button click events that call the CREATE, READ, UPDATE, DELETE functions respectively. The READ function sets the data source for the data grid view to the data retrieved from the database using the Read_data method of the CRUD class.

The CREATE function retrieves data from the input text boxes on the form and calls the Create_data method of the CRUD class to create a new record in the database. The UPDATE and DELETE functions are similar to the CREATE function, but they call the Update_data and Delete_data methods of the CRUD class respectively to update or delete a record in the database.

The GET DATA function is an event handler for the dataGridView1_CellContentClick event. This function retrieves the data from the selected row in the data grid view and displays it in the input text boxes on the form.
