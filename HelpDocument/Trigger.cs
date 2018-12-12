About Trigger:
	    <TextBlock Text="Hello, styled world!" FontSize="28" HorizontalAlignment="Center" VerticalAlignment="Center">
            <TextBlock.Style>
			<!--Here you can set a property of control-->
                <Style TargetType="TextBlock">
				<!--TargetType can help you to set all the specific control-->
                    <Setter Property="Foreground" Value="Blue"></Setter>
					<!--Setter as your target control-->
                    <Style.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
						<!--IsMouseOver is a Event-->
                            <Setter Property="Foreground" Value="Red" />
                            <Setter Property="TextDecorations" Value="Underline" />
                        </Trigger>
                    </Style.Triggers>
					<!--Actually Setter and Trigger at the same level-->
                </Style>
            </TextBlock.Style>
        </TextBlock>