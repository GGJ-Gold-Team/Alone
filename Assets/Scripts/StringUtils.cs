using System;

public static class StringUtils {
    public static string SpaceCase(string inputStr) {
        char[] charArray = inputStr.ToCharArray();
        string spacedString = "";
        for (int i = 0; i < charArray.Length; i++) {
            if (i > 0 && char.IsUpper(charArray[i])) {
                spacedString += " " + charArray[i];
            } else {
                spacedString += charArray[i];
            }
        }

        return spacedString;
    }

    public static string FormatTimer(float time) {
        int roundedTime = (int) System.Math.Ceiling(time);

        int minutes = roundedTime / 60;
        string minutesString = minutes.ToString();
        if (minutes < 10) {
            minutesString = String.Format("0{0}", minutes);
        }

        int seconds = roundedTime % 60;
        string secondsString = seconds.ToString();
        if (seconds < 10) {
            secondsString = String.Format("0{0}", seconds);
        }

        return String.Format("{0}:{1}", minutesString, secondsString);
    }
}