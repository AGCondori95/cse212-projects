public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // 1. We need `length` values, and we know that exact size in advance,
        //    so a fixed-size array is the right structure (no list needed).
        // 2. The i-th element (0-indexed) is `number * (i + 1)`:
        //    i=0 -> number*1, i=1 -> number*2, ..., i=length-1 -> number*length
        // 3. Loop from 0 to length-1, assign result[i] = number * (i + 1).
        // 4. Return the array.
        // Edge case: length > 0 is guaranteed by the spec, so no need to guard
        // against length == 0 or negative.

        double[] result = new double[length];
        for (int i = 0; i < length; ++i)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // 1. Rotating right by `amount` means: the last `amount` elements
        //    move to the front, keeping their relative order, and the
        //    remaining elements follow after them.
        //    Example: {1,2,3,4,5,6,7,8,9}, amount=3
        //             tail = last 3 = {7,8,9}
        //             head = the rest = {1,2,3,4,5,6}
        //             result = tail + head = {7,8,9,1,2,3,4,5,6}
        // 2. splitIndex = data.Count - amount marks where the tail begins.
        // 3. Use GetRange to slice out head and tail as separate lists.
        // 4. Since the function must modify `data` in place, clear it and
        //    rebuild it: Clear() -> AddRange(tail) -> AddRange(head).
        // Edge case: amount == data.Count -> splitIndex == 0, head is empty,
        // tail is the whole list -> no visible change. Correct behavior.
        // Edge case: amount == 1 -> only the last element moves to front.

        int splitIndex = data.Count - amount;

        List<int> head = data.GetRange(0, splitIndex);
        List<int> tail = data.GetRange(splitIndex, amount);

        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
