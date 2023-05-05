int hours = -1;
int minutes = -1;
while (true)
{
	try
	{
		AskForInput(out hours, out minutes);
	}
	catch (Exception e)
	{
		Console.WriteLine("Please enter valid time: [hours: 0 - 23] and [minutes: 0 - 59]");
	}
	if (!(hours < 0 || hours > 23 || minutes < 0 || minutes > 59))
	{
		var output = CalculateLesserAngle(hours % 12, minutes);

		Console.WriteLine($"The lesser angle between the two hands at {hours}:{minutes:00} is equal to {output} degrees");
	}
	Console.WriteLine("Type \"Y\" if you still want to continue.");
	var continueAskInput = Console.ReadLine().ToLower().Trim();
	if (continueAskInput == "y")
	{
		Console.Clear();
	}
	else
	{
		break;
	}
}

void AskForInput(out int hoursInput, out int minutesInput )
{
	Console.Write("Please enter hours: ");
	hoursInput = int.Parse(Console.ReadLine());
	Console.Write("\nPlease enter minutes: ");
	minutesInput = int.Parse(Console.ReadLine());
	if (hoursInput < 0 || hoursInput > 23 || minutesInput < 0 || minutesInput > 59)
	{
		throw new Exception();
	}
}
float CalculateLesserAngle(int givenHours, int givenMinutes)
{
	//assuming that the 12 marker is the 0 degrees point
	//calculate the angle (clockwise) from start to the given hour/minute hand 
	var minuteAngle = givenMinutes * 6;
	var hourAngleBase = givenHours * 30;
	//take into consideration the offset of the hour hand based on the minutes
	var hourAngleFinal = hourAngleBase + 30 * givenMinutes / 60f;

	//calculate the angle (clockwise) from the minute to the hour hand
	var angle = Math.Abs(hourAngleFinal - minuteAngle);
	
	//if the angle is greater than 180 degrees, then the lesser angle would be the other angle.
	//This computation neglects the width of the hands.
	float lesserAngle = angle <= 180? angle : 360 - angle;

	return lesserAngle;
}
