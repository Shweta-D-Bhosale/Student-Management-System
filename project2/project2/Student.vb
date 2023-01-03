Imports System.Data.SqlClient
Imports System.Data
Public Class Student
    Dim str As String = ""
    Dim dr As SqlDataReader
    Dim rw As Integer = 0
    Dim cn As SqlConnection
    Dim cmd As SqlCommand

    Private Sub dgdata_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgdata.CellContentClick

    End Sub

    Private Sub btninsert_Click(sender As Object, e As EventArgs) Handles btninsert.Click
        If TextBox1.Text = "" Then
            MsgBox("Please Enter Student ID ")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Please Enter Student Name")
        ElseIf ComboBox1.Text = "" Then
            MsgBox("Please Enter Gender")
        ElseIf TextBox3.Text = "" Then
            MsgBox("Please Enter Phone Number")
        ElseIf TextBox4.Text = "" Then
            MsgBox("Please Enter Address")
        ElseIf TextBox1.Text And TextBox2.Text = "" Then
            MsgBox("Please Enter Student ID and Student Name")
        ElseIf TextBox1.Text And ComboBox1.Text = "" Then
            MsgBox("Plase Enter Student ID and and Gender")
        ElseIf TextBox1.Text And TextBox3.Text = "" Then
            MsgBox("Please Enter Student ID and Student Phone number")
        ElseIf TextBox1.Text And TextBox4.Text = "" Then
            MsgBox("Please Enter Student ID and Student Address")
        ElseIf TextBox3.Text And TextBox4.Text = "" Then
            MsgBox("Please Enter Student Phone number and Student Address")
        ElseIf TextBox3.Text And ComboBox1.Text = "" Then
            MsgBox("Please Enter Student Phone number and Student Gender")
        Else
            MsgBox("DataInserted Successfully")

        End If


        Dim cn As SqlConnection
        Dim cmd As SqlCommand
        cn = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=" & Application.StartupPath & "\Library Management .mdf;Integrated Security=True")
        cn.Open()

        cmd = New SqlCommand("insert into student values(" & TextBox1.Text & ",'" & TextBox2.Text & "','" & ComboBox1.Text & "'," & TextBox3.Text & ",'" & TextBox4.Text & "')", cn)
        cmd.ExecuteNonQuery()
        cn.Close()
        
        DispData()
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Dim cn As SqlConnection
        Dim cmd As SqlCommand
        cn = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=" & Application.StartupPath & "\Library Management .mdf;Integrated Security=True")
        cn.Open()
        cmd = New SqlCommand("update student set sname='" & TextBox2.Text & "',ph=" & TextBox3.Text & " where (sid=" & TextBox1.Text & ")", cn)
        cmd.ExecuteNonQuery()
        cn.Close()
        MessageBox.Show("Data Updated Successfully")
        DispData()
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Dim cn As SqlConnection
        Dim cmd As SqlCommand
        cn = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=" & Application.StartupPath & "\Library Management .mdf;Integrated Security=True")
        cn.Open()
        cmd = New SqlCommand("delete from student where (sid=" & TextBox1.Text & ")", cn)
        cmd.ExecuteNonQuery()
        cn.Close()
        MessageBox.Show("Data Deleted Successfully")
        DispData()
    End Sub

    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        Me.TextBox2.Text = ""
        Me.TextBox3.Text = ""
        Me.TextBox4.Text = ""
        Me.TextBox1.Text = ""
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub Student_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = 320
        cn = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=" & Application.StartupPath & "\Library Management .mdf;Integrated Security=True")
        cn.Open()
    End Sub
    Private Sub DispData()
        dgdata.Rows.Clear()
        Dim x As Integer = 0
        str = "Select * From student Order By sid"
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader
        While dr.Read
            dgdata.Rows.Add()
            dgdata.Rows(x).Cells(0).Value = dr("sid")
            dgdata.Rows(x).Cells(1).Value = dr("sname")
            dgdata.Rows(x).Cells(4).Value = dr("gender")
            dgdata.Rows(x).Cells(2).Value = dr("ph")
            dgdata.Rows(x).Cells(3).Value = dr("address")

            x = x + 1
        End While
        dr.Close()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Timer1.Enabled = True
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Timer2.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Height = Me.Height + 10
        If Me.Height >= 550 Then
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Me.Height = Me.Height - 10
        If Me.Height <= 320 Then
            Timer2.Enabled = False
        End If
    End Sub
End Class