public static class random_utils
{
	public static int[] generate_array(int count)
	{
		Random random = new Random();
		int[] values = new int[count];

		for (int i = 0; i < count; ++i)
			values[i] = random.Next();

		return values;
	}
}