'Imports System.IO

Public Class fMain
    Public Connected As Boolean = False
    Public TiltCenter As Integer
    Public PanCenter As Integer
    Public ServoMin As Integer
    Public ServoMax As Integer
    Public PanMin As Integer = 75
    Public PanMax As Integer = 150
    Public TiltMin As Integer = 75
    Public TiltMax As Integer = 150
    Public ValueMin As Integer = 0
    Public ValueMax As Integer = 255
    Public ImageWidth As Integer
    Public ImageHeight As Integer
    Public Stringa As String
    Public Pixels(300, 300) As Integer
    Public PixelMax As Integer
    Public PixelMin As Integer


    Private Sub fMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        updateComPortList()
        ToolStripStatusLabel1.Text = "Serial Port Closed"
        'SwitchToDegrees()
        Debug.Print("Start!")
        Debug.Print("Start!")
        ImageWidth = PanMax - PanMin
        ImageHeight = TiltMax - TiltMin
        PictureBox1.Width = ImageWidth + 1
        PictureBox1.Height = ImageHeight + 1
        bScan.Enabled = False

    End Sub
    Private Sub updateComPortList()
        If connectDisconnectButton.Text = "&Connect" Then
            comPortComboBox.Items.Clear()
            comPortComboBox.Items.Add("None")

            Dim s As String
            For Each s In IO.Ports.SerialPort.GetPortNames()
                comPortComboBox.Items.Add(s)
            Next s

            comPortComboBox.SelectedIndex = 0
            'baudRateComboBox.SelectedIndex = 0
        End If
    End Sub
    Private Sub connectDisconnectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles connectDisconnectButton.Click

        If connectDisconnectButton.Text = "&Connect" Then
            If comPortOpen() Then
                connectDisconnectButton.Text = "&Disconnect"
                bScan.Enabled = True
                'Ferma = False
                'GetData()
            Else
                'TextBox.AppendText("Error: Unable to open specified Com Port")
            End If
        Else
            'Ferma = True
            'SerialPort1.Close()
            ToolStripStatusLabel1.Text = "Serial Port Closed"
            connectDisconnectButton.Text = "&Connect"
        End If
    End Sub
    Private Function comPortOpen() As Boolean
        Dim portName As String = Nothing
        Dim baudRate As Integer

        portName = comPortComboBox.Text
        baudRate = Convert.ToInt32(115200)

        comPortOpen = True

        Try

            With SerialPort1
                .BaudRate = baudRate
                .PortName = portName
                .DataBits = 8
                .Parity = IO.Ports.Parity.None
                .StopBits = IO.Ports.StopBits.One
                .Encoding = System.Text.Encoding.Default
                '.ReceivedBytesThreshold = 1
                '.ReadTo(vbCrLf)
                .Handshake = IO.Ports.Handshake.None
                .Open()
            End With
            Connected = True
        Catch ex As Exception
            ToolStripStatusLabel1.Text = "Unable to open"
            Connected = False
            Return False

        End Try
        'portName = comPortComboBox.Text
        'baudRate = Convert.ToInt32(baudRateComboBox.Text)

        'textBox.AppendText("Port Name :" & portName & vbCrLf)
        'textBox.AppendText("Baud Rate :" & baudRate & vbCrLf)

        'SerialPort1.PortName = portName
        'SerialPort1.BaudRate = baudRate
        'SerialPort1.Open()

        'If SerialPort1.IsOpen Then
        '    textBox.AppendText("Serial Port Opened")
        '    textBox.AppendText(Environment.NewLine)
        '    Return True
        'End If

        'TextBox.AppendText("Serial Port Opened")
        ToolStripStatusLabel1.Text = "Serial Port Opened"
        'TextBox.AppendText(Environment.NewLine)
        Return True
    End Function
    Private Sub comPortComboBox_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comPortComboBox.DropDown
        updateComPortList()
    End Sub
    Private Sub SendPanTilt(Pan As Integer, Tilt As Integer)
        Dim message As String

        'Exit Sub

        message = Pan
        message &= ","
        message &= Tilt
        'ToolStripStatusLabel2.Text = message

        message = Chr(CInt(Pan))
        message &= Chr(CInt(Tilt))
        message &= Chr(255)


        If Connected = True Then
            SerialPort1.Write(message)
        End If
    End Sub
    'Private Sub SerialPort1_DataReceived(sender As Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
    '    Dim stringa As String
    '    stringa = SerialPort1.ReadExisting
    '    'SerialRX.Text &= stringa
    '    'If SerialRX.
    '    Debug.Print(stringa)

    'End Sub

    Private Sub bEnd_Click(sender As System.Object, e As System.EventArgs) Handles bEnd.Click
        If Connected = True Then
            SerialPort1.Close()
        End If
        If SerialPort1.IsOpen = True Then
            SerialPort1.Close()
        End If
        End
    End Sub

    Private Sub bScan_Click(sender As System.Object, e As System.EventArgs) Handles bScan.Click
        Dim Pan, Tilt, x, y As Integer
        Dim value As Integer
        Dim Start As Date
        Dim Stopp As Date
        Dim TimeElapsed As System.TimeSpan
        PixelMax = 0
        PixelMin = 255

        Start = Now

        Label1.Text = "Scanning"
        SerialPort1.DiscardInBuffer()
        'PictureBox1.Image = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim Bitmappa = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        For Pan = PanMin To PanMax
            For Tilt = TiltMin To TiltMax
                SendPanTilt(Pan, Tilt)
                'value = Pan + Tilt
                value = SerialPort1.ReadByte
                x = Pan - PanMin
                y = Tilt - TiltMin
                If value > PixelMax Then
                    PixelMax = value
                End If

                If value < PixelMin Then
                    PixelMin = value

                End If
                Pixels(Pan, Tilt) = value

                'Bitmap.SetPixel(Pan, Tilt, Color.FromArgb(255, 255, 0))
                'PictureBox1.Image.
                'DirectCast(PictureBox1.Image, Bitmap).SetPixel(x, y, Color.FromArgb(value, 0, 0))
                Bitmappa.SetPixel(x, y, Color.FromArgb(value, 0, 0))
                ToolStripStatusLabel3.Text = value.ToString
                PictureBox1.Image = Bitmappa
            Next
        Next
        'PictureBox1.Refresh()
        PictureBox1.Image = Bitmappa
        Stopp = Now
        TimeElapsed = Stopp - Start
        ToolStripStatusLabel3.Text = TimeElapsed.ToString
        Label1.Text = "Done!"
    End Sub

    Private Sub bNormalize_Click(sender As System.Object, e As System.EventArgs) Handles bNormalize.Click
        Dim pan, tilt, x, y As Integer
        Dim m As Single
        Dim q As Integer
        Dim Start As Date
        Dim Stopp As Date
        Dim TimeElapsed As System.TimeSpan
        Dim Bitmappa = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim oldvalue As Integer
        Dim range As Integer

        Label1.Text = "Normalizing"
        Start = Now
        If PixelMax = PixelMin Then
            Label1.Text = "Pmax=Pmin"
            Exit Sub
        End If

        m = 255 / (PixelMax - PixelMin)
        q = (-PixelMin * 255) / (PixelMax - PixelMin)
        range = PixelMax - PixelMin
        For pan = PanMin To PanMax
            For tilt = TiltMin To TiltMax
                oldvalue = Pixels(pan, tilt)
                'Pixels(pan, tilt) = CInt(Pixels(pan, tilt) * m - PixelMin)
                'Pixels(pan, tilt) = CInt(Pixels(pan, tilt) * m - q)
                Pixels(pan, tilt) = CInt((Pixels(pan, tilt) - PixelMin) / range * 255)
                x = pan - PanMin
                y = tilt - TiltMin
                Bitmappa.SetPixel(x, y, Color.FromArgb(Pixels(pan, tilt), 0, 0))
            Next
        Next

        PictureBox1.Image = Bitmappa
        Stopp = Now
        TimeElapsed = Stopp - Start
        ToolStripStatusLabel3.Text = TimeElapsed.ToString
        Label1.Text = "Done!"
    End Sub

    Private Sub bTest_Click(sender As System.Object, e As System.EventArgs) Handles bTest.Click
        Dim Pan, Tilt, x, y As Integer
        Dim value As Integer
        Dim Start As Date
        Dim Stopp As Date
        Dim TimeElapsed As System.TimeSpan
        PixelMax = 0
        PixelMin = 255

        Start = Now

        Label1.Text = "Filling"
        'PictureBox1.Image = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim Bitmappa = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        For Pan = PanMin To PanMax
            For Tilt = TiltMin To TiltMax
                value = Pan
                x = Pan - PanMin
                y = Tilt - TiltMin
                If value > PixelMax Then
                    PixelMax = value
                End If
                If value < PixelMin Then
                    PixelMin = value
                End If
                Pixels(Pan, Tilt) = value

                'Bitmap.SetPixel(Pan, Tilt, Color.FromArgb(255, 255, 0))
                'PictureBox1.Image.
                'DirectCast(PictureBox1.Image, Bitmap).SetPixel(x, y, Color.FromArgb(value, 0, 0))
                Bitmappa.SetPixel(x, y, Color.FromArgb(value, 0, 0))
                'ToolStripStatusLabel3.Text = value.ToString
                PictureBox1.Image = Bitmappa
            Next
        Next
        'PictureBox1.Refresh()
        PictureBox1.Image = Bitmappa
        Stopp = Now
        TimeElapsed = Stopp - Start
        ToolStripStatusLabel3.Text = TimeElapsed.ToString
        Label1.Text = "Done!"
    End Sub
End Class
