public static class Arrays
{
        public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array to store the multiples.
        // The array should have a size equal to the value of 'length'.
        double[] result = new double[length];

        // Step 2: Loop through the array positions.
        // For each index i (starting at 0), calculate number * (i + 1).
        // Store the result in the array at index i.
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        // Step 3: Return the filled array.
        return result;
    }

    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Get the last 'amount' elements from the list.
        List<int> lastItems = data.GetRange(data.Count - amount, amount);

        // Step 2: Remove those items from the end.
        data.RemoveRange(data.Count - amount, amount);

        // Step 3: Insert each item from lastItems at the front of the list (in order).
        // Since inserting at index 0 pushes the existing items forward, we must insert in reverse order.
        for (int i = lastItems.Count - 1; i >= 0; i--)
        {
            data.Insert(0, lastItems[i]);
        }
    }
}
