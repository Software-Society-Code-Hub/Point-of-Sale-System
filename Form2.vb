Imports System.IO
Imports System.Data.OleDb
Public Class Form2
    Dim provider As String
    Dim dataFile As String
    Dim conString As String
    Dim myConnection As OleDbConnection = New OleDbConnection

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        provider = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
        dataFile = "../../db/userDB.accdb"
        conString = provider & dataFile
        myConnection.ConnectionString = conString
        myConnection.Open()

        Dim insertcmd As String = "INSERT INTO userList([username], [password], [privilege]) Values (?, ?, ?)"
        Dim cmd As OleDbCommand = New OleDbCommand(insertcmd, myConnection)
        cmd.Parameters.Add(New OleDbParameter("username", CType(TextBox1.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("password", CType(TextBox2.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("privilege", CType(TextBox3.Text, String)))

        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myConnection.Close()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            MsgBox("Account created")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class