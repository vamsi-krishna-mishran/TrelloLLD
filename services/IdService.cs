

public class IdGeneratorService
{


    public string GenerateId()
    {
        DateTime dt = DateTime.UtcNow;

        // Use the correct number of bits for each component
        long year = (long)(dt.Year - 2000); // 12 bits, starting from year 2000 (so 2000 becomes 0)
        long month = (long)dt.Month;        // 4 bits
        long day = (long)dt.Day;            // 5 bits
        long hour = (long)dt.Hour;          // 5 bits
        long minute = (long)dt.Minute;      // 6 bits
        long second = (long)dt.Second;      // 6 bits
        long millisecond = (long)dt.Millisecond; // 10 bits

        // Start with zero and build the ID by shifting and OR'ing values
        long id = 0;

        // Shift bits and combine values into a single long
        id |= (year << 52);           // 12 bits for year
        id |= (month << 48);          // 4 bits for month
        id |= (day << 43);            // 5 bits for day
        id |= (hour << 38);           // 5 bits for hour
        id |= (minute << 32);         // 6 bits for minute
        id |= (second << 26);         // 6 bits for second
        id |= (millisecond << 16);    // 10 bits for millisecond

        // Convert the long ID to a hexadecimal string
        string hexString = id.ToString("x");

        // Ensure hexString is even length for better formatting
        if (hexString.Length % 2 != 0)
        {
            hexString = "0" + hexString;
        }

        return hexString;
    }

}