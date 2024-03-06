namespace AstrobotanyLibrary.Classes.Utility
{
    public static class AnimationHelper
    {
        public static float Bezier(float value)
        {
            return value * value * (3f - 2f * value);
        }
        public static float Parametric(float value)
        {
            float timeSqrd = value * value;
            return timeSqrd / (2f * (timeSqrd - value) + 1f);
        }
        public static float Wobble(float value, int bounces = 1, float start = 1f, float end = 0f)
        {
            if (value == 0)
                return start;
            if (value == 1)
                return end;

            float scaled = bounces * MathF.PI * value;
            return (start - end) * (MathF.Sin(scaled) / scaled) + end;
        }
        public static float Bounce(float value, int bounces = 1, float start = 1f, float end = 0f)
        {
            if (value == 0)
                return start;
            if (value == 1)
                return end;

            float scaled = bounces * MathF.PI * value;
            return MathF.Abs((start - end) * (MathF.Sin(scaled) / scaled)) + end;
        }
    }
}