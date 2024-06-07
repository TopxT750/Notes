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
        rtb.ContextMenuStrip = RtbContextMenuStrip
        newTab.Controls.Add(rtb)
        TabControl.TabPages.Add(newTab)
        TabControl.SelectedTab = newTab
    End Sub

    Private Sub CloseTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseTabToolStripMenuItem.Click
        If TabControl.TabPages.Count > 0 Then
            TabControl.TabPages.Remove(TabControl.SelectedTab)
        End If
    End Sub

    Private Function GetCurrentRichTextBox() As RichTextBox
        If TabControl.TabPages.Count > 0 AndAlso TypeOf TabControl.SelectedTab.Controls(0) Is RichTextBox Then
            Return CType(TabControl.SelectedTab.Controls(0), RichTextBox)
        End If
        Return Nothing
    End Function

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        CreateNewTab()
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        CreateNewTab()
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        If TabControl.TabPages.Count > 0 Then
            TabControl.TabPages.Remove(TabControl.SelectedTab)
        End If
    End Sub
End Class
