Imports System.IO
Imports System.Data.OleDb
Public Class Form1
    Public currentUser As String
    Public currentPriv As String
    Public defaultUser As String = "admin"
    Public defaultPass As String = "admin"

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
        Dim cmd As OleDbCommand = New OleDbCommand("Select * FROM [userList] WHERE [username] = '" & TextBox1.Text & "' AND [password] = '" & TextBox2.Text & "' ", myConnection)
        Dim dr As OleDbDataReader = cmd.ExecuteReader

        Dim userDB As String = ""
        Dim passDB As String = ""
        Dim privDB As String = ""
        While dr.Read
            userDB = dr("username").ToString
            passDB = dr("password").ToString
            privDB = dr("privilege").ToString
        End While
        myConnection.Close()

        If userPrompt = defaultUser And passPrompt = defaultPass Then
            currentUser = defaultUser
            MsgBox("Hello " + currentUser)
            Form3.Show()
        ElseIf userPrompt = userDB And passPrompt = passDB Then
            currentUser = userDB
            currentPriv = privDB
            MsgBox("Hello " + currentUser)
            Form3.Show()
        Else
            MsgBox("invalid credentials")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form2.Show()
    End Sub
End Class
