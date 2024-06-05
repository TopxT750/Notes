Public Class Form1

    Private newNoteCounter As Integer = 0

    Private Sub NewTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewTabToolStripMenuItem.Click
        CreateNewTab()
    End Sub

    Private Sub CreateNewTab()
        newNoteCounter += 1
        Dim newTab As New TabPage($"New Note {newNoteCounter}")
        Dim rtb As New RichTextBox()
        rtb.Dock = DockStyle.Fill
        rtb.BorderStyle = BorderStyle.None
        newTab.Controls.Add(rtb)
        Guna2TabControl1.TabPages.Add(newTab)
        Guna2TabControl1.SelectedTab = newTab
    End Sub

    Private Sub CloseTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseTabToolStripMenuItem.Click
        If Guna2TabControl1.TabPages.Count > 0 Then
            Guna2TabControl1.TabPages.Remove(Guna2TabControl1.SelectedTab)
        End If
    End Sub

    Private Function GetCurrentRichTextBox() As RichTextBox
        If Guna2TabControl1.TabPages.Count > 0 AndAlso TypeOf Guna2TabControl1.SelectedTab.Controls(0) Is RichTextBox Then
            Return CType(Guna2TabControl1.SelectedTab.Controls(0), RichTextBox)
        End If
        Return Nothing
    End Function

End Class
