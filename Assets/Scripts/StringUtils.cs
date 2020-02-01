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
}