Imports System.IO
Imports System.Data.OleDb
Public Class Form3
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Public currentUser As String = Form1.currentUser
    Public currentPriv As String = Form1.currentPriv

    Dim provider As String
    Dim dataFile As String
    Dim conString As String
    Dim myConnection As OleDbConnection = New OleDbConnection


End Class