Imports System.IO
Imports System.Data.OleDb
Public Class Form2
    Dim provider As String
    Dim dataFile As String
    Dim conString As String
    Dim myConnection As OleDbConnection = New OleDbConnection

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim userPrompt As String = TextBox1.Text
        Dim passPrompt As String = TextBox2.Text
        provider = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
        dataFile = "../../db/userDB.accdb"
        conString = provider & dataFile
        myConnection.ConnectionString = conString
        myConnection.Open()
    End Sub
End Class