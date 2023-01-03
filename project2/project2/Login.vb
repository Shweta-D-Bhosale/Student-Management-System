Public Class Login

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        If TextBox1.Text = "admin" And TextBox2.Text = "12345" Then
            MessageBox.Show("Welcome to library Management System", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MDIParent1.Show()
            Me.Hide()
        Else
            MessageBox.Show("Invalid Login", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return

        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class