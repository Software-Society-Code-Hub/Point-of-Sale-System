Imports System.IO
Imports System.Data.OleDb
Public Class Form4
    Dim provider As String
    Dim dataFile As String
    Dim conString As String
    Dim myConnection As OleDbConnection = New OleDbConnection

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        provider = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
        dataFile = "../../db/itemDB.accdb"
        conString = provider & dataFile
        myConnection.ConnectionString = conString
        myConnection.Open()

        Dim insertcmd As String = "INSERT INTO itemList([Product BarCode], [Product Name], [Product Type], [Price], [Quantity]) Values (?, ?, ?, ?, ?)"
        Dim cmd As OleDbCommand = New OleDbCommand(insertcmd, myConnection)
        cmd.Parameters.Add(New OleDbParameter("Product BarCode", CType(TextBox1.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Product Name", CType(TextBox2.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Product Type", CType(TextBox3.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Price", CType(TextBox4.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Quantity", CType(TextBox5.Text, String)))

        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myConnection.Close()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            MsgBox("Item created")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class