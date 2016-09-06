<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fMain
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.comPortComboBox = New System.Windows.Forms.ComboBox()
        Me.connectDisconnectButton = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.bEnd = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.bScan = New System.Windows.Forms.Button()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bNormalize = New System.Windows.Forms.Button()
        Me.bTest = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'comPortComboBox
        '
        Me.comPortComboBox.FormattingEnabled = True
        Me.comPortComboBox.Location = New System.Drawing.Point(12, 12)
        Me.comPortComboBox.Name = "comPortComboBox"
        Me.comPortComboBox.Size = New System.Drawing.Size(99, 21)
        Me.comPortComboBox.Sorted = True
        Me.comPortComboBox.TabIndex = 15
        '
        'connectDisconnectButton
        '
        Me.connectDisconnectButton.Location = New System.Drawing.Point(12, 39)
        Me.connectDisconnectButton.Name = "connectDisconnectButton"
        Me.connectDisconnectButton.Size = New System.Drawing.Size(99, 21)
        Me.connectDisconnectButton.TabIndex = 17
        Me.connectDisconnectButton.Text = "&Connect"
        Me.connectDisconnectButton.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 236)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(298, 24)
        Me.StatusStrip1.TabIndex = 18
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(43, 19)
        Me.ToolStripStatusLabel1.Text = "Status"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(55, 19)
        Me.ToolStripStatusLabel2.Text = "Nothing"
        '
        'bEnd
        '
        Me.bEnd.Location = New System.Drawing.Point(136, 101)
        Me.bEnd.Name = "bEnd"
        Me.bEnd.Size = New System.Drawing.Size(50, 25)
        Me.bEnd.TabIndex = 19
        Me.bEnd.Text = "&End"
        Me.bEnd.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(12, 76)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'bScan
        '
        Me.bScan.Location = New System.Drawing.Point(136, 12)
        Me.bScan.Name = "bScan"
        Me.bScan.Size = New System.Drawing.Size(54, 34)
        Me.bScan.TabIndex = 21
        Me.bScan.Text = "&Scan"
        Me.bScan.UseVisualStyleBackColor = True
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(36, 19)
        Me.ToolStripStatusLabel3.Text = "Value"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(205, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 22
        '
        'bNormalize
        '
        Me.bNormalize.Location = New System.Drawing.Point(136, 52)
        Me.bNormalize.Name = "bNormalize"
        Me.bNormalize.Size = New System.Drawing.Size(67, 27)
        Me.bNormalize.TabIndex = 23
        Me.bNormalize.Text = "&Normalize"
        Me.bNormalize.UseVisualStyleBackColor = True
        '
        'bTest
        '
        Me.bTest.Location = New System.Drawing.Point(192, 101)
        Me.bTest.Name = "bTest"
        Me.bTest.Size = New System.Drawing.Size(67, 27)
        Me.bTest.TabIndex = 24
        Me.bTest.Text = "&Fill test"
        Me.bTest.UseVisualStyleBackColor = True
        '
        'fMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(298, 260)
        Me.Controls.Add(Me.bTest)
        Me.Controls.Add(Me.bNormalize)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bScan)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bEnd)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.connectDisconnectButton)
        Me.Controls.Add(Me.comPortComboBox)
        Me.Name = "fMain"
        Me.Text = "Pan Tilt Scanner"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents comPortComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents connectDisconnectButton As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents bEnd As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bScan As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bNormalize As System.Windows.Forms.Button
    Friend WithEvents bTest As System.Windows.Forms.Button

End Class
