Class MainWindow

    Private Sub btnOrder_Click(sender As Object, e As RoutedEventArgs) Handles btnOrder.Click
        Dim result As New System.Text.StringBuilder()

        ' 1. 判斷內用 / 外帶
        Dim orderType As String = If(rbIn.IsChecked = True, "內用", "外帶")
        result.AppendLine($"訂購方式：{orderType}，訂購清單如下：")

        Dim itemCount As Integer = 1
        Dim totalSum As Integer = 0

        ' 2. 檢查各飲料項目
        CheckItem(chkRedBig, "紅茶大杯", 60, sliderRedBig.Value, itemCount, totalSum, result)
        CheckItem(chkRedSmall, "紅茶小杯", 40, sliderRedSmall.Value, itemCount, totalSum, result)
        CheckItem(chkGreenBig, "綠茶大杯", 60, sliderGreenBig.Value, itemCount, totalSum, result)
        CheckItem(chkGreenSmall, "綠茶小杯", 40, sliderGreenSmall.Value, itemCount, totalSum, result)
        CheckItem(chkCokeBig, "可樂大杯", 50, sliderCokeBig.Value, itemCount, totalSum, result)
        CheckItem(chkCokeSmall, "可樂小杯", 30, sliderCokeSmall.Value, itemCount, totalSum, result)

        ' 3. 結算與折扣（滿1000打8折）
        result.AppendLine($"總計：{totalSum}元")

        If totalSum >= 1000 Then
            Dim finalPrice As Integer = CInt(totalSum * 0.8)
            result.AppendLine($"總價{totalSum}打8折，售價為：{finalPrice}元")
        End If

        ' 4. 輸出顯示結果
        txtResult.Text = result.ToString()
    End Sub

    Private Sub CheckItem(chk As CheckBox, name As String, price As Integer, sliderVal As Double, ByRef count As Integer, ByRef total As Integer, sb As System.Text.StringBuilder)
        Dim qty As Integer = CInt(sliderVal)
        If chk.IsChecked = True AndAlso qty > 0 Then
            Dim itemTotal As Integer = price * qty
            total += itemTotal
            sb.AppendLine($"{count}. {name}:{price}元 X {qty}杯 = {itemTotal}元")
            count += 1
        End If
    End Sub

End Class