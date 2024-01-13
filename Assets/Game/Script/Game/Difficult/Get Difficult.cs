public static class GetDifficult
{
    #region Difficults

    public static Difficult _difficult;

    private static float[] _ease = new float[8] { 9f, 0.75f, 1.5f, 5.5f, 100f, 1.5f, 15f, 0.5f };
    private static float[] _normal = new float[8] { 7f, 1f, 3f, 5f, 100f, 1.75f, 10f, 1f };
    private static float[] _hard = new float[8] { 6f, 1f, 3f, 5f, 150f, 2f, 5f, 2f };
    private static float[] _epic = new float[8] { 5f, 1.25f, 4f, 5f, 150f, 2.5f, 5f, 4f };
    private static float[] _custom;
    #endregion

    #region Get value
    public static void SetCustomValues(float[] values) => _custom = values;  
    public static float[] GetValues() =>
        _difficult switch
        {
            Difficult.EASE => _ease,
            Difficult.NORMAL => _normal,
            Difficult.HARD => _hard,
            Difficult.EPIC => _epic,
            Difficult.CUSTOM => _custom,
            _ => _normal,
        };
    public static float GetValue(DifficutValue value) =>
        _difficult switch
        {
            Difficult.EASE => _ease[(int)value],
            Difficult.NORMAL => _normal[(int)value],
            Difficult.HARD => _hard[(int)value],
            Difficult.EPIC => _epic[(int)value],
            Difficult.CUSTOM => _custom[(int)value],
            _ => _normal[(int)value],
        };
    #endregion
}

public enum Difficult
{
    EASE,
    NORMAL,
    HARD,
    EPIC,
    CUSTOM,
}
public enum DifficutValue
{
    DISTANCE_BETWEEN,
    PILLAR_WIDTH,
    SPAWN_OFFSET,
    SPAWN_DELAY,
    BASE_SPEED,
    SPEED_MULTIPLIER,
    SPEED_BREAK_POINT,
    MONEY_MODIFIER,
}
